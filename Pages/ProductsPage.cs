using AutomationExercise.WebHelperMethods;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationExercise.Pages
{
    public class ProductsPage
    {
        IWebDriver webDriver;
        WebElementMethods webElementMethods;
        public ProductsPage(IWebDriver driver)
        {
            webDriver = driver;
            webElementMethods = new WebElementMethods(driver);
        }
        IWebElement allProductsHeading => webDriver.FindElement(By.CssSelector("h2.title.text-center"));
        List<IWebElement> productsList => webDriver.FindElements(By.ClassName("product-image-wrapper")).ToList();
        //IWebElement firstProductViewBtn => webDriver.FindElement(By.CssSelector("a[href='/product_details/1']"));

        List<IWebElement> viewProductBtns => webDriver.FindElements(By.XPath("//a[contains(text(),'View Product')]")).ToList();

        public void VerifyAllProductsPageIsVisible()
        {
            if (allProductsHeading.Displayed)
                Console.WriteLine("'ALL PRODUCTS' is visible");
            else
                Console.WriteLine("'ALL PRODUCTS' is NOT visible");
        }

        public void VerifyProductListIsVisible()
        {
            Assert.IsTrue(productsList.Count > 0, "Product list is not visible");
        }

        public void ClickOnViewProductBtn(int productIndex)
        {
            if (viewProductBtns.Count == 0)
                throw new Exception("No 'View Product' buttons found on the page.");
            else if (productIndex < 0 || productIndex >= viewProductBtns.Count)
                Console.WriteLine($"❌ Invalid product index: {productIndex}. It should be between 0 and {viewProductBtns.Count - 1}.");
                
            webElementMethods.ClickOnElement(viewProductBtns[productIndex]);
        }
    }
}
