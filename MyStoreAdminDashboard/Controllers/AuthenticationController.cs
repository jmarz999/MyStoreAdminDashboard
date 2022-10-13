using Microsoft.AspNetCore.Mvc;
using MyStoreAdminDashboard.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
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
                    
                    var token = new JwtSecurityTokenHandler().ReadJwtToken(response.Token);

                    var identity = new ClaimsPrincipal(new ClaimsIdentity(token.Claims));

                    return RedirectToAction("ManageUsers", "User");
                }

                ModelState.AddModelError(string.Empty, "You are not authenticated");
                return View(user);
            }

            return View(user);
        }

        public async Task<IActionResult> LogOut()
        {
            await authenticationService.LogOut();
            return RedirectToAction(nameof(LogIn));
        }
    }
}