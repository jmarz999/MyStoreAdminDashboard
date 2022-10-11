using System;
using System.Collections.Generic;

namespace MyStoreAdminDashboard.Services
{
    public class CreateUserDto
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public List<string> GenderValues { get; set; }
    }
}
