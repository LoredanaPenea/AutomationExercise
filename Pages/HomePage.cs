using AutomationExercise.WebHelperMethods;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationExercise.Pages
{
    public class HomePage
    {
        IWebDriver webDriver;
        WebElementMethods webElementMethods;

        public HomePage(IWebDriver driver)
        {
            webDriver = driver;
            webElementMethods = new WebElementMethods(driver);
        }
        
        IList<IWebElement> navigationBarItems => webDriver.FindElements(By.CssSelector("ul.nav.navbar-nav li a"));
        
        IWebElement homeItem => navigationBarItems[0];
        // IWebElement homeLink => webDriver.FindElement(By.LinkText("Home"));
        // IWebElement homeCss => webDriver.FindElement(By.CssSelector("ul.nav.navbar-nav li a[href='/']"));
        IWebElement productsItem => navigationBarItems[1];
        // IWebElement productsLink => webDriver.FindElement(By.LinkText("Products"));
        // IWebElement productsXPath => webDriver.FindElement(By.XPath("//ul[@class='nav navbar-nav']//a[@href='/products']"));

        IWebElement cartItem => navigationBarItems[2];
        // IWebElement cartLink => webDriver.FindElement(By.LinkText("Cart"));
        // IWebElement cartCss => webDriver.FindElement(By.CssSelector("a[href='/view_cart']"));
        IWebElement signupLoginItem => navigationBarItems[3];
       // IWebElement signupLoginLink => webDriver.FindElement(By.LinkText("Signup / Login"));
       // IWebElement signupLoginXPath => webDriver.FindElement(By.XPath("//a[contains(text(),'Signup / Login')]"));

        IWebElement testCasesLink => webDriver.FindElement(By.LinkText("Test Cases"));
       // IWebElement testCasesCss => webDriver.FindElement(By.CssSelector("a[href='/test_cases']"));

        IWebElement apiTestingLink => webDriver.FindElement(By.LinkText("API Testing"));
       // IWebElement apiTestingXPath => webDriver.FindElement(By.XPath("//a[@href='/api_list']"));

        IWebElement videoTutorialsLink => webDriver.FindElement(By.LinkText("Video Tutorials"));
       // IWebElement videoTutorialsCss => webDriver.FindElement(By.CssSelector("a[href*='youtube.com']"));
    
        IWebElement contactUsLink => webDriver.FindElement(By.LinkText("Contact us"));
        // IWebElement contactUsXPath => webDriver.FindElement(By.XPath("//a[@href='/contact_us']"));
        IWebElement consentPopup => webDriver.FindElement(By.CssSelector("div.fc-dialog-scrollable-content"));
        IWebElement consentButton => webDriver.FindElement(By.XPath("//button[@aria-label='Consent']"));
        IWebElement logo => webDriver.FindElement(By.CssSelector("img[alt='Website for automation practice']"));
        
        public void AcceptConsent()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            if (IsConsentPopupDisplayed())
                consentButton.Click();
        }

        public bool IsConsentPopupDisplayed()
        {
            try
            {
                return consentPopup.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public void VerifyHomePageIsVisible()
        {
            if (logo.Displayed)
                Console.WriteLine("✅ Home page is visible: Logo is displayed.");
            Assert.IsTrue(logo.Displayed, "Home page logo is not visible. Home page may not have loaded correctly.");
        }
        public void ClickOnHomeItem()
        {
            webElementMethods.ClickOnElement(homeItem);
            // webElementMethods.ClickOnElement(navigationBarItems[0]);
        }

        public void ClickOnProductsItem()
        {
            webElementMethods.ClickOnElement(productsItem);
        }

        public void ClickOnCartItem()
        {
            webElementMethods.ClickOnElement(cartItem);
        }

        public void ClickOnSignupLoginItem()
        {
            webElementMethods.ClickOnElement(signupLoginItem);
        }

    }
}
