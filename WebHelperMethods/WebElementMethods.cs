using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationExercise.WebHelperMethods
{
    public class WebElementMethods
    {
        IWebDriver Driver;
        JavaScriptMethods jsMethods;

        public WebElementMethods(IWebDriver driver)
        {
            Driver = driver;
            jsMethods = new JavaScriptMethods(driver);
        }

        public void ClickOnElement(IWebElement element)
        {
            element.Click();
        }

        public void FillElement(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        public void TypeTextInWebElement(IWebElement element, string text)
        {
            element.SendKeys(text);
        }

        public void PressEnter(IWebElement element)
        {
            element.SendKeys(Keys.Enter);
        }

        public void ArrowDown(IWebElement element)
        {
            element.SendKeys(Keys.ArrowDown);
        }
        public void SelectAll(IWebElement element)
        {
            element.SendKeys(Keys.Control + "a");
        }
        public void SelectByText(IWebElement element, string text)
        {
            SelectElement dropdown = new SelectElement(element);
            dropdown.SelectByText(text);
        }
        public void SelectByValue(IWebElement element, string value)
        {
            SelectElement dropdown = new SelectElement(element);
            dropdown.SelectByValue(value);
        }
        public void SelectValueFromDropDown(IWebElement element, string text)
        {
            
            SelectElement dropdownCountry = new SelectElement(element);

            var options = dropdownCountry.Options.Select(o => o.Text).ToList();

            if (options.Contains(text))
            {
                dropdownCountry.SelectByValue(text);
                Console.WriteLine($"✅ Country '{text}' was selected successfully.");
            }
            else
                Console.WriteLine($"❌ Country '{text}' is NOT available in dropdown. Available options: {string.Join(", ", options)}");
        }

        public void SelectOptionFromDropDown(IWebElement element, string text)
        {
            element.Click();
            // option nodes get an auto-generated id that starts with "react-select"
            IWebElement option = Driver.FindElement(By.XPath($"//div[contains(@id, 'react-select') and text()='{text}']"));
            ClickOnElement(option);
        }

        public void SelectMultipleOptionsFromDropDown(IWebElement element, List<string> options)
        {
            IWebElement selectedOption;
            jsMethods.ScrollPageVertically(1000);

            element.Click();

            foreach (string option in options)
            {
                selectedOption = Driver.FindElement(By.XPath($"//div[contains(@id, 'react-select') and text()='{option}']"));
                selectedOption.Click();
            }
        }
        public void SelectElementFromListByText(IList<IWebElement> elementsList, string text)
        {
            foreach (IWebElement element in elementsList)
            {
                if (element.Text == text)
                    ClickOnElement(element);
            }
        }
    }
}
