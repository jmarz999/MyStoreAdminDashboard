using Microsoft.AspNetCore.Mvc;
using MyStoreAdminDashboard.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyStoreAdminDashboard.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserAppService userAppService;

        public UserController(IUserAppService userAppService)
        {
            this.userAppService = userAppService;
        }

        public async Task<IActionResult> ManageUsers()
        {
            List<UserDto> models = await userAppService.GetAllAsync();

            return View(models);
        }

        public async Task<IActionResult> GetById(string id)
        {
            UserDto model = await userAppService.GetByIdAsync(id);
            return View(model);
        }

        public async Task<IActionResult> CreateUser()
        {
            CreateUserDto model = new CreateUserDto();

            model.GenderValues = await userAppService.GetGenderValues();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto user)
        {
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

        public async Task<IActionResult> EditUser(string id)
        {
            UserDto model = await userAppService.GetByIdAsync(id);
            model.GenderValues = new List<string>();

            model.GenderValues = await userAppService.GetGenderValues();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(UserDto model)
        {
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

        public async Task<IActionResult> Delete(string id)
        {
            await userAppService.DeleteAsync(id);
            return RedirectToAction(nameof(ManageUsers));
        }
    }
}