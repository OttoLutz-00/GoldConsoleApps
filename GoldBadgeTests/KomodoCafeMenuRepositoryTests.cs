using KomodoCafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GoldBadgeTests
{

    [TestClass]
    public class KomodoCafeMenuRepositoryTests
    {
        private MenuRepository _menuRepository;
        private MenuItem item1;
        private MenuItem item2;
        private MenuItem item3;

        [TestInitialize]
        public void Arrange()
        {
            //Arrange
            _menuRepository = new MenuRepository();
            item1 = new MenuItem(1, "Bread Loaf", "This is a fresh baked loaf of bread from our own dough.", "Flour, yeast, nuts, water, olive oil, and eggs.", 11.55);
            item2 = new MenuItem(22, "Chocolate Muffin", "A favorite among customers, fresh, fluffy muffin sprinkled with delicious chocolate chips.", "Komodo Cafe muffin mix, milk, butter, and mini chocolate chips.", 7.30);
            item3 = new MenuItem(33, "Komodo Coffee", "Home brewed columbian coffee", "water, coffe beans", 6.75);
            //Act
            _menuRepository.AddItemToMenu(item1);
            _menuRepository.AddItemToMenu(item2);
            _menuRepository.AddItemToMenu(item3);
        }
        [TestMethod]
        public void RemoveItemFromMenuTest()
        {
            //Arrange
            MenuItem newItem = new MenuItem(27, "The Twenty Seven Combo", "This is a famous dish only served here", "Fresh things, more things, more things, and things.", 54.32);
            //Act
            _menuRepository.AddItemToMenu(newItem);
            //Assert
            Assert.AreEqual( true , _menuRepository.DoesItemExist(27));
            _menuRepository.RemoveItemFromMenu(27);
            Assert.AreEqual( false , _menuRepository.DoesItemExist(27));
        }
        [TestMethod]
        public void GetMenuItemByItemNumber()
        {
            //Arrange
            MenuItem newItem = new MenuItem(27, "The Twenty Seven Combo", "This is a famous dish only served here", "Fresh things, more things, more things, and things.", 54.32);
            //Assert
            Assert.AreEqual(null,_menuRepository.GetMenuItemByItemNumber(27));
            //Act
            _menuRepository.AddItemToMenu(newItem);
            //Assert
            Assert.AreEqual(newItem, _menuRepository.GetMenuItemByItemNumber(27));
        }
        [TestMethod]
        public void MenuItemPropertyAssignmentTests()
        {
            //Arrange
            MenuItem item = new MenuItem();
            //Act
            item.ItemNumber = 33;
            item.ItemName = "This Is The Name Of The Item";
            item.ItemDescription = "This Is The Description.";
            item.ItemIngredients = "ingredient1, ingredient2, igredient101.";
            item.ItemPrice = 43.76;
            //Assert
            Assert.AreEqual( 33 , item.ItemNumber);
            Assert.AreEqual("This Is The Name Of The Item" , item.ItemName);
            Assert.AreEqual("This Is The Description.", item.ItemDescription);
            Assert.AreEqual(43.76 , item.ItemPrice);
            Assert.AreEqual("ingredient1, ingredient2, igredient101." , item.ItemIngredients);
        }
        [TestMethod]
        public void DoesItemExist()
        {
            //data has been Arranged and Acted on already
            //Assert
            Assert.IsTrue(_menuRepository.DoesItemExist(1));
            Assert.IsTrue(_menuRepository.DoesItemExist(22));
            Assert.IsTrue(_menuRepository.DoesItemExist(33));
            //these should not exist and return false
            Assert.IsFalse(_menuRepository.DoesItemExist(66));
            Assert.IsFalse(_menuRepository.DoesItemExist(12));
            Assert.IsFalse(_menuRepository.DoesItemExist(34));
        }
        [TestMethod]
        public void AddItemToMenu_AndItemExists()
        {
            //Arrange
            MenuItem newItem = new MenuItem(27, "The Twenty Seven Combo", "This is a famous dish only served here", "Fresh things, more things, more things, and things.", 54.32);
            //Assert
            Assert.IsFalse(_menuRepository.DoesItemExist(27));
            _menuRepository.AddItemToMenu(newItem);
            Assert.IsTrue(_menuRepository.DoesItemExist(27));
        }
    }
}
