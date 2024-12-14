using System.ComponentModel.DataAnnotations;

namespace InsuranceManagementSystem.Models
{
    
        public class PolicyModel
        {
           
            public int id { get; set; }
        [Required]
            public int PolicyId { get; set; }
            public int user_id { get; set; }
            public DateTime date_registered { get; set; }
        [Required]
            public string policy_name { get; set; }
        [Required]
            public string policy_status { get; set; }

        }
    
}
