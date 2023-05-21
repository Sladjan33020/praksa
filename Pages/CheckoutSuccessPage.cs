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
    public class CheckoutSuccessPage : BasePage
    {
        /// <summary>
        /// Konstruktor bez parametara
        /// </summary>
        public CheckoutSuccessPage()
        {
            driver = null;
        }

        /// <summary>
        /// Konstruktor sa parametrima
        /// </summary>
        /// <param name="webDriver"></param>
        public CheckoutSuccessPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        //Locators
        By successText = By.XPath("//span[@class='maintext']");

        public string GetOrderSuccessMessage()
        {
            Thread.Sleep(1000);
            return CommonMethods.ReadTextFromElement(driver, successText);
        }
    }
}
