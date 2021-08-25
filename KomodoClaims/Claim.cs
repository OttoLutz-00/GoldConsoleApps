using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims
{
    public enum ClaimType { NA, Car, Home, Theft};
    public class Claim
    {
        public int ClaimID { get; set; }
        public ClaimType ClaimType { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid
        {
            get
            {
                TimeSpan difference = DateOfClaim - DateOfIncident;
                if (difference.Days <= 30)
                {
                    return true;
                }
                return false;
            }
        }
        public Claim() { }
        public Claim(int claimID, ClaimType claimType, string description, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimID = claimID;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        }
        public override string ToString()
        {
            string incDate = $"{DateOfIncident.Month}/{DateOfIncident.Day}/{DateOfIncident.Year}";
            string clDate = $"{DateOfClaim.Month}/{DateOfClaim.Day}/{DateOfClaim.Year}";
            return String.Format(" | {0,-6} | {1,-10} | {2,-30} | ${3,-12} | {4,-13} | {5,-13} | {6,-7} |", ClaimID, ClaimType, Description, ClaimAmount, incDate, clDate, IsValid);
        }
    }
}
