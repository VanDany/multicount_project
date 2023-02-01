using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Multicount_Utility;
using Multicount_WEB.Models;
using Multicount_WEB.Models.Dto;
using Multicount_WEB.Models.VM;
using Multicount_WEB.Services;
using Multicount_WEB.Services.IServices;
using Newtonsoft.Json;
using System.Data;

namespace Multicount_WEB.Controllers
{
    public class LocalUserController : Controller
    {
        private readonly ILocalUserService _localUserService;
        private readonly IMapper _mapper;
        public LocalUserController(ILocalUserService localUserService, IMapper mapper)
        {
            _localUserService = localUserService;
            _mapper = mapper;
        }

        public async Task<IActionResult> IndexLocalUser()
        {
            List<LocalUserDTO> list = new();
            var response = await _localUserService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response is not null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<LocalUserDTO>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateLocalUser()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateLocalUser(LocalUserCreateDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _localUserService.CreateAsync<APIResponse>(model, HttpContext.Session.GetString(SD.SessionToken));
                if (response is not null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexLocalUser));
                }
            }
            return View(model);
        }
        //[Authorize(Roles = "admin")]
        //public async Task<IActionResult> UpdateLocalUser(int localUserId)
        //{
        //    LocalUserUpdateVM localUserUpdateVM = new();
        //    var response = await _localUserService.GetAsync<APIResponse>(localUserId, HttpContext.Session.GetString(SD.SessionToken));
        //    if (response is not null && response.IsSuccess)
        //    {
        //        LocalUserDTO model = JsonConvert.DeserializeObject<LocalUserDTO>(Convert.ToString(response.Result));
        //        localUserUpdateVM.LocalUser = (_mapper.Map<LocalUserUpdateDTO>(model));
        //    }
        //    response = await _localUserService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
        //    if (response is not null && response.IsSuccess)
        //    {
        //        return View(localUserUpdateVM);
        //    }
        //    return NotFound();
        //}
        //[Authorize(Roles = "admin")]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> UpdateLocalUser(localUserUpdateVM model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var response = await _localUserService.UpdateAsync<APIResponse>(model.localUser, HttpContext.Session.GetString(SD.SessionToken));
        //        if (response is not null && response.IsSuccess)
        //        {
        //            TempData["success"] = "Local User updated successfully";
        //            return RedirectToAction(nameof(IndexLocalUser));
        //        }
        //        else
        //        {
        //            if (response.ErrorMessages.Count > 0)
        //            {
        //                ModelState.AddModelError("ErrorMessages", response.ErrorMessages.FirstOrDefault());
        //            }
        //        }
        //    }
        //    TempData["error"] = "Error encountered.";
        //    return View(model);
        //}
        //[Authorize(Roles = "admin")]
        //public async Task<IActionResult> DeleteLocalUser(int localUserId)
        //{
        //    LocalUserDeleteVM localUserDeleteVM = new();
        //    var response = await _localUserService.GetAsync<APIResponse>(localUserId, HttpContext.Session.GetString(SD.SessionToken));
        //    if (response is not null && response.IsSuccess)
        //    {
        //        LocalUserDTO model = JsonConvert.DeserializeObject<LocalUserDTO>(Convert.ToString(response.Result));
        //        localUserDeleteVM.LocalUser = (_mapper.Map<LocalUserDTO>(model));
        //    }
        //    response = await _localUserService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
        //    if (response is not null && response.IsSuccess)
        //    {
        //        return View(localUserDeleteVM);
        //    }
        //    return NotFound();
        //}
        //[Authorize(Roles = "admin")]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteLocalUser(LocalUserDTO model)
        //{
        //    var response = await _localUserService.DeleteAsync<APIResponse>(model.Id, HttpContext.Session.GetString(SD.SessionToken));
        //    if (response is not null && response.IsSuccess)
        //    {
        //        TempData["success"] = "Local User deleted successfully";
        //        return RedirectToAction(nameof(IndexLocalUser));
        //    }
        //    TempData["error"] = "Error encountered.";

        //    return View(model);
        //}
    }
}
