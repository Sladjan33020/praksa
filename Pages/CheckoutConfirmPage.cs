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
    public class CheckoutConfirmPage : BasePage
    {
        /// <summary>
        /// Konstruktor bez parametara
        /// </summary>
        public CheckoutConfirmPage()
        {
            driver = null;
        }

        /// <summary>
        /// Konstruktor sa parametrima
        /// </summary>
        /// <param name="webDriver">driver</param>
        public CheckoutConfirmPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        //Locators
        By totalPriceSumLabel = By.XPath("//span[@class='bold totalamout']");
        By checkoutButton = By.Id("checkout_btn");

        /// <summary>
        /// Metoda koja vraca ukupnu cenu proizvoda
        /// </summary>
        /// <returns></returns>
        public string GetTotalPrice()
        {
            Thread.Sleep(3000);
            return CommonMethods.ReadTextFromElement(driver, totalPriceSumLabel);
        }

        /// <summary>
        /// Metoda koja klikne na checkout button
        /// </summary>
        public void ClickOnCheckoutButton()
        {
            ClickElement(checkoutButton);
        }
    }
}
