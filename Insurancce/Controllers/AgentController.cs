using InsuranceManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

public class AgentController : Controller
{
    private readonly ApplicationDbContext _context;

    public AgentController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var pendingPolicies = _context.Policies.Where(p => p.policy_status == "Pending").ToList();
        var activePolicies = _context.Policies.Where(p => p.policy_status == "Active").ToList();

        ViewBag.PendingPolicies = pendingPolicies;
        ViewBag.ActivePolicies = activePolicies;

        return View();
    }
    [HttpGet]
    public IActionResult SignOut()
    {
        return View();
    }

    [HttpPost]
    public IActionResult ApprovePolicy(int policyId, string policyName, int userId)
    {
        var policy = _context.Policies.FirstOrDefault(p => p.PolicyId == policyId &&
                                                            p.policy_name == policyName &&
                                                            p.user_id == userId);
        if (policy != null)
        {
            policy.policy_status = "Active";
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }

}
