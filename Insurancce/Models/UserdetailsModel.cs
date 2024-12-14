using System.ComponentModel.DataAnnotations;

namespace InsuranceManagementSystem.Models
{
    public class UserdetailsModel
    {
        [Required]
        public int id { get; set; }
        public int user_id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string phone_no { get; set; }
        public DateTime dob { get; set; }
        public string address { get; set; }

    }
}
