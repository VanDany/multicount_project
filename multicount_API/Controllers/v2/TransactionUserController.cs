using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using multicount_API.Logging;
using multicount_API.Models;
using multicount_API.Repository.IRepository;
using System.Net;

namespace multicount_API.Controllers.v2
{
    [Route("api/v{version:apiVersion}/TransactionUser")]
    [ApiController]
    [ApiVersionNeutral]
    public class TransactionUserController : Controller
    {
        protected APIResponse _response;
        private readonly ITransactionUserRepository _dbTransactionUser;
        private readonly ILogging _logger;
        private readonly IMapper _mapper;
        public TransactionUserController(ITransactionUserRepository dbTransactionUser, IMapper mapper, ILogging logger)
        {
            _logger = logger;
            _mapper = mapper;
            _dbTransactionUser = dbTransactionUser;
            _response = new APIResponse();
        }
        [HttpGet]
        [ResponseCache(CacheProfileName = "Default30")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetTransactionsUsersByTransactionId(int transactionId)
        {
            try
            {
                if (transactionId == 0)
                {
                    _logger.Log("Get transactionsUsers error with the transactionId " + transactionId, "error");
                    return BadRequest();
                }
                IEnumerable<TransactionsUsers> transactionsUsersList;
                transactionsUsersList = await _dbTransactionUser.GetAllAsync(u => u.TransactionId == transactionId);
                if (transactionsUsersList == null)
                {
                    return NotFound();
                }
                _response.Result = _mapper.Map<List<TransactionsUsers>>(transactionsUsersList);
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
