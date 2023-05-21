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
    public class HomePage : BasePage
    {
        /// <summary>
        /// Konstruktor bez parametara
        /// </summary>
        public HomePage()
        {
            driver = null;
        }

        /// <summary>
        /// Konstruktor sa parametrima
        /// </summary>
        /// <param name="webDriver">driver</param>
        public HomePage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        //Locators

        By loginOrRegisterLink = By.LinkText("Login or register");
        By contactUsLink = By.LinkText("Contact Us");
        By productAddToCartButton = By.XPath("//a[@data-id='50']");
        By productAddToCartButton2 = By.XPath("//a[@data-id='53']");
        By cartLinkElement = By.XPath("//ul[@class='nav topcart pull-left']/li[@class='dropdown hover']");
        By productName = By.XPath("//a[@class='prdocutname'][@title='Skinsheen Bronzer Stick']");
        By cartNumber = By.XPath("//ul[@class='nav topcart pull-left']/li[@class='dropdown hover']/a/span[@class='label label-orange font14']");
        By homeButton = By.XPath("//a[@class='active menu_home']");
        By searchBox = By.Id("filter_keyword");
        By searchIcon = By.XPath("//div[@title='Go']");

        /// <summary>
        /// Metoda koja klikne na link Login or register
        /// </summary>
        public void ClickOnLoginOrRegisterLink()
        {
            ClickElement(loginOrRegisterLink);
        }

        /// <summary>
        /// Metoda koja klikne na contact us link
        /// </summary>
        public void ClickOnContactUsLink()
        {
            ClickElement(contactUsLink);
        }

        /// <summary>
        /// Metoda koja klikne na home button
        /// </summary>
        public void ClickOnHomeButton()
        {
            ClickElement(homeButton);
        }

        /// <summary>
        /// Metoda koja klikne na add to cart dugme proizovda
        /// </summary>
        public void ClickOnAddToCart()
        {
            Thread.Sleep(500);
            ClickElement(productAddToCartButton);
        }

        /// <summary>
        /// Metoda koja klikne na addToCart
        /// </summary>
        private void ClickOnCartLink()
        {
            ClickElement(cartLinkElement);
        }

        /// <summary>
        /// Metoda koja vraca broj artikla u korpi
        /// </summary>
        /// <returns>vrqca broj artikla u korpi koji je tipa int</returns>
        public int GetItemNumberInCart()
        {
            Thread.Sleep(1000);
            return int.Parse(CommonMethods.ReadTextFromElement(driver, cartNumber));
        }

        /// <summary>
        /// Metoda koja klikne na item link
        /// </summary>
        public void ClickOnItemLink()
        {
            CommonMethods.ReturnFirst(driver, productName);
        }

        /// <summary>
        /// MEtoda koja pretrazuje odredjeni proizvos
        /// </summary>
        /// <param name="text">text</param>
        public void EnterSearch(string text)
        {
            Thread.Sleep(2000);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            WriteText(searchBox, text);
            driver.FindElement(searchBox).SendKeys(Keys.Return);
            ClickElement(searchIcon);
        }

        /// <summary>
        /// Metoda koja dodaje artiakl u korpu
        /// </summary>
        public void AddToCart()
        {
            Thread.Sleep(3000);
            ClickOnAddToCart();
            ClickOnCartLink();
        }
    }
}
