using AutomationFramework.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.Tests
{
    public class ForgotLoginTest : BaseTest
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
        public void ForgotLogin()
        {
            Pages.HomePage.ClickOnLoginOrRegisterLink();
            Pages.LoginOrRegisterPage.ClickForgotLoginLink();

            Pages.ForgotLoginPage.ForgotLoginName(TestData.TestData.Register.lastName, TestData.TestData.Register.email);

            //Assert
            string successMessage = Pages.ForgotLoginPage.GetSuccessMessage();
            Assert.AreEqual(AppConstants.Constants.GenericMessages.loginNameResetSuccessMessage , successMessage);
        }
    }
}
