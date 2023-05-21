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
    public class ProductPage : BasePage
    {
        /// <summary>
        /// Konstruktor bez parametara
        /// </summary>
        public ProductPage()
        {
            driver = null;
        }

        /// <summary>
        /// Konstruktor sa parametrima
        /// </summary>
        /// <param name="webDriver">driver</param>
        public ProductPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        //Locators
        By addToCartButton = By.XPath("//a[@class='cart']");
        By productName = By.XPath("//h1[@class='productname']");

        /// <summary>
        /// Metoda koja klikne na dd to cart button
        /// </summary>
        public void ClickOnAddToCartItem()
        {
            ClickElement(addToCartButton);
        }

        public string GetNameOfProduct()
        {
            Thread.Sleep(1000);
            return CommonMethods.ReadTextFromElement(driver, productName);
        }
    }
}
