using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyStoreAdminDashboard.Services
{
    public class AuthService : IAuthService
    {
        public async Task<bool> LogInAsync(AuthUserModel user)
        {
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("https://localhost:44319/api/Authentication/LogIn", user);

            if (responseMessage.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task LogOut()
        {
            try
            {
                HttpClient httpClient = new HttpClient();

                HttpResponseMessage responseMessage = await httpClient.GetAsync("https://localhost:44319/api/Authentication/LogOut");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
