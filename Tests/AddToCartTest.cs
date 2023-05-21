using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.Tests
{
    public class AddToCartTest : BaseTest
    {
        [Test]
        public void AddToCartFromHomePage()
        {
            Pages.HomePage.AddToCart();

            //Assert
            int brojArtikla = Pages.ShoppingCartPage.CountItemsInCart();
            Assert.Greater(brojArtikla, TestData.TestData.AddToCart.numberOfItems);
        }

        [Test]
        public void AddToCartFromDescription()
        {
            Pages.HomePage.ClickOnItemLink();
            Pages.ProductPage.ClickOnAddToCartItem();

            //Assert

            int brojArtikla = Pages.ShoppingCartPage.CountItemsInCart();
            Assert.Greater(brojArtikla, TestData.TestData.AddToCart.numberOfItems);

        }
    }
}
