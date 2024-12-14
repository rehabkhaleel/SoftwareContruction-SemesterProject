using System.ComponentModel.DataAnnotations;

namespace InsuranceManagementSystem.Models
{
    public class Policy
    {
        [Required]
        public int Id { get; set; }
        //public string Name { get; set; }
        public string PolicyName { get; set; }
  
        public string PolicyStatus { get; set; }
    }
}
