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

    }
    
}
