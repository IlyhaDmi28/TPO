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

        public IWebElement GetProductOnBasket(string productName)
        {
            return driver.FindElement(By.XPath($"//a[text()='{productName}']"));
        }
        public override void OpenPage()
        {
            driver.Navigate().GoToUrl("https://agroup.by/order/");
        }
    }
}
