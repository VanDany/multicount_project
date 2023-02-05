using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Multicount_Utility;
using Multicount_WEB.Models.Dto;
using Multicount_WEB.Models;
using Multicount_WEB.Models.Dto;
using Multicount_WEB.Services.IServices;
using Newtonsoft.Json;

namespace Multicount_WEB.Controllers
{
    public class GroupController : Controller
    {
        private readonly IGroupService _groupService;
        private readonly IMapper _mapper;
        public GroupController(IGroupService groupService, IMapper mapper)
        {
            _groupService = groupService;
            _mapper = mapper;
        }
        public async Task<IActionResult> IndexGroup()
        {
            HttpContext.Session.SetString("groupId", "0");
            List<GroupDTO> list = new();
            var response = await _groupService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response is not null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<GroupDTO>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
        public IActionResult GroupValidation(int GroupId)
        {
            var group = GroupId;
            HttpContext.Session.SetString("groupId", GroupId.ToString());

            return RedirectToAction("IndexTransaction", "Transaction");
        }
    }
}
