using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyStoreAdminDashboard.Services
{
    public interface IUserAppService
    {
        Task<List<UserDto>> GetAllAsync();
        Task<UserDto> GetByIdAsync(string id);
        Task<bool> CreateAsync(CreateUserDto user);
        Task<bool> UpdateAsync(UserDto user);
        Task DeleteAsync(string id);
        Task<List<string>> GetGenderValues();
    }
}
