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
    public class LoginUserCorrect : WebHomePage
    {
        WebElementMethods webElementMethods;
        HomePage homePage;
        LoginSignupPage loginSignupPage;
        HomePageLoggedUserPage homePageLoggedUserPage;
        DeleteAccountPage deleteAccountPage;

        [Test]  
        public void LoginUserCorrectMethod()
        {
            webElementMethods = new WebElementMethods(driver);
            homePage = new HomePage(driver);
            loginSignupPage = new LoginSignupPage(driver);
            homePageLoggedUserPage = new HomePageLoggedUserPage(driver);
            deleteAccountPage = new DeleteAccountPage(driver);
            var loginData = new LoginData(1);

            homePage.AcceptConsent();
            homePage.VerifyHomePageIsVisible();
            homePage.ClickOnSignupLoginItem();

            loginSignupPage.verifyLoginTitle();
            loginSignupPage.EnterLoginDataFromXML(loginData);
            loginSignupPage.ClickLoginBtn();
           
            homePageLoggedUserPage.VerifyLoggedInAs();
            homePageLoggedUserPage.DeleteAccountBtn();

            deleteAccountPage.VerifyAccountDeletedHeading();
            deleteAccountPage.ClickContinueBtn();
        }
    }
}
