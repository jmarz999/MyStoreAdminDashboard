using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyStoreAdminDashboard.Services
{
    public class UserAppService : IUserAppService
    {
        public async Task<List<UserDto>> GetAllAsync(string token)
        {
            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Add("Authorization", token);

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

        public async Task<string> CreateAsync(CreateUserDto user)
        {
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage httpResponse = await httpClient.PostAsJsonAsync<CreateUserDto>("https://localhost:44319/api/Users/CreateUser", user);

            if (httpResponse.IsSuccessStatusCode)
            {
                return string.Empty;
            }
            else
            {
                var obj = new { Message = "" };
                var response = await httpResponse.Content.ReadAsStringAsync();
                obj = JsonConvert.DeserializeAnonymousType(response, obj);
                return obj.Message;
            }
        }

        public async Task<string> UpdateAsync(UserDto user)
        {
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage httpResponse = await httpClient.PutAsJsonAsync("https://localhost:44319/api/Users/UpdateUser", user);

            if (httpResponse.IsSuccessStatusCode)
            {

                return string.Empty;
            }
            else
            {
                var obj = new { Message = "" };
                var response = await httpResponse.Content.ReadAsStringAsync();
                obj = JsonConvert.DeserializeAnonymousType(response, obj);
                return obj.Message;
            }
        }

        public async Task DeleteAsync(string id)
        {
            try
            {
                HttpClient httpClient = new HttpClient();

                HttpResponseMessage httpResponse = await httpClient.DeleteAsync($"https://localhost:44319/api/Users/DeleteUser?id={id}");

                if (httpResponse.IsSuccessStatusCode)
                {
                    
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
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