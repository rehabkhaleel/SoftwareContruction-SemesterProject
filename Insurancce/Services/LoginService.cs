using System.Linq;
using InsuranceManagementSystem.Models;

public class LoginService
{
    private readonly ApplicationDbContext _context;

    public LoginService(ApplicationDbContext context)
    {
        _context = context;
    }

    public bool Authenticate(string username, string password, string role)
    {
        if (role == "User")
        {
            var user = _context.UserDetails.SingleOrDefault(u => u.username == username && u.password == password);
            return user != null;
        }
        else if (role == "Agent")
        {
            var agent = _context.AgentDetails.SingleOrDefault(a => a.Agent_name == username && a.password == password);
            return agent != null;
        }
        else if (role == "Admin")
        {
            var admin = _context.AdminDetails.SingleOrDefault(a => a.username == username && a.password == password);
            return admin != null;
        }
        return false;
    }
}
