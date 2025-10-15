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
    public class VerifyAllProductsPageTest : WebHomePage
    {
        WebElementMethods webElementMethods;
        HomePage homePage;
        ProductsPage productsPage;
        ProductDetailsPage productDetailsPage;

        [Test]
        public void VerifyAllProductsPageTestMethod()
        {
            // Test implementation goes here
            webElementMethods = new WebElementMethods(driver);
            homePage = new HomePage(driver);
            productsPage = new ProductsPage(driver);
            productDetailsPage = new ProductDetailsPage(driver);

            homePage.AcceptConsent();
            homePage.VerifyHomePageIsVisible();
            homePage.ClickOnProductsItem();

            productsPage.VerifyAllProductsPageIsVisible();
            productsPage.VerifyProductListIsVisible();
            productsPage.ClickOnViewProductBtn(0);

            productDetailsPage.VerifyProductDetailsPageIsVisible();
            productDetailsPage.VerifyAllProductDetailsAreVisible();
        }
    }
}
