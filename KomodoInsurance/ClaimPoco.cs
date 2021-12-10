using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance
{
    public class ClaimClass
    {
        //POCO
        private bool isValid;

        //Empty Constructor
        public ClaimClass() { }

        public ClaimClass(int claimId)
        {
            ClaimId = claimId;
        }

        //Full Constructor
        public ClaimClass(int claimId, string claimType, string description, double claimAmt, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid)
        {
            ClaimId = claimId;
            ClaimType = claimType;
            Description = description;
            ClaimAmt = claimAmt;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            this.isValid = isValid;
        }

        public int ClaimId { get; set; }
        public string ClaimType { get; set; }
        public string Description { get; set; }
        public double ClaimAmt { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }

    }
}

