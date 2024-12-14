using Microsoft.AspNetCore.Identity;
using System;

namespace InsuranceManagementSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Additional properties specific to your application
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }

        // You can include other properties as needed

        // Constructors, additional methods, or behavior specific to your application
    }
}
