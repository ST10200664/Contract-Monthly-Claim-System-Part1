// Models/Claim.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace Contract_Monthly_Claim_System.Models
{
    public class Claim
    {
        [Key]
        public int ClaimID { get; set; }

        [Required]
        public string LecturerName { get; set; }

        [Required]
        [Range(0, Double.MaxValue)]
        public double ClaimAmount { get; set; }

        [Required]
        public string SupportingDocument { get; set; }

        public string Status { get; set; } = "Pending";

        public string Remarks { get; set; }
    }
}
