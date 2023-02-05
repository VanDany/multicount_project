using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using multicount_API.Data;
using multicount_API.Logging;
using multicount_API.Models;
using multicount_API.Models.Dto;
using multicount_API.Repository.IRepository;
using System.Net;
using System.Text.Json;

namespace multicount_API.Controllers.v1
{
    [Route("api/v{version:apiVersion}/Transaction")]
    [ApiController]
    [ApiVersionNeutral]
    public class TransactionAPIController : ControllerBase
    {
        protected APIResponse _response;
        private readonly ITransactionRepository _dbTransaction;
        private readonly ICategoryRepository _dbCategory;
        private readonly ITransactionUserRepository _dbTransactionUser;
        private readonly ILogging _logger;
        private readonly IMapper _mapper;

        public TransactionAPIController(ITransactionRepository dbTransaction, ITransactionUserRepository dbTransactionUser, ICategoryRepository dbCategory, IMapper mapper, ILogging logger)
        {
            _dbTransaction = dbTransaction;
            _dbCategory = dbCategory;
            _logger = logger;
            _mapper = mapper;
            _dbTransactionUser = dbTransactionUser;
            _response = new APIResponse();
        }

        [HttpGet]
        [ResponseCache(CacheProfileName = "Default30")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetTransactions(
            [FromQuery(Name = "filterAmount")] float amount,
            [FromQuery] string search, int pageSize = 0, int pageNumber = 1)
        {
            _logger.Log("Getting all transactions", "info");
            try
            {
                var includeProperties = "Category,LocalUser,TransactionsUsers";
                IEnumerable<Transaction> transactionsList;
                if (amount > 0)
                {
                    transactionsList = await _dbTransaction.GetAllAsync(u => u.Amount == amount, includeProperties: includeProperties, pageSize: pageSize, pageNumber: pageNumber);
                }
                else transactionsList = await _dbTransaction.GetAllAsync(includeProperties: includeProperties, pageSize: pageSize, pageNumber: pageNumber);
                if (!string.IsNullOrEmpty(search))
                {
                    transactionsList = transactionsList.Where(u => u.Description.ToLower().Contains(search) || u.CategoryId.ToString().Contains(search));
                }

                var transactionUser = await _dbTransactionUser.GetAllAsync(includeProperties: "LocalUser");
                
                Pagination pagination = new() { PageNumber = pageNumber, PageSize = pageSize };

                Response.Headers.Add("Pagination", JsonSerializer.Serialize(pagination));
                foreach (var transaction in transactionsList)
                {
                    transaction.TransactionsUsers = transactionUser.Where(t => t.TransactionId == transaction.Id).ToList();
                }
                _response.Result = _mapper.Map<List<TransactionDTO>>(transactionsList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string> { ex.Message.ToString() };
            }
            return _response;
        }
        [HttpGet("{id:int}", Name = "GetTransaction")]
        [ResponseCache(CacheProfileName = "Default30")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetTransaction(int id)
        {
            try
            {
                if (id == 0)
                {
                    _logger.Log("Get transaction error with Id " + id, "error");
                    return BadRequest();
                }
                var transaction = await _dbTransaction.GetAsync(u => u.Id == id, includeProperties: "Category,LocalUser,TransactionsUsers");
                var transactionUser = await _dbTransactionUser.GetAllAsync(t => t.TransactionId == transaction.Id, includeProperties: "LocalUser");
                if (transaction == null)
                {
                    return NotFound();
                }
                transaction.TransactionsUsers = transactionUser;
                var transactionDetails = _mapper.Map<Transaction>(transaction);
                _response.Result = transactionDetails;
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string> { ex.Message.ToString() };
            }
            return _response;
        }
    }
}
