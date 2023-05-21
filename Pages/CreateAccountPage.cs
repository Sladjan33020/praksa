using AutomationFramework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationFramework.Pages
{
    public class CreateAccountPage : BasePage
    {
        /// <summary>
        /// Konstruktor bez parametara
        /// </summary>
        public CreateAccountPage()
        {
            driver = null;
        }

        /// <summary>
        /// Konstruktor sa parametrima
        /// </summary>
        /// <param name="webDriver">driver</param>
        public CreateAccountPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        //Locators
        By firstNameField = By.Id("AccountFrm_firstname");
        By lastNameField = By.Id("AccountFrm_lastname");
        By emailField = By.Id("AccountFrm_email");
        By telephoneField = By.Id("AccountFrm_telephone");
        By faxField = By.Id("AccountFrm_fax");
        By companyField = By.Id("AccountFrm_company");
        By address1Field = By.Id("AccountFrm_address_1");
        By address2Field = By.Id("AccountFrm_address_2");
        By cityField = By.Id("AccountFrm_city");
        By regionSelectElement = By.Id("AccountFrm_zone_id");
        By regionOptionsElements = By.XPath("//select[@id='AccountFrm_zone_id']/option");
        By zipCodeField = By.Id("AccountFrm_postcode");
        By countrySelectElement = By.Id("AccountFrm_country_id");
        By countryOptionsElements = By.XPath("//select[@id='AccountFrm_country_id']/option");
        By loginNameField = By.Id("AccountFrm_loginname");
        By passwordField = By.Id("AccountFrm_password");
        By passwordConfirmField = By.Id("AccountFrm_confirm");
        By newsletterNoButton = By.Id("AccountFrm_newsletter0");
        By privacyPolicyCheckbox = By.Id("AccountFrm_agree");
        By continueButton = By.XPath("//button[@title='Continue']");

        /// <summary>
        /// Metoda koja unosi vrednost u first name polje
        /// </summary>
        /// <param name="name">name</param>
        private void EnterFirstName(string name)
        {
            WriteText(firstNameField, name);
        }

        /// <summary>
        /// Metoda koja unosi vrednost u last name polje
        /// </summary>
        /// <param name="lastName">last name</param>
        private void EnterLastName(string lastName)
        {
            WriteText(lastNameField, lastName);
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
        /// Metoda koja upisuje vrednost u telephone polje
        /// </summary>
        /// <param name="tel">telephone</param>
        private void EnterTelephone(string tel)
        {
            WriteText(telephoneField, tel);
        }

        /// <summary>
        /// Metoda koja unosi vrednost u fax polje
        /// </summary>
        /// <param name="fax">fax</param>
        private void EnterFax(string fax)
        {
            WriteText(faxField, fax);
        }

        /// <summary>
        /// Metoda koja upisuje vrednost u company polje
        /// </summary>
        /// <param name="company">company</param>
        private void EnterCompany(string company)
        {
            WriteText(companyField, company);
        }

        /// <summary>
        /// Metoda koja upisuje vrednost u address1 polje
        /// </summary>
        /// <param name="address1">address1</param>
        private void EnterAddress1(string address1)
        {
            WriteText(address1Field, address1);
        }

        /// <summary>
        /// Metoda koja upisuje vrednost u address2 polje
        /// </summary>
        /// <param name="address2">address2</param>
        private void EnterAddress2(string address2)
        {
            WriteText(address2Field, address2);
        }

        /// <summary>
        /// Metoda koja upisuje vrednost u city polje
        /// </summary>
        /// <param name="city">city</param>
        private void EnterCity(string city)
        {
            WriteText(cityField, city);
        }

        /// <summary>
        /// Metoda koja nasumicno bira region iz select elementa
        /// </summary>
        private void SelectRegion()
        {
            Thread.Sleep(1000);
            List<string> options = CommonMethods.GetAllOptions(driver, regionOptionsElements);

            SelectElement select = new SelectElement(driver.FindElement(regionSelectElement));
            select.SelectByText(CommonMethods.GetRandomItemFromList(options));
        }

        /// <summary>
        /// Metoda koja unosi vrednost u zip code polje
        /// </summary>
        /// <param name="zip">zip code</param>
        private void EnterZipCode(string zip)
        {
            WriteText(zipCodeField, zip);
        }

        /// <summary>
        /// Metoda koja nasumicno bira drzavu
        /// </summary>
        private void SelectCountry()
        {
            Thread.Sleep(1000);

            List<string> options = CommonMethods.GetAllOptions(driver, countryOptionsElements);

            SelectElement select = new SelectElement(driver.FindElement(countrySelectElement));
            select.SelectByText(CommonMethods.GetRandomItemFromList(options));
        }

        /// <summary>
        /// Metoda koja unosi vrednost u login name polje 
        /// </summary>
        /// <param name="loginName"></param>
        private void EnterLoginName(string loginName)
        {
            WriteText(loginNameField, loginName);
        }

        /// <summary>
        /// Metoda koja unosi vrednost u password field i confirm password field
        /// </summary>
        /// <param name="password">password</param>
        private void EnterPassword(string password)
        {
            WriteText(passwordField, password);
            WriteText(passwordConfirmField, password);
        }

        /// <summary>
        /// Metoda koja klikne na no za newsletter subscribe
        /// </summary>
        private void ClickNewsletterNo()
        {
            ClickElement(newsletterNoButton);
        }

        /// <summary>
        /// Metoda koja stiklira da je procitana i da se slazemo sa privacy policy
        /// </summary>
        private void CheckPrivacyPolicy()
        {
            ClickElement(privacyPolicyCheckbox);
        }

        private void ClickOnContinueButton()
        {
            ClickElement(continueButton);
        }
        
        public void RegisterUser(string firstName, string lastName, string email,
            string telephone, string fax, string company, 
            string address1, string address2, string city, 
            string zipCode, string loginName, string password)
        {
            
            EnterFirstName(firstName);
            EnterLastName(lastName);
            EnterEmail(email);
            EnterTelephone(telephone);
            EnterFax(fax);
            EnterCompany(company);
            EnterAddress1(address1);
            EnterAddress2(address2);
            EnterCity(city);
            SelectCountry();
            SelectRegion();
            EnterZipCode(zipCode);
            EnterLoginName(loginName);
            EnterPassword(password);
            ClickNewsletterNo();
            CheckPrivacyPolicy();
            ClickOnContinueButton();

        }

    }
}
