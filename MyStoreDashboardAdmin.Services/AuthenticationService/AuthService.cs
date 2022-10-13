using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyStoreAdminDashboard.Services
{
    public class AuthService : IAuthService
    {
        public async Task<AuthenticateResponse> LogInAsync(AuthUserModel user)
        {
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("https://localhost:44319/api/Authentication/LogIn", user);

            var response = new AuthenticateResponse();

            if (responseMessage.IsSuccessStatusCode)
            {
                string content = await responseMessage.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<AuthenticateResponse>(content);
            }

            return response;
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