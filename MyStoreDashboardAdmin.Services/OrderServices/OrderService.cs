using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using MyStoreAdminDashboard.Services;
using Newtonsoft.Json;

namespace MyStoreAdminDashboard.Services
{
    public class OrderService : IOrderService
    {
        public async Task<List<OrderDto>> GetAllAsync(string token)
        {
            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Add("Authorization", token);

            HttpResponseMessage httpResponse = await httpClient.GetAsync("https://localhost:44319/api/Orders/GetAll");

            List<OrderDto> orders = new List<OrderDto>();
            if (httpResponse.IsSuccessStatusCode)
            {
                string response = await httpResponse.Content.ReadAsStringAsync();
                orders = JsonConvert.DeserializeObject<List<OrderDto>>(response);
            }

            return orders;
        }

        public async Task<OrderDto> GetById(int id, string token)
        {
            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Add("Authorization", token);

            HttpResponseMessage httpResponse = await httpClient.GetAsync($"https://localhost:44319/api/Orders/GetById?id={id}");

            OrderDto order = new OrderDto();

            if (httpResponse.IsSuccessStatusCode)
            {
                string response = await httpResponse.Content.ReadAsStringAsync();
                order = JsonConvert.DeserializeObject<OrderDto>(response);
            }
            return order;
        }
        
        public async Task<bool> Update(OrderDto order, string token)
        {
            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Add("Authorization", token);

            HttpResponseMessage httpResponse = await httpClient.PutAsJsonAsync($"https://localhost:44319/api/Orders/Update", order);

            if (httpResponse.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}