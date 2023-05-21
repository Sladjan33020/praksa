using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.Pages
{
    public class ContactUsPage : BasePage
    {
        /// <summary>
        /// Konstruktor bez parametara
        /// </summary>
        public ContactUsPage()
        {
            driver = null;
        }

        /// <summary>
        /// Konstruktor sa parametrima
        /// </summary>
        /// <param name="webDriver">driver</param>
        public ContactUsPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        //Locators
        By firstNameField = By.Id("ContactUsFrm_first_name");
        By emailField = By.Id("ContactUsFrm_email");
        By enquiryField = By.Id("ContactUsFrm_enquiry");
        By submitButton = By.XPath("//button[@title='Submit']");

        /// <summary>
        /// Metoda koja upisuje vrednost u first name polje
        /// </summary>
        /// <param name="firstName">first name</param>
        private void EnterFirstName(string firstName)
        {
            WriteText(firstNameField, firstName);
        }

        /// <summary>
        /// Metoda koja upisuje vrednost u email polje
        /// </summary>
        /// <param name="email">email</param>
        private void EnterEmail(string email)
        {
            WriteText(emailField, email);
        }

        /// <summary>
        /// Metoda koja upisuje vrednost u enquiry polje
        /// </summary>
        /// <param name="text">enquiry</param>
        private void EnterEnquiry(string text)
        {
            WriteText(enquiryField, text);
        }

        /// <summary>
        /// Metoda koja klikne na submit dugme
        /// </summary>
        private void ClickOnSubmit()
        {
            ClickElement(submitButton);
        }

        public void ContactUs(string firstName, string email, string enquiry)
        {
            EnterFirstName(firstName);
            EnterEmail(email);
            EnterEnquiry(enquiry);
            ClickOnSubmit();
        }
    }
}
