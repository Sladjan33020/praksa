using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.Tests
{
    public class SearchProductTest : BaseTest
    {
        [Test]
        public void SearchProduct()
        {
            Pages.HomePage.EnterSearch(TestData.TestData.Search.product);

            //Assert
            string productName = Pages.ProductPage.GetNameOfProduct();
            Assert.AreEqual(AppConstants.Constants.ProductName.nameSkinsheenBronzerStick , productName);
        }
    }
}
