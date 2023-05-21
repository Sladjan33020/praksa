using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.Tests
{
    public class LoginTest : BaseTest
    {
        [Test]
        public void Login()
        {
            Pages.HomePage.ClickOnLoginOrRegisterLink();

            Pages.LoginOrRegisterPage.Login(
                TestData.TestData.Login.loginName,
                TestData.TestData.Login.password
                );

            //Assert 
            string welcomeBackText = Pages.MyAccountPage.GetLoggedInText();

            Assert.AreEqual($"{AppConstants.Constants.GenericMessages.welcomeText} {TestData.TestData.Login.firstName}" , welcomeBackText);
        }
    }
}
