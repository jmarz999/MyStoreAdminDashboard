using System.Threading.Tasks;

namespace MyStoreAdminDashboard.Services
{
    public interface IAuthService
    {
        Task<bool> LogInAsync(AuthUserModel user);
        Task LogOut();
    }
}
