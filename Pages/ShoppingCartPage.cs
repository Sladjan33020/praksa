using AutomationFramework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationFramework.Pages
{
    public class ShoppingCartPage : BasePage
    {
        /// <summary>
        /// Konstruktor bez parametara
        /// </summary>
        public ShoppingCartPage()
        {
            driver = null;
        }

        /// <summary>
        /// Konstruktor sa parametrima
        /// </summary>
        /// <param name="webDriver">driver</param>
        public ShoppingCartPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        //Locators
        By tableRows = By.XPath("//div[@class='container-fluid cart-info product-list']/table[@class='table table-striped table-bordered']/tbody/tr[position()>1]");
        By deleteButton = By.XPath("//div[@class='container-fluid cart-info product-list']/table[@class='table table-striped table-bordered']/tbody/tr/td[last()]");
        By emptyCartText = By.XPath("//div[@class='contentpanel']");
        By currencyDropdown = By.XPath("//ul[@class='nav language pull-left']");
        By eurOption = By.XPath("//ul[@class='nav language pull-left']/li/ul/li[1]");
        By poundOption = By.XPath("//ul[@class='nav language pull-left']/li/ul/li[2]");
        By usdOption = By.XPath("//ul[@class='nav language pull-left']/li/ul/li[3]");
        By checkoutButton = By.Id("cart_checkout2");

        /// <summary>
        /// metoda koja broji redove u tabeli
        /// </summary>
        /// <returns>Vraca broj redova koji je tipa int</returns>
        public int CountItemsInCart()
        {
            Thread.Sleep(500);
            return CommonMethods.GetCountFromTable(driver, tableRows);
        }

        /// <summary>
        /// Metoda koja brise artikal iz korpe
        /// </summary>
        public void ClickOnDeleteItem()
        {
            ClickElement(deleteButton);
        }

        private void ClickOnCheckoutButton()
        {
            ClickElement(checkoutButton);
        }

        /// <summary>
        /// Metoda koja vraca poruku da je prazna korpa
        /// </summary>
        /// <returns>vraca poruku tipa string da je prazna kopa</returns>
        public string EmptyCartMessage()
        {
            return CommonMethods.ReadTextFromElement(driver, emptyCartText);
        }

        public void Checkout(string currency)
        {
            ChangeCurrency(currency);
            ClickOnCheckoutButton();

        }

        private void ChangeCurrency(string currency)
        {
            IWebElement mainMenu = driver.FindElement(currencyDropdown);

            //Instantiating Actions class
            Actions actions = new Actions(driver);

            //Hovering on main menu
            actions.MoveToElement(mainMenu);

            IWebElement subMenu;
            switch (currency)
            {
                case "eur":
                     subMenu = driver.FindElement(eurOption);
                    break;
                case "usd":
                     subMenu = driver.FindElement(usdOption);
                    break;
                case "pound":
                     subMenu = driver.FindElement(poundOption);
                    break;
                default:
                    subMenu = null;
                    break;
            }

            //To mouseover on sub menu
            actions.MoveToElement(subMenu).Click();


            //build()- used to compile all the actions into a single step
            actions.Click().Build().Perform();
        }
    }
}
