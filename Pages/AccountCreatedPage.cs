using AutomationExercise.WebHelperMethods;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationExercise.Pages
{
    public class AccountCreatedPage
    {
        IWebDriver webDriver;
        WebElementMethods webElementMethods;

        public AccountCreatedPage(IWebDriver driver)
        {
            this.webDriver = driver;
            webElementMethods = new WebElementMethods(driver);
        }
        IWebElement accountCreatedHeading => webDriver.FindElement(By.XPath("//h2//b[text()='Account Created!']"));
        IWebElement continueBtn => webDriver.FindElement(By.CssSelector("a[data-qa='continue-button']"));

        public void VerifyAccountCreatedHeading()
        {
            Assert.True(accountCreatedHeading.Displayed);// "'ACCOUNT CREATED!' heading is visible.");
            Console.WriteLine("'ACCOUNT CREATED!' is visible");
        }

        public void ClickContinueBtn()
        {
            webElementMethods.ClickOnElement(continueBtn);
        }
    }
}
