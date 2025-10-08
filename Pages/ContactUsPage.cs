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
    public class ContactUsPage
    {
        IWebDriver webDriver;
        WebElementMethods webElementMethods;

        public ContactUsPage(IWebDriver driver)
        {
            this.webDriver = driver;
            webElementMethods = new WebElementMethods(driver);
        }
        IWebElement getInTouchHeading => webDriver.FindElement(By.XPath("//h2[text()='Get In Touch']"));
        IWebElement nameInput => webDriver.FindElement(By.Name("name"));
        IWebElement emailInput => webDriver.FindElement(By.Name("email"));
        IWebElement subjectInput => webDriver.FindElement(By.Name("subject"));
        IWebElement messageTextarea => webDriver.FindElement(By.Name("message"));
        IWebElement uploadFileInput => webDriver.FindElement(By.Name("upload_file"));
        IWebElement submitButton => webDriver.FindElement(By.Name("submit"));
        IWebElement successMessage => webDriver.FindElement(By.XPath("//div[@class='status alert alert-success']"));
        IWebElement homeBtn => webDriver.FindElement(By.XPath("//a[@class='btn btn-success']"));

        public void VerifyGetInTouchHeadingIsVisible()
        {
            Assert.IsTrue(getInTouchHeading.Displayed);
            Console.WriteLine("'GET IN TOUCH' is visible");
        }
        public void FillContactUsFormUsingXML(ContactUsData contactUsData)
        {
            webElementMethods.FillElement(nameInput, contactUsData.Name);
            webElementMethods.FillElement(emailInput, contactUsData.Email);
            webElementMethods.FillElement(subjectInput, contactUsData.Subject);
            webElementMethods.FillElement(messageTextarea, contactUsData.Message);
          
            uploadFileInput.SendKeys(contactUsData.FilePath);
        }

        public void ClickSubmitButton()
        {
            webElementMethods.ClickOnElement(submitButton);
        }
        public void HandleAlertAfterSubmit()
        {
            try
            {
                IAlert alert = webDriver.SwitchTo().Alert();
                alert.Accept();
                Console.WriteLine("Alert accepted successfully.");
            }
            catch (NoAlertPresentException)
            {
                Console.WriteLine("No alert was present after form submission.");
            }
        }
        public void VerifySuccessMessageIsVisible()
        {
            Assert.IsTrue(successMessage.Displayed);
            Console.WriteLine("Success message is visible");
        }

        public void ClickOnHomeBtn()
        {
            webElementMethods.ClickOnElement(homeBtn);
        }
    }
}
