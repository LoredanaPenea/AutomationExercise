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
    public class LoginUserWithIncorrectCredentialsTest : WebHomePage
    {
        WebElementMethods webElementMethods;
        HomePage homePage;
        LoginSignupPage loginSignUpPage;

        [Test]
        public void LoginUserWithIncorrectCredentialsTestMethod()
        {
            webElementMethods = new WebElementMethods(driver);
            homePage = new HomePage(driver);
            loginSignUpPage = new LoginSignupPage(driver);
            var loginData = new LoginData(2);

            homePage.AcceptConsent();
            homePage.VerifyHomePageIsVisible();
            homePage.ClickOnSignupLoginItem();

            loginSignUpPage.VerifyLoginTitle();
            loginSignUpPage.EnterLoginDataFromXML(loginData);
            loginSignUpPage.ClickLoginBtn();
            loginSignUpPage.VerifyIncorrectEmailOrPasswordMessage();
        }
    }
}
