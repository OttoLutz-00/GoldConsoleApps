
using KomodoInsuranceBadges2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeTests
{
    [TestClass]
    public class KomodoInsuranceBadgesRepositoryTests
    {
        [TestMethod]
        public void BadgePropertyTests()
        {
            //Arrange
            Badge badge = new Badge();
            List<string> list = new List<string> { "A1", "A2", "B1", "B2" };
            //Act
            badge.BadgeID = 123;
            badge.AccessibleDoors = list;
            //Assert
            Assert.AreEqual(123, badge.BadgeID);
            Assert.AreEqual(list , badge.AccessibleDoors);
        }

        [TestMethod]
        public void AddBadge_AddsBadge()
        {
            //Arrange
            BadgeRepository badgeRepository = new BadgeRepository();
            Badge badge = new Badge(123, new List<string> { "A1", "A2", "B1", "B2" });
            Assert.IsFalse(badgeRepository.GetAllBadges().ContainsKey(123));
            //Act
            badgeRepository.AddBadge(badge);
            //Assert
            Assert.IsTrue(badgeRepository.GetAllBadges().ContainsKey(123));
        }

        [TestMethod]
        public void GetAllBadges_ReturnsBadges()
        {
            //Arrange
            BadgeRepository badgeRepository = new BadgeRepository();
            Badge badge = new Badge(123, new List<string> { "A1", "A2", "B1", "B2" });
            //Act
            badgeRepository.AddBadge(badge);
            //Assert
            Assert.IsNotNull(badgeRepository.GetAllBadges());
        }

        [TestMethod]
        public void UpdateBadge_UpdatesBadgeDoor()
        {
            //Arrange
            BadgeRepository badgeRepository = new BadgeRepository();
            Badge badge = new Badge(123, new List<string> { "A1", "A2", "B1", "B2" });
            badgeRepository.AddBadge(badge);
            //Act
            badgeRepository.UpdateBadge(123, "C1");
            //Assert
            Assert.IsTrue(badgeRepository.GetAllBadges()[123].Contains("C1"));
            Assert.IsFalse(badgeRepository.GetAllBadges()[123].Contains("D9"));
        }

        [TestMethod]
        public void DeleteBadge_DeletesBadgeDoor()
        {
            //Arrange
            BadgeRepository badgeRepository = new BadgeRepository();
            Badge badge = new Badge(123, new List<string> { "A1", "A2", "B1", "B2" });
            badgeRepository.AddBadge(badge);
            //Act
            Assert.IsTrue(badgeRepository.GetAllBadges()[123].Contains("A1"));
            badgeRepository.DeleteBadge(123, "A1");
            //Assert
            Assert.IsFalse(badgeRepository.GetAllBadges()[123].Contains("A1"));
        }
    }
}
