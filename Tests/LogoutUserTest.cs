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
    public class LogoutUserTest : WebHomePage
    {
        WebElementMethods webElementMethods;
        HomePage homePage;
        LoginSignupPage loginSignupPage;
        HomePageLoggedUserPage homePageLoggedUserPage;

        [Test]
        public void LogoutUserTestMethod()
        {
            webElementMethods = new WebElementMethods(driver);
            homePage = new HomePage(driver);
            loginSignupPage = new LoginSignupPage(driver);
            homePageLoggedUserPage = new HomePageLoggedUserPage(driver);
            var loginData = new LoginData(1);

            homePage.AcceptConsent();
            homePage.VerifyHomePageIsVisible();
            homePage.ClickOnSignupLoginItem();

            loginSignupPage.VerifyLoginTitle();
            loginSignupPage.EnterLoginDataFromXML(loginData);
            loginSignupPage.ClickLoginBtn();

            homePageLoggedUserPage.VerifyLoggedInAs();
            homePageLoggedUserPage.ClickOnLogoutItem();
            
            loginSignupPage.VerifyLoginTitle();
            //loginSignupPage.IsLoginFormVisible();
        }
    }
}
