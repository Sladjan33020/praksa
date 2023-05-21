using AutomationFramework.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.Tests
{
    public class PurchaseItemTest : BaseTest
    {
        [SetUp]
        public void Setup()
        {

            Pages.HomePage.ClickOnLoginOrRegisterLink();
            Pages.LoginOrRegisterPage.ClickOnRegisterContinueButton();

            string username = CommonMethods.GenerateRandomUsername("MilanStankovic");
            string email = username + "@gmail.com";


            Pages.CreateAccountPage.RegisterUser(
                TestData.TestData.Register.firstName,
                TestData.TestData.Register.lastName,
                email,
                TestData.TestData.Register.telephone,
                TestData.TestData.Register.fax,
                TestData.TestData.Register.company,
                TestData.TestData.Register.address1,
                TestData.TestData.Register.address2,
                TestData.TestData.Register.city,
                TestData.TestData.Register.zip,
                username,
                TestData.TestData.Register.password
                );
            Pages.MyAccountPage.ClickOnHomeButton();

            Pages.HomePage.AddToCart();
        }

        [Test]
        public void PurchaseItemEUR()
        {
            Pages.ShoppingCartPage.Checkout(TestData.TestData.Currency.eur);

            //Assert
            string price = Pages.CheckoutConfirmPage.GetTotalPrice();
            Assert.AreEqual(AppConstants.Constants.PriceForProductSkinsheenBronzerStick.eur , price);

            Pages.CheckoutConfirmPage.ClickOnCheckoutButton();
            string message = Pages.CheckoutSuccessPage.GetOrderSuccessMessage();
            Assert.AreEqual(AppConstants.Constants.GenericMessages.orderSuccessMessage, message);
        }

        [Test]
        public void PurchaseItemUSD()
        {
            Pages.ShoppingCartPage.Checkout(TestData.TestData.Currency.usd);

            //Assert
            string price = Pages.CheckoutConfirmPage.GetTotalPrice();
            Assert.AreEqual(AppConstants.Constants.PriceForProductSkinsheenBronzerStick.usd, price);


            Pages.CheckoutConfirmPage.ClickOnCheckoutButton();
            string message = Pages.CheckoutSuccessPage.GetOrderSuccessMessage();
            Assert.AreEqual(AppConstants.Constants.GenericMessages.orderSuccessMessage, message);
        }

        [Test]
        public void PurchaseItemPOUND()
        {
            Pages.ShoppingCartPage.Checkout(TestData.TestData.Currency.pound);

            //Assert
            string price = Pages.CheckoutConfirmPage.GetTotalPrice();
            Assert.AreEqual(AppConstants.Constants.PriceForProductSkinsheenBronzerStick.pound, price);


            Pages.CheckoutConfirmPage.ClickOnCheckoutButton();
            string message = Pages.CheckoutSuccessPage.GetOrderSuccessMessage();
            Assert.AreEqual(AppConstants.Constants.GenericMessages.orderSuccessMessage, message);
        }
    }
}
