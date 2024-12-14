using System.ComponentModel.DataAnnotations;

namespace InsuranceManagementSystem.Models
{
    public class AdminDetailModel
    {
        [Required]
        public int Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }

    }
}
