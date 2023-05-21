using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.Tests
{
    public class RemoveItemFromCartTest : BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            Pages.HomePage.AddToCart();
        }

        [Test]
        public void RemoveItemFromCart()
        {
            Pages.ShoppingCartPage.ClickOnDeleteItem();

            //Asssert
            string emptyCartMessage = Pages.ShoppingCartPage.EmptyCartMessage();
            Assert.AreEqual(AppConstants.Constants.GenericMessages.emptyCartMessage, emptyCartMessage);
        }
    }
}
