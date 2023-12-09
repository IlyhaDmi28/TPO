using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAgroup.Pages
{
    public class ProductPage : PageObject
    {
        public ProductPage(WebDriver driver) : base(driver)
        {
            driver.Manage().Timeouts().PageLoad = new TimeSpan(0, 0, 20);
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 30);
        }

        private IWebElement Product
        {
            get => driver.FindElement(By.XPath("//h1[@class='product-card__title h1 flc']"));
        }

        private IWebElement AddBasketButton
        {                                   
            get => driver.FindElement(By.XPath("//button[@class='product-card__action-btn btn btn--primary btn--lg btn--wide flc']"));
        }

        private IWebElement CloseInfoWindowButton
        {
            get => driver.FindElement(By.XPath("//button[@class='modal-window__close js-close-modal']"));
        }

        public void AddProductToBasket()
        {
            IJavaScriptExecutor javascriptExecutor = (IJavaScriptExecutor)driver;
            javascriptExecutor.ExecuteScript("arguments[0].click();", AddBasketButton);

            CloseInfoWindowButton.Click();
        }


        public string GetProductName()
        {
            IWebElement product = Product;
            return product.Text;
        }
        public override void OpenPage()
        {
            driver.Navigate().GoToUrl("https://agroup.by/elektronika/smartfony-i-aksessuary/mobilnye-telefony/xiaomi-redmi-note-12-6gb-128gb-mezhdunarodnaya-versiya-seryi-oniks/");
        }
    }
}
