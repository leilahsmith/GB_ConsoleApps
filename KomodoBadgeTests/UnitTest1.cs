using KomodoBadges;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KomodoBadgeTests
{
    [TestClass]
    public class Badge_RepoTests
    {
        [TestMethod]
        public void AddToRepo_ShouldGetCorrectBool()//Create
        {
            //Arrange
            BadgeListPoco badge = new BadgeListPoco(01);
            BadgeRepo repo = new BadgeRepo();

            //Act
            bool addResult = repo.AddBadgeToList(badge);

            //Assert
            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void GetBadges_ShouldReturnCorrectCollection() //Read
        {

           
            //Arrange
            BadgeListPoco badge = new BadgeListPoco(01);
            BadgeRepo repo = new BadgeRepo();
            repo.AddBadgeToList(badge);

            //Act
            Dictionary<int, List<string>> badges = repo.ViewExistingBadges();
            bool hasBadges = badges.ContainsKey(badge.BadgeID);

            //Assert
            Assert.IsTrue(hasBadges);

        }

        [TestMethod]
        public void GetBadgeByID_ShouldReturnCorrectBadge() //Read
        {
            //Arrange
            //Arrange
            BadgeListPoco badge = new BadgeListPoco(001, new List<string> { "A1", "A2" });
            BadgeRepo repo = new BadgeRepo();
            
            
            repo.AddBadgeToList(badge);
            int badgeID = 001;
            //Act
            BadgeListPoco searchResult = repo.GetABadgeByID(badgeID);

            //Assert
            Assert.AreEqual(searchResult.BadgeID, badgeID);
        }

        [TestMethod]
        public void UpdateExistingBadge_ShouldReturnTrue() //Update
        {
            //Arrange

            BadgeListPoco oldBadge = new BadgeListPoco(001, new List<string> { "A1", "A2" });
            BadgeListPoco newBadge = new BadgeListPoco(001, new List<string> { "A2", "A3", "B5" });
            BadgeRepo repo = new BadgeRepo();
            repo.AddBadgeToList(oldBadge);

            //Act
            bool updateResult = repo.UpdateExistingBadge(oldBadge.BadgeID, newBadge);

            //Assert
            Assert.IsTrue(updateResult);
        }

        [TestMethod]
        public void DeleteBadge_ShouldReturnTrue() //Delete
        {
            //Arrange
            BadgeListPoco badge = new BadgeListPoco(001, new List<string> { "A1", "A2" });
            BadgeRepo repo = new BadgeRepo();
            repo.AddBadgeToList(badge);
            int badgeID = 001;
            //Act
            BadgeListPoco oldBadge = repo.GetABadgeByID(badgeID);
            bool removeResult = repo.DeleteExistingAccessOnBadges(oldBadge);

            //Assert
            Assert.IsTrue(removeResult);
        }
    }
}
