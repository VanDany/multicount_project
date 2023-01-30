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
    [Route("api/v{version:apiVersion}/LocalUser")]
    [ApiController]
    [ApiVersion("2.0")]
    public class LocalUserController : ControllerBase
    {
        protected APIResponse _response;
        private readonly ILogging _logger;
        private readonly IMapper _mapper;
        private readonly ILocalUserRepository _dbLocalUser;

        public LocalUserController(IMapper mapper, ILogging logger, ILocalUserRepository dbLocalUser)
        {
            _logger = logger;
            _mapper = mapper;
            _dbLocalUser = dbLocalUser;
            _response = new APIResponse();
        }
        [HttpGet]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetUsers()
        {
            _logger.Log("Getting all users", "info");
            try
            {
                IEnumerable<LocalUser> usersList = await _dbLocalUser.GetAllAsync();
                _response.Result = _mapper.Map<List<LocalUserDTO>>(usersList);
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
        [HttpGet("{id:int}", Name = "GetUser")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetUser(int id)
        {
            try
            {
                if (id == 0)
                {
                    _logger.Log("Get user error with Id " + id, "error");
                    return BadRequest();
                }
                var user = await _dbLocalUser.GetAsync(u => u.Id.Equals(id));
                if (user == null)
                {
                    return NotFound();
                }
                _response.Result = _mapper.Map<LocalUser>(user);
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
        [HttpPost]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> PostUser([FromBody] LocalUserCreateDTO createDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (createDTO is null)
                {
                    return BadRequest(createDTO);
                }
                LocalUser user = _mapper.Map<LocalUser>(createDTO);

                await _dbLocalUser.CreateAsync(user);
                _response.Result = _mapper.Map<LocalUserDTO>(user);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetUser", new { id = user.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string> { ex.Message.ToString() };
            }
            return _response;
        }

        [HttpDelete("{id:int}", Name = "DeleteUser")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> DeleteUser(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var user = await _dbLocalUser.GetAsync(u => u.Id.Equals(id));
                if (user == null)
                {
                    return NotFound();
                }
                await _dbLocalUser.RemoveAsync(user);
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

        [HttpPut("{id:int}", Name = "UpdateUser")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateUser(int id, [FromBody] LocalUserUpdateDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || !id.Equals(updateDTO.Id))
                {
                    return BadRequest();
                }

                LocalUser model = _mapper.Map<LocalUser>(updateDTO);

                await _dbLocalUser.UpdateAsync(model);
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
