using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.Pages
{
    public class LoginOrRegisterPage : BasePage
    {
        /// <summary>
        /// Konstruktor bez parametra
        /// </summary>
        public LoginOrRegisterPage()
        {
            driver = null;
        }

        /// <summary>
        /// Konstruktor sa parametrima
        /// </summary>
        /// <param name="webDriver">driver</param>
        public LoginOrRegisterPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        //Locators
        By registerContinueButton = By.XPath("//button[@title='Continue']");
        By loginNameField = By.Id("loginFrm_loginname");
        By passwordField = By.Id("loginFrm_password");
        By loginButton = By.XPath("//button[@title='Login']");
        By forgotPasswordLink = By.LinkText("Forgot your password?");
        By forgotLoginLink = By.LinkText("Forgot your login?");

        /// <summary>
        /// Metoda koja klikne na continue dugme za registraciju korisnika
        /// </summary>
        public void ClickOnRegisterContinueButton()
        {
            ClickElement(registerContinueButton);
        }

        /// <summary>
        /// Metoda koja klikne na forgot password link
        /// </summary>
        public void ClickForgotPasswordLink()
        {
            ClickElement(forgotPasswordLink);
        }

        /// <summary>
        /// MEtoda koja klikne na forgot your login 
        /// </summary>
        public void ClickForgotLoginLink()
        {
            ClickElement(forgotLoginLink);
        }

        /// <summary>
        /// Metoda koja upisuje vrednost u login polje
        /// </summary>
        /// <param name="login">login name</param>
        private void EnterLoginName(string login)
        {
            WriteText(loginNameField, login);
        }

        /// <summary>
        /// Metoda koja upisuje vrednost u password polje
        /// </summary>
        /// <param name="password">password</param>
        private void EnterPassword(string password)
        {
            WriteText(passwordField, password);
        }

        /// <summary>
        /// Metoda koja klikne na login dugme
        /// </summary>
        private void ClickOnLoginButton()
        {
            ClickElement(loginButton);
        }

        /// <summary>
        /// Metoda koja vrsi kompletan login korisnika
        /// </summary>
        /// <param name="loginName">login name</param>
        /// <param name="password">password</param>
        public void Login(string loginName, string password)
        {
            EnterLoginName(loginName);
            EnterPassword(password);
            ClickOnLoginButton();
        }
    }
}
