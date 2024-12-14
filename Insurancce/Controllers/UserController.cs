using Microsoft.AspNetCore.Mvc;
using InsuranceManagementSystem.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace InsuranceManagementSystem.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Home() => View();

        [HttpGet]
        public IActionResult UserDetails(int userId)
        {
            var userDetails = _context.UserDetails.FirstOrDefault(u => u.user_id == userId);
            return View(userDetails);
        }

        [HttpGet]
        public IActionResult EditInfo()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var userDetails = _context.UserDetails.FirstOrDefault(u => u.user_id == userId);
            if (userDetails == null)
            {
                return NotFound();
            }

            return View(userDetails);
        }

        [HttpGet]
        public IActionResult CheckPolicyStatus()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var policies = _context.Policies.Where(p => p.user_id == userId).ToList();

            return View(policies);
        }


        [HttpPost]
        public async Task<IActionResult> EditInfo(UserdetailsModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var userId = HttpContext.Session.GetInt32("UserId");

                    var userDetails = _context.UserDetails.FirstOrDefault(u => u.user_id == userId);
                    if (userDetails == null)
                    {
                        return NotFound();
                    }

                    userDetails.name = model.name;
                    userDetails.username = model.username;
                    userDetails.password = model.password;
                    userDetails.phone_no = model.phone_no;
                    userDetails.dob = model.dob;
                    userDetails.address = model.address;

                    _context.UserDetails.Update(userDetails);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("UserDetails", new { userId = userId });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error updating user details: {ex.Message}");
                    return View(model);
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult ApplyPolicy()
        {
            var policies = _context.PolicyList.ToList();
            ViewBag.PolicyList = policies;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ApplyPolicy(PolicyModel model)
        {
            //if (true)
            //{
            try
            {
                var userId = HttpContext.Session.GetInt32("UserId");
                if (userId == null)
                {
                    ModelState.AddModelError("", "User is not logged in.");
                    ViewBag.PolicyList = _context.PolicyList.ToList();
                    return View(model);
                }

                var selectedPolicy = await _context.PolicyList.FindAsync(model.PolicyId);
                if (selectedPolicy == null)
                {
                    ModelState.AddModelError("", "Invalid policy selection.");
                    ViewBag.PolicyList = _context.PolicyList.ToList();
                    return View(model);
                }

                var policyModel = new PolicyModel
                {
                    user_id = userId.Value,
                    PolicyId = model.PolicyId,
                    date_registered = DateTime.Now,
                    policy_name = selectedPolicy.PolicyName,
                    policy_status = "Pending"
                };

                _context.Policies.Add(policyModel);
                await _context.SaveChangesAsync();

                ViewBag.Message = "Policy applied successfully!";
                return RedirectToAction("Home");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error applying for policy: {ex.Message}");
                ViewBag.PolicyList = _context.PolicyList.ToList();
                return View(model);
            }
            //}

            //// Log ModelState errors for debugging
            //var errors = ModelState.Values.SelectMany(v => v.Errors);
            //foreach (var error in errors)
            //{
            //    Console.WriteLine(error.ErrorMessage);
            //}

            //ViewBag.PolicyList = _context.PolicyList.ToList();
            //return View(model);
        }
        [HttpGet]
        public IActionResult SignOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }




    }
}
