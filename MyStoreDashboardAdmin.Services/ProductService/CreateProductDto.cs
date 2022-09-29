using System;
using System.Collections.Generic;
using System.Text;

namespace MyStoreAdminDashboard.Services
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Manufacturers { get; set; }
        public string Category { get; set; }
        public string Img { get; set; }
    }
}
