using AutomationExercise.WebHelperMethods;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AutomationExercise.Pages
{
    public class SignUpPage
    {
        IWebDriver webDriver;
        WebElementMethods webElementMethods;
        JavaScriptMethods jsMethods;

        public SignUpPage(IWebDriver driver) 
        { 
            this.webDriver = driver;
            webElementMethods = new WebElementMethods(driver);
            jsMethods = new JavaScriptMethods(webDriver);
        }

        IWebElement accountInformationHeading => webDriver.FindElement(By.XPath("//h2/b[text()='Enter Account Information']"));
        IWebElement titleMrRadioBtn => webDriver.FindElement(By.Id("id_gender1"));
        IWebElement titleMrsRadioBtn => webDriver.FindElement(By.Id("id_gender2"));
        IWebElement nameInput => webDriver.FindElement(By.CssSelector("input[data-qa='name']"));
        IWebElement emailInput => webDriver.FindElement(By.CssSelector("input[data-qa='email']"));
        IWebElement passwordInput => webDriver.FindElement(By.CssSelector("input[data-qa='password']"));
        IWebElement daysDropdown => webDriver.FindElement(By.CssSelector("select[data-qa='days']"));
        IWebElement monthsDropdown => webDriver.FindElement(By.CssSelector("select[data-qa='months']"));
        IWebElement yearsDropdown => webDriver.FindElement(By.CssSelector("select[data-qa='years']"));
        IWebElement newsletterCheckbox => webDriver.FindElement(By.Id("newsletter"));
        IWebElement specialOffersCheckbox => webDriver.FindElement(By.Id("optin"));

        IWebElement addressInformationHeading => webDriver.FindElement(By.XPath("//h2//b[text()='Address Information']"));

        IWebElement firstNameInput => webDriver.FindElement(By.CssSelector("input[data-qa='first_name']"));
        IWebElement lastNameInput => webDriver.FindElement(By.CssSelector("input[data-qa='last_name']"));
        IWebElement companyInput => webDriver.FindElement(By.Id("company"));
        IWebElement address1Input => webDriver.FindElement(By.CssSelector("input[data-qa='address']"));
        IWebElement address2Input => webDriver.FindElement(By.CssSelector("input[data-qa='address2']"));
        IWebElement countryDropdown => webDriver.FindElement(By.CssSelector("select[data-qa='country']"));
        IWebElement stateInput => webDriver.FindElement(By.CssSelector("input[data-qa='state']"));
        IWebElement cityInput => webDriver.FindElement(By.CssSelector("input[data-qa='city']"));
        IWebElement zipcodeInput => webDriver.FindElement(By.CssSelector("input[data-qa='zipcode']"));
        IWebElement mobileNumberInput => webDriver.FindElement(By.CssSelector("input[data-qa='mobile_number']"));

        IWebElement createAccountButton => webDriver.FindElement(By.CssSelector("button[data-qa='create-account']"));

        public void VerifyAccountInformationHeading()
        {
            Assert.IsTrue(accountInformationHeading.Displayed);
            Console.WriteLine("'Enter Account Information' is visible");
        }
        public void SelectTitle(string title)
        {
            switch (title)
            {
                case "Mr":
                    webElementMethods.ClickOnElement(titleMrRadioBtn);
                    break;
                case "Mrs":
                    webElementMethods.ClickOnElement(titleMrsRadioBtn);
                    break;
            }
        } 

        public void VerifyPrefilledUserInfo(string expectedName, string expectedEmail)
        {
            string actualName = nameInput.GetAttribute("value");
            string actualEmail = emailInput.GetAttribute("value");

            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedEmail, actualEmail);
        }
        public void SetPassword(string password)
        {
            webElementMethods.TypeTextInWebElement(passwordInput,password);
        } 

        public void SelectDOB(string day, string month, string year)
        {
            jsMethods.ScrollPageVertically(500);
            new SelectElement(daysDropdown).SelectByText(day);
            string newMonth = char.ToUpper(month[0]) + month.Substring(1).ToLower();
            new SelectElement(monthsDropdown).SelectByText(newMonth);
            new SelectElement(yearsDropdown).SelectByText(year);
        }

        public void SubscribeToNewsletter()
        {
            webElementMethods.ClickOnElement(newsletterCheckbox);
        }
        public void SubscribeToSpecialOffers()
        {
            webElementMethods.ClickOnElement(specialOffersCheckbox);
        }

        public void VerifyAdressInformationHeading()
        {
            Assert.IsTrue(addressInformationHeading.Displayed);
            Console.WriteLine("'Address Information' is visible");
        }

        public void FillAddressInformation(string firstName, string lastName, string company, string address, string country, string state, string city, string zipcode, string mobileNumber)
        {
            webElementMethods.FillElement(firstNameInput, firstName);
            webElementMethods.FillElement(lastNameInput,lastName);
            webElementMethods.FillElement(companyInput,company);
            webElementMethods.FillElement(address1Input,address);
            SelectCountry(country);
            webElementMethods.FillElement(stateInput, state);
            webElementMethods.FillElement(cityInput, city);
            webElementMethods.FillElement(zipcodeInput, zipcode);
            webElementMethods.FillElement(mobileNumberInput,mobileNumber);
        }

        public void SelectCountry (string country)
        {
            string newCountry = char.ToUpper(country[0]) + country.Substring(1).ToLower();
            webElementMethods.SelectValueFromDropDown(countryDropdown, newCountry);
        }

        public void ClickCreateAccount()
        {
            webElementMethods.ClickOnElement(createAccountButton);
        } 
    }
}
