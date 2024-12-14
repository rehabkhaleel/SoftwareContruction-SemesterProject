using Microsoft.EntityFrameworkCore;

namespace InsuranceManagementSystem.Models
{
    public class ApplicationDbContext : DbContext
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<PolicyModel> Policies { get; set; }
        public DbSet<UserdetailsModel> UserDetails { get; set; }
        public DbSet<AdminDetailModel> AdminDetails { get; set; }
        public DbSet<AgentDetailsModel> AgentDetails { get; set; }
        public DbSet<Policy> PolicyList { get; set; }
    }
}
