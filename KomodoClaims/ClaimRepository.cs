using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims
{
    class ClaimRepository
    {
        //field
        private readonly List<Claim> _claimRepo = new List<Claim>();
        //CRUD
        //Create
        public void AddClaimToRepository(Claim claim)
        {
            _claimRepo.Add(claim);
        }
        //Read
        public List<Claim> GetClaimRepository()
        {
            return _claimRepo;
        }
        public Claim GetClaimByClaimNumber(int id)
        {
            foreach (Claim item in _claimRepo)
            {
                if (item.ClaimID == id)
                    return item;
            }
            Console.WriteLine("There was no claim with that number.");
            return null;
        }
        //same as function above but it will return just a bool instead of the actual claim.
        public bool DoesItemExist(int id)
        {
            foreach (Claim item in _claimRepo)
            {
                if (item.ClaimID == id)
                    return true;
            }
            return false;
        }
        //Update
        public bool UpdateClaimByID(int id, Claim newClaim)
        {
            Claim oldClaim = GetClaimByClaimNumber(id);
            if (oldClaim != null)
            {
                oldClaim.ClaimID = newClaim.ClaimID;
                oldClaim.ClaimType = newClaim.ClaimType;
                oldClaim.Description = newClaim.Description;
                oldClaim.ClaimAmount = newClaim.ClaimAmount;
                oldClaim.DateOfIncident = newClaim.DateOfIncident;
                oldClaim.DateOfClaim = newClaim.DateOfClaim;
                return true;
            }
            return false;
        }
        //Delete
        public bool RemoveItemFromMenu(int id)
        {
            if (_claimRepo.Remove(GetClaimByClaimNumber(id)))
                return true;
            return false;
        }
    }
}
