using KomodoClaims;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeTests
{
    [TestClass]
    public class KomodoClaimsRepositoryTests
    {
        private ClaimRepository _claimRepository;
        Claim claim1;
        Claim claim2;
        Claim claim3;
        [TestInitialize]
        public void Arrange()
        {
            _claimRepository = new ClaimRepository();
            claim1 = new Claim(1, ClaimType.Theft, "Stolen pancake.", 24.00, new DateTime(2021, 7, 4), new DateTime(2021, 8, 2));
            claim2 = new Claim(2, ClaimType.Car, "Car accident on 465.", 3275.00, new DateTime(2021, 7, 8), new DateTime(2021, 8, 4));
            claim3 = new Claim(3, ClaimType.Home, "House fire in kitchen.", 5500.00, new DateTime(2021, 7, 9), new DateTime(2021, 8, 9));
            _claimRepository.AddClaimToRepository(claim1);
            _claimRepository.AddClaimToRepository(claim2);
            _claimRepository.AddClaimToRepository(claim3);
        }
        [TestMethod]
        public void ClaimPropertiesTest()
        {
            //Arrange
            Claim claim = new Claim();
            //Act
            claim.ClaimID = 738;
            claim.ClaimType = ClaimType.Theft;
            claim.Description = "Stolen pancake.";
            claim.ClaimAmount = 28.01;
            claim.DateOfIncident = new DateTime(2021, 7, 28);
            claim.DateOfClaim = new DateTime(2021, 8, 20);
            //Assert
            Assert.AreEqual(738, claim.ClaimID);
            Assert.AreEqual(ClaimType.Theft, claim.ClaimType);
            Assert.AreEqual("Stolen pancake.", claim.Description);
            Assert.AreEqual(28.01, claim.ClaimAmount);
            Assert.AreEqual(new DateTime(2021, 7, 28), claim.DateOfIncident);
            Assert.AreEqual(new DateTime(2021, 8, 20), claim.DateOfClaim);
            //claim is within 30 days, so it is valid
            Assert.AreEqual(true, claim.IsValid);
            //updating the date of the claim to 30 or more days, this should return false
            claim.DateOfClaim = new DateTime(2021, 8, 29);
            Assert.AreEqual(false, claim.IsValid);
        }
        [TestMethod]
        public void AddClaimToRepository_AndDoesItemExist()
        {
            //Arrange
            //Act
            bool addedClaim1 = _claimRepository.AddClaimToRepository(claim1);
            bool addedClaim2 = _claimRepository.AddClaimToRepository(claim2);
            bool addedClaim3 = _claimRepository.AddClaimToRepository(claim3);
            //Assert
            Assert.AreEqual(true, addedClaim1);
            Assert.AreEqual(true, addedClaim2);
            Assert.AreEqual(true, addedClaim3);
        }
        [TestMethod]
        public void GetClaimRepositoryReturns_AndGetClaimByClaimIDReturns()
        {
            //Arrange
            List<Claim> newList;
            newList = _claimRepository.GetClaimRepository();
            claim1 = new Claim(73, ClaimType.Theft, "Stolen pancake.", 24.00, new DateTime(2021, 7, 4), new DateTime(2021, 8, 2));
            //Act
            //Assert
            Assert.IsNotNull(newList);
            Assert.AreEqual(null, _claimRepository.GetClaimByClaimNumber(73));
            Assert.IsTrue(_claimRepository.AddClaimToRepository(claim1));
            Assert.AreEqual(claim1, _claimRepository.GetClaimByClaimNumber(73));
        }
        [TestMethod]
        public void UpdateClaimUpdatesClaim()
        {
            //Arrange
            Arrange();
            Claim newClaim = new Claim(9, ClaimType.Theft, "Stolen headphones.", 45.00, new DateTime(2021, 7, 4), new DateTime(2021, 8, 2));
            //Act
            _claimRepository.UpdateClaimByID(1, newClaim);
            //Assert
            Assert.AreEqual( false, _claimRepository.DoesItemExist(1));
            Assert.AreEqual( true, _claimRepository.DoesItemExist(9));
        }
        [TestMethod]
        public void RemoveClaimByIDReturnsCorrectly()
        {
            //Arrange
            Arrange();
            //Act
            Assert.IsTrue(_claimRepository.DoesItemExist(3));
            _claimRepository.RemoveClaimByID(3);
            //Assert
            Assert.IsFalse(_claimRepository.DoesItemExist(3));
        }
    }
}
