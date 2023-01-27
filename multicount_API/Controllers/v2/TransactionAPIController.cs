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

namespace multicount_API.Controllers.v2
{
    [Route("api/v{version:apiVersion}/Transaction")]
    [ApiController]
    [ApiVersion("2.0")]
    public class TransactionAPIController : ControllerBase
    {
        protected APIResponse _response;
        private readonly ITransactionRepository _dbTransaction;
        private readonly ICategoryRepository _dbCategory;
        private readonly ILogging _logger;
        private readonly IMapper _mapper;

        public TransactionAPIController(ITransactionRepository dbTransaction, ICategoryRepository dbCategory, IMapper mapper, ILogging logger)
        {
            _dbTransaction = dbTransaction;
            _dbCategory = dbCategory;
            _logger = logger;
            _mapper = mapper;
            _response = new APIResponse();
        }
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> PostTransaction([FromBody] TransactionCreateDTO createDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                else if (await _dbTransaction.GetAsync(u => u.Description.ToLower() == createDTO.Description.ToLower()) != null)
                {
                    ModelState.AddModelError("ErrorMessages", "Transaction already Exists!");
                    return BadRequest(ModelState);
                }
                if (createDTO.CategoryId is not null && await _dbCategory.GetAsync(u => u.Id == createDTO.CategoryId) == null)
                {
                    ModelState.AddModelError("ErrorMessages", "CategoryId is invalid!");
                    return BadRequest(ModelState);
                }
                if (createDTO is null)
                {
                    return BadRequest(createDTO);
                }
                var userId = HttpContext.User.Claims.FirstOrDefault(t => t.Type == "userId").Value;
                Transaction transaction = _mapper.Map<Transaction>(createDTO);
                transaction.UserId = userId;
                transaction.CreatedDate = DateTime.Now;
                await _dbTransaction.CreateAsync(transaction);
                _response.Result = _mapper.Map<TransactionDTO>(transaction);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetTransaction", new { id = transaction.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string> { ex.Message.ToString() };
            }
            return _response;
        }

        [HttpDelete("{id:int}", Name = "DeleteTransaction")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> DeleteTransaction(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var transaction = await _dbTransaction.GetAsync(u => u.Id == id);
                if (transaction == null)
                {
                    return NotFound();
                }
                await _dbTransaction.RemoveAsync(transaction);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
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

        [HttpPut("{id:int}", Name = "UpdateTransaction")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateTransaction(int id, [FromBody] TransactionUpdateDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || id != updateDTO.Id)
                {
                    return BadRequest();
                }
                if (updateDTO.CategoryId is not null && await _dbCategory.GetAsync(u => u.Id == updateDTO.CategoryId) == null)
                {
                    ModelState.AddModelError("ErrorMessages", "CategoryId is invalid!");
                    return BadRequest(ModelState);
                }
                var userId = HttpContext.User.Claims.FirstOrDefault(t => t.Type == "userId").Value;
                Transaction model = _mapper.Map<Transaction>(updateDTO);
                model.UserId = userId;
                model.UpdatedDate= DateTime.Now;
                await _dbTransaction.UpdateAsync(model);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
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
