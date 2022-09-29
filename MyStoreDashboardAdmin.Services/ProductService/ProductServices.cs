using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MyStoreAdminDashboard.Services
{
    public class ProductServices : IProductService
    {
        public async Task<bool> Create(CreateProductDto product)
        {
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage httpResponse = await httpClient.PostAsJsonAsync<CreateProductDto>("https://localhost:44319/api/Products/Add", product);

            if (httpResponse.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage httpResponse = await httpClient.GetAsync("https://localhost:44319/api/Products/GetAll");

            List<ProductDto> products = new List<ProductDto>();
            if (httpResponse.IsSuccessStatusCode)
            {
                string response = await httpResponse.Content.ReadAsStringAsync();
                products = JsonConvert.DeserializeObject<List<ProductDto>>(response);
            }

            return products;
        }

        public async Task<ProductDto> GetById(int id)
        {
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage httpResponse = await httpClient.GetAsync($"https://localhost:44319/api/Products/GetById?id={id}");

            ProductDto product = new ProductDto();

            if (httpResponse.IsSuccessStatusCode)
            {
                var response = await httpResponse.Content.ReadAsStringAsync();
                product = JsonConvert.DeserializeObject<ProductDto>(response);
            }

            return product;
        }

        public async Task<bool> Update(ProductDto product)
        {
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage httpResponse = await httpClient.PutAsJsonAsync<ProductDto>("https://localhost:44319/api/Products/Update", product);

            if (httpResponse.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task Delete(int id)
        {
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage httpResponse = await httpClient.DeleteAsync($"https://localhost:44319/api/Products/Delete?id={id}");
        }
    }
}
