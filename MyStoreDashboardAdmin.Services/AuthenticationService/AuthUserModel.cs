using System.ComponentModel.DataAnnotations;

namespace MyStoreAdminDashboard.Services
{
    public class AuthUserModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}