using KomodoCafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KomodoCafeTests
{
    [TestClass]
    public class UnitTest1
    {
        //Should create an item on the cafe menu.
        [TestMethod]
        public void CreateMenuItem_WithName_ShouldCreateItem()
        {

            //Arrange
            KC_Poco items = new KC_Poco();
            KC_Repo menu = new KC_Repo();

            //Act
            bool addResult = menu.AddItemsToMenu(items);

            //Assert
            Assert.IsTrue(addResult);

        }
      
        //Read
        [TestMethod]
        public void GetMenu_ShouldReturnCorrectCollection()//Read
        {
            //Arrange
            KC_Poco items = new KC_Poco();
            KC_Repo menu = new KC_Repo();
            menu.AddItemsToMenu(items);
            //Act
            List<KC_Poco> menuItems = menu.GetCafeItems();
            bool menuHasItems = menuItems.Contains(items);

            //Assert
            Assert.IsTrue(menuHasItems);
        }

        //Get Cafe items by number
        [TestMethod]
        public void GetMenuByMealNumber_ShouldReturnCorrectMenuItem()//Read
        {
            //Arrange
            KC_Repo menu = new KC_Repo();
            KC_Poco item = new KC_Poco("Cafe Americano", 1, "Rich espresso with artisan water heated perfectly for a delcious and bold flavor", "Espresso & water", 3.99);
            menu.AddItemsToMenu(item);
            int mealNumber = 01;
            //Act
            KC_Poco searchResult = menu.GetCafeItemsByItemNumber(mealNumber);

            //Assert
            Assert.AreEqual(searchResult.Number, mealNumber);

        }
        [TestMethod]
        public void UpdateExistingCafeItem_ShouldReturnTrue() //Update
        {
            //Arrange
            KC_Repo menu = new KC_Repo();
            KC_Poco oldItem = new KC_Poco("Cafe Americano", 1, "Rich espresso with artisan water heated perfectly for a delcious and bold flavor", "Espresso & water", 3.99);
            
            menu.AddItemsToMenu(oldItem);
            KC_Poco newItem = new KC_Poco("Cafe Mocha", 2, "Iced or hot mocha latte", "Chocolate, espresso, milk, whipped cream, drizzle", 4.99);
            //Act
            bool updateResult = menu.UpdateExistingCafeItem(oldItem.Number, newItem);

            //Assert
            Assert.IsTrue(updateResult);
        }

        [TestMethod]
        public void RemoveItemFromList_ShouldReturnTrue() //Delete
        {
            //Arrange
            KC_Repo menu = new KC_Repo();
            KC_Poco item = new KC_Poco("Cafe Americano", 1, "Rich espresso with artisan water heated perfectly for a delcious and bold flavor", "Espresso & water", 3.99);
            menu.AddItemsToMenu(item);
            int mealNumber = 1;

            //Act
            KC_Poco oldItem = menu.GetCafeItemsByItemNumber(mealNumber);
            bool removeResult = menu.RemoveItemFromList(oldItem);

            //Assert
            Assert.IsTrue(removeResult);

        }
    }
}

