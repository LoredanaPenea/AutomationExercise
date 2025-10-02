using AutomationExercise.WebHelperMethods;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationExercise.Pages
{
    public class HomePageLoggedUserPage
    {
        IWebDriver webDriver;
        WebElementMethods webElementMethods;
        public HomePageLoggedUserPage(IWebDriver driver)
        {
            this.webDriver = driver;
            webElementMethods = new WebElementMethods(driver);
        }

        IList<IWebElement> navigationBarItems => webDriver.FindElements(By.CssSelector("ul.nav.navbar-nav li a"));

        IWebElement homeItem => navigationBarItems[0];
       
        IWebElement productsItem => navigationBarItems[1];
        // IWebElement productsLink => webDriver.FindElement(By.LinkText("Products"));
       

        IWebElement cartItem => navigationBarItems[2];
        // IWebElement cartLink => webDriver.FindElement(By.LinkText("Cart"));
        
        IWebElement logoutItem => navigationBarItems[3];
        // IWebElement logoutLink => webDriver.FindElement(By.LinkText("Logout"));
        
        IWebElement deleteAccountItem => navigationBarItems[4];
        IWebElement testCasesLink => webDriver.FindElement(By.LinkText("Test Cases"));

        IWebElement apiTestingLink => webDriver.FindElement(By.LinkText("API Testing"));

        IWebElement videoTutorialsLink => webDriver.FindElement(By.LinkText("Video Tutorials"));

        IWebElement contactUsLink => webDriver.FindElement(By.LinkText("Contact us"));

        IWebElement loggedInAsItem => navigationBarItems[9];

        public void VerifyLoggedInAs()
        {
            Assert.True(loggedInAsItem.Displayed);
            Console.WriteLine($"{loggedInAsItem.Text} is visible");
        }

        public void DeleteAccountBtn()
        {
            webElementMethods.ClickOnElement(deleteAccountItem);
        }
    }
}
