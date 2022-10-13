using System.Threading.Tasks;

namespace MyStoreAdminDashboard.Services
{
    public interface IAuthService
    {
        Task<AuthenticateResponse> LogInAsync(AuthUserModel user);
        Task LogOut();
    }
}
