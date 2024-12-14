using Microsoft.AspNetCore.Mvc;
using InsuranceManagementSystem.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http; 

namespace InsuranceManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Register User
        [HttpGet]
        public IActionResult RegisterUser() => View();

        [HttpPost]
        public async Task<IActionResult> RegisterUser(UserdetailsModel model)
        {
            if (ModelState.IsValid)
            {
                _context.UserDetails.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Login");
            }
            return View(model);
        }

        // Register Agent
        [HttpGet]
        public IActionResult RegisterAgent() => View();

        [HttpPost]
        public async Task<IActionResult> RegisterAgent(AgentDetailsModel model)
        {
            if (ModelState.IsValid)
            {
                _context.AgentDetails.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Login");
            }
            return View(model);
        }

        // Login
        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(string username, string password, string role)
        {
            if (role == "Admin")
            {
                var admin = _context.AdminDetails.FirstOrDefault(a => a.username == username && a.password == password);
                if (admin != null)
                {
                    // Store the admin ID in session
                    HttpContext.Session.SetInt32("UserId", admin.Id);
                    return RedirectToAction("Index", "Admin");
                }
            }
            else if (role == "Agent")
            {
                var agent = _context.AgentDetails.FirstOrDefault(a => a.Agent_name == username && a.password == password);
                if (agent != null)
                {
                    // Store the agent ID in session
                    HttpContext.Session.SetInt32("UserId", agent.agent_id);
                    return RedirectToAction("Index", "Agent");
                }
            }
            else
            {
                var user = _context.UserDetails.FirstOrDefault(u => u.username == username && u.password == password);
                if (user != null)
                {
                    // Store the user ID in session
                    HttpContext.Session.SetInt32("UserId", user.user_id);
                    return RedirectToAction("Home", "User");
                }
            }

            ViewBag.Message = "Invalid credentials";
            return View();
        }

    }
}
