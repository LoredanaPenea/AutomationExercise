using AutomationExercise.WebHelperMethods;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationExercise.Pages
{
    public class DeleteAccountPage
    {
        IWebDriver webDriver;
        WebElementMethods webElementMethods;

        public DeleteAccountPage(IWebDriver driver)
        {
            this.webDriver = driver;
            webElementMethods = new WebElementMethods(driver);
        }

        IWebElement accountDeletedHeading => webDriver.FindElement(By.XPath("//h2//b[text()='Account Deleted!']"));
        IWebElement continueBtn => webDriver.FindElement(By.CssSelector("a[data-qa='continue-button']"));

        public void VerifyAccountDeletedHeading()
        {
            Assert.True(accountDeletedHeading.Displayed);
            Console.WriteLine("'ACCOUNT DELETED!' is visible");
        }

        public void ClickContinueBtn()
        {
            webElementMethods.ClickOnElement(continueBtn);
        }
    }
}
