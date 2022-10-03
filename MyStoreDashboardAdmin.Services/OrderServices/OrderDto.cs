using System.Collections.Generic;
using MyStoreAdminDashboard.Services.ProductService.Enums;

namespace MyStoreAdminDashboard.Services
{
    public class OrderDto
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}