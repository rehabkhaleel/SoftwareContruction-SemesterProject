using InsuranceManagementSystem.Interfaces;
using InsuranceManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceManagementSystem.Controllers
{
    public class PolicyController : Controller
    {
        private readonly IPolicyService _policyService;

        public PolicyController(IPolicyService policyService)
        {
            _policyService = policyService;
        }

        public IActionResult ApplyPolicy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ApplyPolicy(Policy policy)
        {
            _policyService.ApplyPolicy(policy);
            return View();
        }
    }
}
