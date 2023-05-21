using AutomationFramework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationFramework.Pages
{
    public class MyAccountPage : BasePage
    {
        /// <summary>
        /// Konstruktor bez parametara
        /// </summary>
        public MyAccountPage()
        {
            driver = null;
        }

        /// <summary>
        /// Konstruktor sa parametrima
        /// </summary>
        /// <param name="webDriver">driver</param>
        public MyAccountPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        //Locators
        By welcomeText = By.XPath("//div[@class='menu_text']");
        By accountCreatedText = By.XPath("//span[@class='maintext']");
        By logoutLink = By.XPath("//ul[@class='sub_menu dropdown-menu']/li[last()][@class='dropdown']");
        By proba = By.XPath("//li[@class='dropdown open']/a[@class='top menu_account']");
        By homeButton = By.XPath("//a[@class='active menu_home']");
        
       

        /// <summary>
        /// Metoda koja vrece welcom back + username text
        /// </summary>
        /// <returns>vraca string koji je u obliku welcome back + username</returns>
        public string GetLoggedInText()
        {
            Thread.Sleep(2000);
            return CommonMethods.ReadTextFromElement(driver, welcomeText);
        }
        //Metoda iznad sad nije ni potrebna verovatno

        /// <summary>
        /// Metoda koja vraca tekst za potvrdu da je uspesno registrovan korisnik
        /// </summary>
        /// <returns>Potvrdu da je korisnik uspesno regsistrovan koja je tupa string</returns>
        public string GetAccountRegistrationConfirm()
        {
            return CommonMethods.ReadTextFromElement(driver, accountCreatedText);
        }

        /// <summary>
        /// Metoda koja klikne na logout link
        /// </summary>
        private void ClickOnLogouLink()
        {
            ClickElement(logoutLink);
        }


        /// <summary>
        /// Metoda koja hoveruje nad nekim elementom
        /// </summary>
        /// <param name="driver">driver</param>
        /// <param name="element">element</param>
        /// <param name="timeSpan">time span</param>
        public void HoverOverElement(uint timeSpan = 20)
        {
            IWebElement mainMenu = driver.FindElement(By.XPath("//ul[@id='customer_menu_top']/li"));

            //Instantiating Actions class
            Actions actions = new Actions(driver);

             //Hovering on main menu
            actions.MoveToElement(mainMenu);


            //Locating the element from Sub Menu
            IWebElement subMenu = driver.FindElement(By.XPath("//ul[@id='customer_menu_top']/li/ul/li[10]"));

            //To mouseover on sub menu
            actions.MoveToElement(subMenu).Click();


            //build()- used to compile all the actions into a single step
            actions.Click().Build().Perform();


        }

        /// <summary>
        /// MEtoda koja klikne na home button
        /// </summary>
        public void ClickOnHomeButton()
        {
            ClickElement(homeButton);
        }

        /// <summary>
        /// Metoda koja vrsi logout korisnika
        /// </summary>
        public void LogOut()
        {
            Thread.Sleep(2000);
            HoverOverElement();
        }
    }
}
