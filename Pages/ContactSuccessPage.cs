using AutomationFramework.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationFramework.Pages
{
    public class ContactSuccessPage : BasePage
    {
        /// <summary>
        /// Konstruktor bez parametara
        /// </summary>
        public ContactSuccessPage()
        {
            driver = null;
        }

        /// <summary>
        /// Konstruktor sa parametrima
        /// </summary>
        /// <param name="webDriver">driver</param>
        public ContactSuccessPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        //Locators
        By successText = By.XPath("//section/p[2]");

        public string GetEnquirySuccessSentText()
        {
            Thread.Sleep(1000);
            return CommonMethods.ReadTextFromElement(driver, successText);
        }
    }
}
