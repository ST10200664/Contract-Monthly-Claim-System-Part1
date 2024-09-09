using Contract_Monthly_Claim_System.Models;
// Controllers/ClaimController.cs
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CMCS.Controllers
{
    public class ClaimController : Controller
    {
        // In-memory list of claims for demonstration purposes
        private static List<Claim> claims = new List<Claim>();

        // Display the claim submission form
        public IActionResult SubmitClaim()
        {
            return View();
        }

        // Handle the claim submission POST request
        [HttpPost]
        public IActionResult SubmitClaim(Claim claim)
        {
            if (ModelState.IsValid)
            {
                claim.ClaimID = claims.Count + 1;
                claims.Add(claim);
                TempData["SuccessMessage"] = "Claim submitted successfully!";
                return RedirectToAction("SubmitClaim");
            }
            return View(claim);
        }

        // View to show all claims for approval
        public IActionResult ApproveClaims()
        {
            return View(claims);
        }

        // Handle the approval or rejection of claims
        public IActionResult Approve(int id)
        {
            var claim = claims.FirstOrDefault(c => c.ClaimID == id);
            if (claim != null)
            {
                claim.Status = "Approved";
                TempData["SuccessMessage"] = $"Claim {id} approved!";
            }
            return RedirectToAction("ApproveClaims");
        }

        public IActionResult Reject(int id, string remarks)
        {
            var claim = claims.FirstOrDefault(c => c.ClaimID == id);
            if (claim != null)
            {
                claim.Status = "Rejected";
                claim.Remarks = remarks;
                TempData["SuccessMessage"] = $"Claim {id} rejected!";
            }
            return RedirectToAction("ApproveClaims");
        }

        // Claim Status tracking page
        public IActionResult TrackStatus(int id)
        {
            var claim = claims.FirstOrDefault(c => c.ClaimID == id);
            return View(claim);
        }
    }
}

