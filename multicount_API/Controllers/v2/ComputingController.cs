using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using multicount_API.Logging;
using multicount_API.Models;
using multicount_API.Models.Dto;
using multicount_API.Repository.IRepository;
using System.Net;

namespace multicount_API.Controllers.v2
{

    [Route("api/v{version:apiVersion}/Computing")]
    [ApiController]
    [ApiVersion("2.0")]
    public class ComputingController : ControllerBase
    {
        protected APIResponse _response;
        private readonly ILogging _logger;
        private readonly IMapper _mapper;
        private readonly IGroupRepository _dbGroup;
        private readonly IGroupUserRepository _dbGroupUser;
        private readonly ITransactionRepository _dbTransaction;

        public ComputingController(IMapper mapper, ILogging logger, IGroupRepository dbGroup, IGroupUserRepository dbGroupUser, ITransactionRepository dbTransaction)
        {
            _logger = logger;
            _mapper = mapper;
            _dbGroup = dbGroup;
            _dbGroupUser = dbGroupUser;
            _dbTransaction = dbTransaction;
            _response = new APIResponse();
        }
        [HttpGet]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> ComputeAmount(int groupId)
        {
            _logger.Log("Computing amounts", "info");
            try
            {
                var includeProperties = "GroupsUsers";

                Group myGroup = await _dbGroup.GetAsync(t => t.Id == groupId, includeProperties: includeProperties);

                var groupsUsers = await _dbGroupUser.GetAllAsync();
                myGroup.GroupsUsers = groupsUsers.Where(t => t.GroupId == groupId).ToList();

                var myTransactions = await _dbTransaction.GetAllAsync(t => t.GroupId == groupId, includeProperties: "TransactionsUsers,LocalUser") ;

                GroupsUsersDTO updatedModel  = new GroupsUsersDTO();

                List<KeyValuePair<string, float>> calc = new List<KeyValuePair<string, float>>();

                foreach (var transac in myTransactions)
                {
                    foreach( var user in transac.TransactionsUsers)
                    {
                        updatedModel.GroupId = groupId;
                        KeyValuePair<string, float> keyVal = new KeyValuePair<string, float>(user.UserId, transac.Amount / transac.TransactionsUsers.Count());
                        calc.Add(keyVal);

                        GroupsUsers resDebts = _mapper.Map<GroupsUsers>(updatedModel);
                        await _dbGroupUser.UpdateAsync(resDebts);
                    }
                    updatedModel.GroupId = groupId;
                    updatedModel.UserId = transac.LocalUser.Id;
                    updatedModel.Amount = transac.Amount;
                    GroupsUsers res = _mapper.Map<GroupsUsers>(updatedModel);
                    await _dbGroupUser.UpdateAsync(res);
                }
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
