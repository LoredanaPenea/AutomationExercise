using AutomationExercise.Access;
using AutomationExercise.Browser;
using AutomationExercise.Pages;
using AutomationExercise.WebHelperMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationExercise.Tests
{
    public class RegisterUserWithExistingEmailTest : WebHomePage
    {
        WebElementMethods webElementMethods;
        HomePage homePage;
        LoginSignupPage loginSignUpPage;

        [Test]

        public void RegisterUserWithExistingEmailTestMethod()
        {
            webElementMethods = new WebElementMethods(driver);
            homePage = new HomePage(driver);
            loginSignUpPage = new LoginSignupPage(driver);
            var signupData = new SignUpData(2);
           
            homePage.AcceptConsent();
            homePage.VerifyHomePageIsVisible();
            homePage.ClickOnSignupLoginItem();

            loginSignUpPage.VerifySingupTitle();
            loginSignUpPage.EnterSignUpDataFromXML(signupData);
            loginSignUpPage.ClickSignupBtn();
            loginSignUpPage.VerifyEmailAlreadyExistMessage();
        }
    }
}
