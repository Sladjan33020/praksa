using AutomationFramework.Utils;
using NUnit.Framework;

namespace AutomationFramework.Tests
{
    public class RegisterUserTest : BaseTest
    {
        [Test]
        public void RegisterUser()
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

            //Asertacija
            string welcomeText = Pages.MyAccountPage.GetLoggedInText();
            string accountRregisteredTExt = Pages.MyAccountPage.GetAccountRegistrationConfirm();

            Assert.AreEqual($"{AppConstants.Constants.GenericMessages.welcomeText} {TestData.TestData.Register.firstName}", welcomeText);
            Assert.AreEqual(AppConstants.Constants.GenericMessages.accountCreatedSuccesfully, accountRregisteredTExt);
        }
    }
}
