using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.Tests
{
    public class ValidateCartCountTest : BaseTest
    {
        [Test]
        public void ValidateCart()
        {
           
            int beforeAdd = Pages.HomePage.GetItemNumberInCart();

            Pages.HomePage.AddToCart();


            int afterAdd = Pages.HomePage.GetItemNumberInCart();

            //Assert
            Assert.Greater(afterAdd, beforeAdd);
        }
    }
}
