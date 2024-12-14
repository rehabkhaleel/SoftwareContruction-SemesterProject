using Microsoft.AspNetCore.Mvc;
using InsuranceManagementSystem.Models;
using System.Linq;

namespace InsuranceManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var users = _context.UserDetails.ToList();
            var agents = _context.AgentDetails.ToList();
            ViewBag.Users = users;
            ViewBag.Agents = agents;
            return View();
        }
    }
}
