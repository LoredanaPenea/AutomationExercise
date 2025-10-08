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
    public class ContactUsSubmitFormTest : WebHomePage
    {
        WebElementMethods webElementMethods;
        HomePage homePage;
        ContactUsPage contactUsPage;

        [Test]
        public void ContactUsSubmitFormTestMethod()
        {
            webElementMethods = new WebElementMethods(driver);
            homePage = new HomePage(driver);
            contactUsPage = new ContactUsPage(driver);
            var contactUsData = new ContactUsData(1);

            homePage.AcceptConsent();
            homePage.VerifyHomePageIsVisible();
            homePage.ClickOnContactUsItem();

            contactUsPage.VerifyGetInTouchHeadingIsVisible();
            contactUsPage.FillContactUsFormUsingXML(contactUsData);
            contactUsPage.ClickSubmitButton();
            contactUsPage.HandleAlertAfterSubmit();
            contactUsPage.VerifySuccessMessageIsVisible();
            contactUsPage.ClickOnHomeBtn();
            homePage.VerifyHomePageIsVisible();
        }
    }
}
