using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationExercise.Browser
{
    public class WebHomePage
    {
        public WebDriver driver;

        [SetUp]
        public void InitializeBrowser()
        {
            driver = new BrowserFactory().GetBrowserFactory();
            driver.Navigate().GoToUrl("https://automationexercise.com/");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
            driver.Dispose();
        }
    }
}
