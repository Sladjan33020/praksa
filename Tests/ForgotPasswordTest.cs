using AutomationFramework.Utils;
using NUnit.Framework;

namespace AutomationFramework.Tests
{
    public class ForgotPasswordTest : BaseTest
    {

        [SetUp]
        public void SetUp()
        {
            Pages.HomePage.ClickOnLoginOrRegisterLink();
            Pages.LoginOrRegisterPage.ClickOnRegisterContinueButton();

            TestData.TestData.Register.username = CommonMethods.GenerateRandomUsername("MilanStankovic");
            TestData.TestData.Register.email = TestData.TestData.Register.username + "@gmail.com";


            Pages.CreateAccountPage.RegisterUser(
                TestData.TestData.Register.firstName,
                TestData.TestData.Register.lastName,
                TestData.TestData.Register.email,
                TestData.TestData.Register.telephone,
                TestData.TestData.Register.fax,
                TestData.TestData.Register.company,
                TestData.TestData.Register.address1,
                TestData.TestData.Register.address2,
                TestData.TestData.Register.city,
                TestData.TestData.Register.zip,
                TestData.TestData.Register.username,
                TestData.TestData.Register.password
                );

            Pages.MyAccountPage.LogOut();
        }

        [Test]
        public void ForgorPassword()
        {
            Pages.HomePage.ClickOnLoginOrRegisterLink();
            Pages.LoginOrRegisterPage.ClickForgotPasswordLink();

            Pages.ForgotPasswordPage.ForgotPasswordAction(
                TestData.TestData.Register.username,
                TestData.TestData.Register.email
                );


            //Assert
            string successMessage = Pages.ForgotPasswordPage.GetSuccessMessage();
            Assert.AreEqual(AppConstants.Constants.GenericMessages.passwrodResetSuccessMessage, successMessage);
        }

    }
}
