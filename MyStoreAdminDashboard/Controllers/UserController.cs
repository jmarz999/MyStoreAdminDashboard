using Microsoft.AspNetCore.Mvc;
using MyStoreAdminDashboard.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyStoreAdminDashboard.Helpers;

namespace MyStoreAdminDashboard.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserAppService userAppService;

        public UserController(IUserAppService userAppService)
        {
            this.userAppService = userAppService;
        }

        [Authorize]
        public async Task<IActionResult> ManageUsers()
        {
            HttpContext.Session.TryGetValue("Token", out byte[] token);

            List<UserDto> models = await userAppService.GetAllAsync(Encoding.ASCII.GetString(token));

            return View(models);
        }

        [Authorize]
        public async Task<IActionResult> GetById(string id)
        {
            HttpContext.Session.TryGetValue("Token", out byte[] token);

            UserDto model = await userAppService.GetByIdAsync(id);
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> CreateUser()
        {
            HttpContext.Session.TryGetValue("Token", out byte[] token);

            CreateUserDto model = new CreateUserDto();

            model.GenderValues = await userAppService.GetGenderValues();
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateUser(CreateUserDto user)
        {
            HttpContext.Session.TryGetValue("Token", out byte[] token);

            try
            {
                if (ModelState.IsValid)
                {
                    var response = await userAppService.CreateAsync(user);
                    if (string.IsNullOrWhiteSpace(response))
                    {
                        return RedirectToAction(nameof(ManageUsers));
                    }
                    else
                    {
                        ModelState.AddModelError(String.Empty, response);
                    }
                }

                user.GenderValues = await userAppService.GetGenderValues();

                return View(user);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [Authorize]
        public async Task<IActionResult> EditUser(string id)
        {
            HttpContext.Session.TryGetValue("Token", out byte[] token);

            UserDto model = await userAppService.GetByIdAsync(id);
            model.GenderValues = new List<string>();

            model.GenderValues = await userAppService.GetGenderValues();
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> EditUser(UserDto model)
        {
            HttpContext.Session.TryGetValue("Token", out byte[] token);

            if (ModelState.IsValid)
            {
                var response = await userAppService.UpdateAsync(model);
                if (string.IsNullOrWhiteSpace(response))
                {
                    return RedirectToAction(nameof(ManageUsers));
                }
                else
                {
                    ModelState.AddModelError(String.Empty, response);
                }
            }

            model.GenderValues = await userAppService.GetGenderValues();
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Delete(string id)
        {
            HttpContext.Session.TryGetValue("Token", out byte[] token);

            try
            {
                await userAppService.DeleteAsync(id);
                return RedirectToAction(nameof(CreateUser));
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}