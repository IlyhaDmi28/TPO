using Newtonsoft.Json.Bson;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAgroup.Pages
{
    public class BasketPage : PageObject
    {
        public BasketPage(WebDriver driver) : base(driver)
        {
            driver.Manage().Timeouts().PageLoad = new TimeSpan(0, 0, 20);
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 30);
        }
        private IWebElement promocodeInput
        {
            get => driver.FindElement(By.XPath("//label[@class='text-input-label']/input"));
        }

        private IWebElement applyPromocodeButton
        {
            get => driver.FindElement(By.XPath("//button[@class='basket__aside-btn btn btn--primary btn--lg btn--wide flc']"));
        }
        public BasketPage SetPromocode(string promocode)
        {
            promocodeInput.SendKeys(promocode);
            return this;
        }

        public BasketPage ApplyPromocode() 
        {
            applyPromocodeButton.Click();
            return this;
        }

        public bool IsActivePomocode()
        {
            return /*promocodeInput == null*/driver.FindElement(By.XPath("//button[@class='basket__inner-button']")) != null;
        }

        public bool HasProductOnBasket()
        {
            return driver.FindElement(By.XPath("//a[text()='Смартфон Xiaomi Redmi Note 12 6GB/128GB с NFC международная версия (серый оникс)']")) != null;
        }
        public override PageObject OpenPage()
        {
            driver.Navigate().GoToUrl("https://agroup.by/order/");
            return this;
        }
    }
}
