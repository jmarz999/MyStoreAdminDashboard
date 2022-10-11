using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MyStoreAdminDashboard.Services
{
    public class UserAppService : IUserAppService
    {
        public async Task<List<UserDto>> GetAllAsync()
        {
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage httpResponse = await httpClient.GetAsync("https://localhost:44319/api/Users/GetAll");

            List<UserDto> users = new List<UserDto>();
            if (httpResponse.IsSuccessStatusCode)
            {
                string response = await httpResponse.Content.ReadAsStringAsync();
                users = JsonConvert.DeserializeObject<List<UserDto>>(response);
            }

            return users;
        }

        public async Task<UserDto> GetByIdAsync(string id)
        {
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage httpResponse = await httpClient.GetAsync($"https://localhost:44319/api/Users/GetById?id={id}");

            UserDto user = new UserDto();

            if (httpResponse.IsSuccessStatusCode)
            {
                var response = await httpResponse.Content.ReadAsStringAsync();
                user = JsonConvert.DeserializeObject<UserDto>(response);
            }

            return user;
        }

        public async Task<bool> CreateAsync(CreateUserDto user)
        {
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage httpResponse = await httpClient.PostAsJsonAsync<CreateUserDto>("https://localhost:44319/api/Users/CreateUser", user);

            if (httpResponse.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(UserDto user)
        {
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage httpResponse = await httpClient.PutAsJsonAsync<UserDto>("https://localhost:44319/api/Users/UpdateUser", user);

            if (httpResponse.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task DeleteAsync(string id)
        {
            HttpClient httpClient = new HttpClient();

            await httpClient.DeleteAsync($"https://localhost:44319/api/Users/Delete?id={id}");
        }

        public async Task<List<string>> GetGenderValues()
        {
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage httpResponse = await httpClient.GetAsync("https://localhost:44319/api/Users/GetGenderValues");

            List<string> gender = new List<string>();
            if (httpResponse.IsSuccessStatusCode)
            {
                string response = await httpResponse.Content.ReadAsStringAsync();
                gender = JsonConvert.DeserializeObject<List<string>>(response);
            }

            return gender;
        }
    }
}