using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyStoreAdminDashboard.Services
{
    public interface IUserAppService
    {
        Task<List<UserDto>> GetAllAsync(string token);
        Task<UserDto> GetByIdAsync(string id);
        Task<string> CreateAsync(CreateUserDto user);
        Task<string> UpdateAsync(UserDto user);
        Task DeleteAsync(string id);
        Task<List<string>> GetGenderValues();
    }
}
