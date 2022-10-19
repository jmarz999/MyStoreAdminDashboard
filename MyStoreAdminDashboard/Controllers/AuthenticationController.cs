using Microsoft.AspNetCore.Mvc;
using MyStoreAdminDashboard.Services;
using System;
using System.Text;
using System.Threading.Tasks;

namespace MyStoreAdminDashboard.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IAuthService authenticationService;

        public AuthenticationController(IAuthService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        public IActionResult LogIn()
        {
            if (HttpContext.Session.TryGetValue("Token", out byte[] value))
            {
                return RedirectToAction("ManageUsers", "User");
            }

            AuthUserModel model = new AuthUserModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(AuthUserModel user)
        {
            if (ModelState.IsValid)
            {
                var response = await authenticationService.LogInAsync(user);

                if (!string.IsNullOrWhiteSpace(response.Token))
                {
                    HttpContext.Session.Set("Token", Encoding.ASCII.GetBytes("Bearer " + response.Token));

                    return RedirectToAction("ManageUsers", "User");
                }

                ModelState.AddModelError(string.Empty, "You are not authenticated");
                return View(user);
            }

            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            try
            {
                await authenticationService.LogOut();

                HttpContext.Session.Clear();
                return RedirectToAction(nameof(LogIn));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}