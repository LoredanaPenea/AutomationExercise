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

            homePage.AcceptConsent();
            homePage.ClickOnSignupLoginItem();
            loginPage.VerifySingupTitle();
            loginPage.EnterSignupName("Loredana");
            loginPage.EnterSignupEmail("lore@test1.com");
            loginPage.ClickSignupBtn();

            signUpPage.VerifyAccountInformationHeading();
            signUpPage.SelectTitle("Mrs");
            signUpPage.VerifyPrefilledUserInfo("Loredana", "lore@test1.com");
            signUpPage.SetPassword("password1");
            signUpPage.SelectDOB("2","february","1990");
            signUpPage.SubscribeToNewsletter();
            signUpPage.SubscribeToSpecialOffers();
            signUpPage.FillAddressInformation("Loredana","Penea","Endava","street 123","canada","AB","Montreal","1234","0770123456");

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
