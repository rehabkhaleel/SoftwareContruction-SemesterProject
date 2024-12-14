using System.ComponentModel.DataAnnotations;
namespace InsuranceManagementSystem.Models
{
    public class AgentDetailsModel
    {
        [Required]
        public int id {  get; set; }
        public int agent_id { get; set; }
        public string password { get; set; }
        public string Agent_name { get; set; }
        public string Agent_contact {  get; set; }
    }
}