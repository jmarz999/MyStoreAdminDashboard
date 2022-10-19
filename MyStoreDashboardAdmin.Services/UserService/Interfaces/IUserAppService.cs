using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyStoreAdminDashboard.Services
{
    public interface IUserAppService
    {
        Task<List<UserDto>> GetAllAsync(string token);
        Task<UserDto> GetByIdAsync(string id, string token);
        Task<string> CreateAsync(CreateUserDto user, string token);
        Task<string> UpdateAsync(UserDto user, string token);
        Task DeleteAsync(string id, string token);
        Task<List<string>> GetGenderValues(string token);
    }
}