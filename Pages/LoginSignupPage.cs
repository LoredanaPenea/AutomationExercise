using AutomationExercise.Access;
using AutomationExercise.WebHelperMethods;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationExercise.Pages
{
    public class LoginSignupPage
    {
        IWebDriver webDriver;
        WebElementMethods webElementMethods;

        public LoginSignupPage(IWebDriver driver)
        {
            webDriver = driver;
            webElementMethods = new WebElementMethods(driver);
        }

        IWebElement nameInput => webDriver.FindElement(By.Name("name"));
        IWebElement signupEmailInput => webDriver.FindElement(By.XPath("//input[@data-qa='signup-email']")); //Name("email"));
        IWebElement signupButton => webDriver.FindElement(By.XPath("//button[text()='Signup']"));
        IWebElement signupTitle => webDriver.FindElement(By.XPath("//h2[text()='New User Signup!']"));

        public bool IsSignupTitleVisible() => signupTitle.Displayed;

        IWebElement loginTitle => webDriver.FindElement(By.XPath("//h2[text()='Login to your account']"));
        IWebElement loginEmailInput => webDriver.FindElement(By.XPath("//input[@data-qa='login-email']"));
        IWebElement passwordInput => webDriver.FindElement(By.XPath("//input[@name='password']"));
        IWebElement loginButton => webDriver.FindElement(By.XPath("//button[text()='Login']"));

        public bool IsLoginTitleVisible() => loginTitle.Displayed;

        public void VerifySingupTitle()
        {
            Assert.IsTrue(IsSignupTitleVisible(), "New User Signup!");
            Console.WriteLine("'New User Signup!' is visible");
        }
        public void EnterSignupName(string name) 
        {
            webElementMethods.FillElement(nameInput, name);
        }
        
        public void EnterSignupEmail(string email)
        {
            webElementMethods.FillElement(signupEmailInput, email);
        } 

        public void EnterSignUpDataFromXML(SignUpData signupData)
        {
            webElementMethods.FillElement(nameInput, signupData.Name);
            webElementMethods.FillElement(signupEmailInput, signupData.EmailAddress);
        }
        public void ClickSignupBtn() 
        {
            webElementMethods.ClickOnElement(signupButton);
        }

        public void verifyLoginTitle()
        {
            Assert.IsTrue(IsLoginTitleVisible(), "Login to your account");
            Console.WriteLine("'Login to ypur account' is visible");
        }
        public void EnterLoginEmail(string email)
        {
            webElementMethods.FillElement(loginEmailInput, email);
            
        } 
        public void EnterLoginPassword(string password)
        {
            webElementMethods.FillElement(passwordInput, password);
        }
     /*   public void EnterLoginDataFromXML(LoginData loginData)
        {
            webElementMethods.FillElement();
            webElementMethods.FillElement();
        } */
        public void ClickLoginBtn() => loginButton.Click();
    }
}
