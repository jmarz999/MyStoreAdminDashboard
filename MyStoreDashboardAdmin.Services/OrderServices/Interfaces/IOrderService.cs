using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyStoreAdminDashboard.Services
{
    public interface IOrderService
    {
        Task<List<OrderDto>> GetAllAsync(string token);
        Task<OrderDto> GetById(int id, string token);
        Task<bool> Update(OrderDto order, string token);
    }
}