using AutomationExercise.Browser;
using AutomationExercise.WebHelperMethods;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationExercise.Pages
{
    public class ProductDetailsPage
    {
        IWebDriver webDriver;
        WebElementMethods webElementMethods;

        public ProductDetailsPage(IWebDriver driver) 
        {
            this.webDriver = driver;
            webElementMethods = new WebElementMethods(driver);
        }
        IWebElement productDetailSection => webDriver.FindElement(By.ClassName("product-information"));
        IWebElement productName => webDriver.FindElement(By.XPath("//h2"));
        IWebElement productCategory => webDriver.FindElement(By.XPath("//p[contains(text(),'Category:')]"));
        IWebElement productPrice => webDriver.FindElement(By.XPath("//span[contains(text(),'Rs.')]"));
        IWebElement productAvailability => webDriver.FindElement(By.XPath("//b[contains(text(),'Availability:')]"));
        IWebElement productCondition => webDriver.FindElement(By.XPath("//b[contains(text(),'Condition:')]"));
        IWebElement productBrand => webDriver.FindElement(By.XPath("//b[contains(text(),'Brand:')]"));

        public void VerifyProductDetailsPageIsVisible()
        {
            Assert.IsTrue(productDetailSection.Displayed, "Product detail section not visible");
        }


        public void VerifyAllProductDetailsAreVisible()
        {
            VerifyProductNameIsVisible();
            VerifyProductCategoryIsVisible();
            VerifyProductPriceIsVisible();
            VerifyProductAvailabilityIsVisible();
            VerifyProductConditionIsVisible();
            VerifyProductBrandIsVisible();
        }
        public void VerifyProductNameIsVisible()
        {
            Assert.IsTrue(productName.Displayed, "Product name not visible");
            Console.WriteLine($"✅ Product Name: {productName.Text}");
        }

        public void VerifyProductCategoryIsVisible()
        {
            Assert.IsTrue(productCategory.Displayed, "Product category not found");
            Console.WriteLine($"✅ Product Category: {productCategory.Text}");
        }

        public void VerifyProductPriceIsVisible()
        {
            Assert.IsTrue(productPrice.Displayed, "Product price not visible");
            Console.WriteLine($"✅ Product Price: {productPrice.Text}");

        }

        public void VerifyProductAvailabilityIsVisible()
        {
            Assert.IsTrue(productAvailability.Displayed, "Availability info missing");
            Console.WriteLine($"✅ Product Availability: {productAvailability.Text}");

        }

        public void VerifyProductConditionIsVisible()
        {
            Assert.IsTrue(productCondition.Displayed, "Condition info missing");
            Console.WriteLine($"✅ Product Condition: {productCondition.Text}");
        }

        public void VerifyProductBrandIsVisible()
        {
            Assert.IsTrue(productBrand.Displayed, "Brand info missing");
            Console.WriteLine($"✅ Product Brand: {productBrand.Text}");
        }
    }
}
