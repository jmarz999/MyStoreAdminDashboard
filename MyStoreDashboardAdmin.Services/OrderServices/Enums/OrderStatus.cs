using System.ComponentModel.DataAnnotations;

namespace MyStoreAdminDashboard.Services.ProductService.Enums
{
    public enum OrderStatus
    {
        [Display(Name = "Pending")]
        Pending,
        [Display(Name = "InProcess")]
        InProcess,
        [Display(Name = "Done")]
        Done
    }
}