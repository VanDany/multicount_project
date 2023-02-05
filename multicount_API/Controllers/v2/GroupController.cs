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
    [Route("api/v{version:apiVersion}/Group")]
    [ApiController]
    [ApiVersion("2.0")]
    public class GroupController : ControllerBase
    {
        protected APIResponse _response;
        private readonly ILogging _logger;
        private readonly IMapper _mapper;
        private readonly IGroupRepository _dbGroup;

        public GroupController(IMapper mapper, ILogging logger, IGroupRepository dbGroup)
        {
            _logger = logger;
            _mapper = mapper;
            _dbGroup= dbGroup;
            _response = new APIResponse();
        }
        [HttpGet]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetGroups()
        {
            _logger.Log("Getting all groups", "info");
            try
            {
                IEnumerable<Group> groupsList = await _dbGroup.GetAllAsync();
                _response.Result = _mapper.Map<List<GroupDTO>>(groupsList);
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
        [HttpGet("{id:int}", Name = "GetGroup")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetGroup(int id)
        {
            try
            {
                if (id == 0)
                {
                    _logger.Log("Get group error with Id " + id, "error");
                    return BadRequest();
                }
                var group = await _dbGroup.GetAsync(u => u.Id == id);
                if (group == null)
                {
                    return NotFound();
                }
                _response.Result = _mapper.Map<Group>(group);
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
        public async Task<ActionResult<APIResponse>> PostUser([FromBody] GroupCreateDTO createDTO)
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
                Group group = _mapper.Map<Group>(createDTO);

                await _dbGroup.CreateAsync(group);
                _response.Result = _mapper.Map<GroupDTO>(group);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetGroup", new { id = group.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string> { ex.Message.ToString() };
            }
            return _response;
        }

        [HttpDelete("{id:int}", Name = "DeleteGroup")]
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
                var group = await _dbGroup.GetAsync(u => u.Id.Equals(id));
                if (group == null)
                {
                    return NotFound();
                }
                await _dbGroup.RemoveAsync(group);
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

        [HttpPut("{id:int}", Name = "UpdateGroup")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateGroup(int id, [FromBody] GroupUpdateDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || !id.Equals(updateDTO.Id))
                {
                    return BadRequest();
                }

                Group model = _mapper.Map<Group>(updateDTO);

                await _dbGroup.UpdateAsync(model);
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
