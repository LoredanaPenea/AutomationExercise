using AutomationExercise.Access;
using AutomationExercise.Browser;
using AutomationExercise.Pages;
using AutomationExercise.WebHelperMethods;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationExercise.Tests
{
    public class RegisterUserTest : WebHomePage
    {
        WebElementMethods webElementMethods;
        HomePage homePage;
        LoginSignupPage loginPage;
        SignUpPage signUpPage;
        AccountCreatedPage accountCreatedPage;
        HomePageLoggedUserPage homePageLoggedUserPage;
        DeleteAccountPage deleteAccountPage;

        [Test]
        public void RegisterUserTestMethod() 
        {
            webElementMethods = new WebElementMethods(driver);
            homePage = new HomePage(driver);
            loginPage = new LoginSignupPage(driver);
            signUpPage = new SignUpPage(driver);
            accountCreatedPage = new AccountCreatedPage(driver);
            homePageLoggedUserPage = new HomePageLoggedUserPage(driver);
            deleteAccountPage = new DeleteAccountPage(driver);
            var signupData = new SignUpData(1);
            var signUpUserData = new SignUpUserData(1);

            homePage.AcceptConsent();
            homePage.ClickOnSignupLoginItem();
            loginPage.VerifySingupTitle();
            loginPage.EnterSignUpDataFromXML(signupData);
            loginPage.ClickSignupBtn();

            signUpPage.VerifyAccountInformationHeading();
            signUpPage.FillAccountInformationUsingXML(signUpUserData);
            signUpPage.SelectDOB("2","february","1990");
            signUpPage.SubscribeToNewsletter();
            signUpPage.SubscribeToSpecialOffers();
            signUpPage.FillAddressInformationUsingXML(signUpUserData);
            signUpPage.ClickCreateAccount();

            accountCreatedPage.VerifyAccountCreatedHeading();
            accountCreatedPage.ClickContinueBtn();

            homePageLoggedUserPage.VerifyLoggedInAs();
            homePageLoggedUserPage.DeleteAccountBtn();
            
            deleteAccountPage.VerifyAccountDeletedHeading();
            deleteAccountPage.ClickContinueBtn();

        }
    }
}
