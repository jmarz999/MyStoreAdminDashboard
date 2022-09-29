using System.ComponentModel.DataAnnotations;

namespace MyStoreAdminDashboard.Services
{
    public class CreateProductDto
    {
        [Required]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Manufacturers { get; set; }
        [Required]
        public string Category { get; set; }
        public string Img { get; set; }
    }
}
