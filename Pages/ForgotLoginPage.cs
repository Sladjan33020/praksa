using AutomationFramework.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.Pages
{
    public class ForgotLoginPage : BasePage
    {
        /// <summary>
        /// Konstruktor bez parametara
        /// </summary>
        public ForgotLoginPage()
        {
            driver = null;
        }

        /// <summary>
        /// Konstruktor sa parametrima
        /// </summary>
        /// <param name="webDriver"></param>
        public ForgotLoginPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        //Locators
        By lastNameField = By.Id("forgottenFrm_lastname");
        By emailField = By.Id("forgottenFrm_email");
        By continueButton = By.XPath("//button[@title='Continue']");
        By successMessage = By.XPath("//div[@class='alert alert-success']");

        /// <summary>
        /// MEtoda koja vrsi upis vrednosti u polje last name
        /// </summary>
        /// <param name="lastName"></param>
        private void EnterLastName(string lastName)
        {
            WriteText(lastNameField, lastName);
        }

        /// <summary>
        /// Metoda koja vrsi upis vrednosti u polje email
        /// </summary>
        /// <param name="email"></param>
        private void EnterEmail(string email)
        {
            WriteText(emailField, email);
        }

        /// <summary>
        /// Metoda koja klikne na dugme Continue
        /// </summary>
        private void ClickOnContinue()
        {
            ClickElement(continueButton);
        }

        public string GetSuccessMessage()
        {
            return CommonMethods.ReadTextFromElement(driver, successMessage);
        }

        /// <summary>
        /// Metoda koja izvrsava niz akcija za forgot login name
        /// </summary>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        public void ForgotLoginName(string lastName, string email)
        {
            EnterLastName(lastName);
            EnterEmail(email);
            ClickOnContinue();
        }
    }
}
