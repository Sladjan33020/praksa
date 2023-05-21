using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.Tests
{
    public class ContactUsTest : BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            Pages.HomePage.ClickOnContactUsLink();
            
           
        }

        [Test]
        public void ContactUs()
        {
            Pages.ContactUsPage.ContactUs(
                TestData.TestData.ContactUs.firstName,
                TestData.TestData.ContactUs.email,
                TestData.TestData.ContactUs.enquiry
                );

            //Assert

            string successMessage = Pages.ContactSuccessPage.GetEnquirySuccessSentText();
            Assert.AreEqual(AppConstants.Constants.GenericMessages.enquirySuccessText , successMessage);
        }
    }
}
