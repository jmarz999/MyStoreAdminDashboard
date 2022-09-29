using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyStoreAdminDashboard.Services
{
    public interface IProductService
    {
        Task<bool> Create(CreateProductDto product);
        Task<List<ProductDto>> GetAllAsync();
        Task<ProductDto> GetById(int id);
        Task<bool> Update(ProductDto product);
        Task Delete(int id);
    }
}
