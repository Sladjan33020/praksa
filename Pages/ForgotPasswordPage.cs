using AutomationFramework.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.Pages
{
    public class ForgotPasswordPage : BasePage
    {
        /// <summary>
        /// KOnstruktor bez parametara
        /// </summary>
        public ForgotPasswordPage()
        {
            driver = null;
        }

        /// <summary>
        /// Konstruktor sa parametrima
        /// </summary>
        /// <param name="webDriver">web driver</param>
        public ForgotPasswordPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        //Locators
        By loginNameField = By.Id("forgottenFrm_loginname");
        By emailField = By.Id("forgottenFrm_email");
        By continueButton = By.XPath("//button[@title='Continue']");
        By successAlert = By.XPath("//div[@class='alert alert-success']");

        /// <summary>
        /// Metoda koja upisuje vrednost u polje login name
        /// </summary>
        /// <param name="login"></param>
        private void EnterLoginName(string login)
        {
            WriteText(loginNameField, login);
        }

        public string GetSuccessMessage()
        {
            return CommonMethods.ReadTextFromElement(driver, successAlert);
        }

        /// <summary>
        /// MEtoda koja upiusje vrednost u email polje
        /// </summary>
        /// <param name="email"></param>
        private void EnterEmail(string email)
        {
            WriteText(emailField, email);
        }

        /// <summary>
        /// Metoda koja klikne na continue dugme
        /// </summary>
        private void ClickOnContinueButton()
        {
            ClickElement(continueButton);
        }

        /// <summary>
        /// Metoda koja vrsi forgot password
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="email">email</param>

        public void ForgotPasswordAction(string name, string email)
        {
            EnterLoginName(name);
            EnterEmail(email);
            ClickOnContinueButton();
        }

    }
}
