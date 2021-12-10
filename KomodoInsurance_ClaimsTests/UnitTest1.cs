using KomodoInsurance;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KomodoInsurance_ClaimsTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestClass]
        public class ClaimRepoTests
        {
            [TestMethod]
            public void AddClaim_ShouldGetCorrectBool() //Create
            {
                //Arrange
                ClaimClass claim = new ClaimClass();
                ClaimRepo repo = new ClaimRepo();

                //Act
                bool addClaim = repo.CreateNewClaim(claim);

                //Assert
                Assert.IsTrue(addClaim);
            }

            [TestMethod]
            public void GetClaims_ShouldReturnCorrectCollection() //Read
            {
                //Arrange
                ClaimClass claim = new ClaimClass();
                ClaimRepo repo = new ClaimRepo();
                repo.CreateNewClaim(claim);

                //Act
                Queue<ClaimClass> claims = repo.SeeAllClaims();
                bool hasClaim = claims.Contains(claim);

                //Assert
                Assert.IsTrue(hasClaim);
            }

            [TestMethod]
            public void PeekClaim_ShouldReturnNextClaim() //Read
            {
                //Arrange
                ClaimClass claim = new ClaimClass();
                ClaimRepo repo = new ClaimRepo();
                repo.CreateNewClaim(claim);

                //Act
                ClaimClass nextClaim = repo.PeekClaim();

                //Assert
                Assert.AreEqual(nextClaim, claim);

            }

            //Delete
            [TestMethod]
            public void DequeueClaim_ShouldReturnTrue()
            {
                //Arrange
                ClaimClass claim = new ClaimClass();
                ClaimRepo repo = new ClaimRepo();
                repo.CreateNewClaim(claim);

                //Act
                bool dequeuedClaim = repo.DequeueClaim();

                //Assert
                Assert.IsTrue(dequeuedClaim);

            }
        }
    }
}
