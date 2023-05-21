using AutomationFramework.Pages;
using SeleniumExtras.PageObjects;
using System;

namespace AutomationFramework.Utils
{
    /// <summary>
    /// Klasa koja inicijalicuje potrebnu stranicu
    /// </summary>
    public class AllPages
    {
        public AllPages(Browsers browser)
        {
            _browser = browser;
        }
        Browsers _browser { get; }
        private T GetPages<T>() where T : new()
        {
            var page = (T)Activator.CreateInstance(typeof(T), _browser.GetDriver);
            PageFactory.InitElements(_browser.GetDriver, page);
            return page;
        }

        public HomePage HomePage => GetPages<HomePage>();
        public LoginOrRegisterPage LoginOrRegisterPage => GetPages<LoginOrRegisterPage>();
        public CreateAccountPage CreateAccountPage => GetPages<CreateAccountPage>();
        public MyAccountPage MyAccountPage => GetPages<MyAccountPage>();
        public ForgotPasswordPage ForgotPasswordPage => GetPages<ForgotPasswordPage>();
        public ForgotLoginPage ForgotLoginPage => GetPages<ForgotLoginPage>();
        public ContactUsPage ContactUsPage => GetPages<ContactUsPage>();
        public ContactSuccessPage ContactSuccessPage => GetPages<ContactSuccessPage>();
        public ShoppingCartPage ShoppingCartPage => GetPages<ShoppingCartPage>();
        public ProductPage ProductPage => GetPages<ProductPage>();
        public CheckoutConfirmPage CheckoutConfirmPage => GetPages<CheckoutConfirmPage>();
        public CheckoutSuccessPage CheckoutSuccessPage => GetPages<CheckoutSuccessPage>();
    }
}
