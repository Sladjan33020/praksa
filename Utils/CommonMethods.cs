
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;

namespace AutomationFramework.Utils
{
    public class CommonMethods
    {
        /// <summary>
        /// Metoda koja klikne na element
        /// </summary>
        /// <param name="driver">driver</param>
        /// <param name="element">element</param>
        public static void ClickOnElement(IWebDriver driver, By element)
        {
            driver.FindElement(element).Click();
            
        }


        /// <summary>
        /// Metoda koja upisuje text u element
        /// </summary>
        /// <param name="driver">driver</param>
        /// <param name="element">element</param>
        /// <param name="text">text koji upisujemo</param>
        public static void WriteTextToElement(IWebDriver driver, By element, string text)
        {
            driver.FindElement(element).SendKeys(text);
        }
        /// <summary>
        /// Metoda koja upisuje text u element
        /// </summary>
        /// <param name="driver">driver</param>
        /// <param name="element">element</param>
        /// <param name="text">text koji upisujemo</param>
        public static void ClearTextFromElement(IWebDriver driver, By element)
        {
            driver.FindElement(element).Clear();
        }

        /// <summary>
        /// Metoda koja cita text iz elementa
        /// </summary>
        public static string ReadTextFromElement(IWebDriver driver, By element, uint timeSpan = 20)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeSpan));
            return driver.FindElement(element).Text;
        }

        /// <summary>
        /// Metoda koja vraca vrednosti celija iz prvog reda u tabeli
        /// </summary>
        /// <returns></returns>
        public static List<string> GetValuesFromFirstTableRow(IWebDriver driver)
        {
            List<string> values = new List<string>();
            ReadOnlyCollection<IWebElement> rows = driver.FindElements(By.XPath("//tr[@class='success']"));

            try
            {
                IWebElement firstRow = rows[0];
                ReadOnlyCollection<IWebElement> cells = driver.FindElements(By.XPath("//tr[@class='success']/td"));

                foreach (IWebElement cell in cells)
                {
                    values.Add(cell.Text);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return values;
        }

        /// <summary>
        /// Metoda koja kreira jedinstvenog korisnika, kreirajuci random broj
        /// kao sufix na "Random User" string
        /// </summary>
        /// <returns></returns>
        public static string GenerateRandomUsername(string randomName)
        {
            Random random = new Random();
            int randomNumber = random.Next(20, 9999);
            string username = randomName + randomNumber;
            return username;
        }
        
        /// <summary>
        /// Metoda koja generise random broj
        /// </summary>
        /// <returns>Vraca random broj od do</returns>
        public static int GeneratePassword(int from, int to)
        {
            Random random = new Random();
            int randomNumber = random.Next(from, to);
            return randomNumber;
        }

        /// <summary>
        /// Metoda koja proverava da li se element nalazi na stranici
        /// </summary>
        /// <param name="driver">driver</param>
        /// <param name="element">lokator elementa By</param>
        /// <returns></returns>
        public static bool IsElementPresented(IWebDriver driver, By element, uint timeoutInSeconds = 20)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return driver.FindElement(element).Displayed;

            } catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Metoda koja vraca sve opcije iz selekt elementa
        /// </summary>
        /// <param name="webDriver">driver</param>
        /// <param name="element">Lokator elementa</param>
        /// <returns>Vraca listu svih opcija iz select elementa</returns>
        public static List<string> GetAllOptions(IWebDriver webDriver, By element)
        {
            List<string> optionsList = new List<string>();
            
            try
            {
            
                ReadOnlyCollection<IWebElement> options = webDriver.FindElements(element);
                foreach(IWebElement option in options)
                {
                    optionsList.Add(option.Text);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return optionsList;
        }

        /// <summary>
        /// Metoda koja vraca random vrednost iz liste
        /// </summary>
        /// <param name="list">lista</param>
        /// <returns>Vraca random vrednost iz liste koji je tipa string</returns>
        public static string GetRandomItemFromList(List<string> list)
        {
            Random random = new Random();
            return list[random.Next(0, list.Count - 1)];
        }

        /// <summary>
        /// Metoda koja vraca broj artikla u tabeli
        /// </summary>
        /// <param name="webDriver">web driver</param>
        /// <param name="element">element</param>
        /// <returns>Vraca broj artikla koji je tipa int</returns>
        public static int GetCountFromTable(IWebDriver webDriver ,By element)
        {
            ReadOnlyCollection<IWebElement> options = webDriver.FindElements(element);
            return options.Count;
        }

        /// <summary>
        /// MEtoda koja klikne na prvi element
        /// </summary>
        /// <param name="webDriver">web driver</param>
        /// <param name="element">element</param>
        public static void ReturnFirst(IWebDriver webDriver, By element)
        {
            ReadOnlyCollection<IWebElement> options = webDriver.FindElements(element);
            options[0].Click();
        }

    }
}
