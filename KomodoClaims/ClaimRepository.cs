using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims
{
    public class ClaimRepository
    {
        //field
        private readonly Queue<Claim> _claimRepo = new Queue<Claim>();
        //CRUD
        //Create
        public bool AddClaimToRepository(Claim claim)
        {
            if (claim != null)
            {
            _claimRepo.Enqueue(claim);
                return true;
            }
            return false;
        }
        //Read
        public Queue<Claim> GetClaimRepository()
        {
            return _claimRepo;
        }
        public Claim GetClaimByClaimNumber(int id)
        {
            foreach (Claim claim in _claimRepo)
            {
                if (claim.ClaimID == id)
                    return claim;
            }
            Console.WriteLine("\nThere was no claim with that number.");
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
        public Claim PeekNextClaim()
        {
            return _claimRepo.Peek();
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
        public void RemoveNextClaim()
        {
            _claimRepo.Dequeue();
        }
    }
}
