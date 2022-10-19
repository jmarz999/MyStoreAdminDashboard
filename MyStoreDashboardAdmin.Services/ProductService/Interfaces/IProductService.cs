using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyStoreAdminDashboard.Services
{
    public interface IProductService
    {
        Task<bool> Create(CreateProductDto product, string token);
        Task<List<ProductDto>> GetAllAsync();
        Task<ProductDto> GetById(int id);
        Task<bool> Update(ProductDto product, string token);
        Task Delete(int id, string token);
    }
}