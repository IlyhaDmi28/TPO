using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAgroup.Pages
{
    public class PhonePage : PageObject
    {
        public PhonePage(WebDriver driver) : base(driver)
        {
            driver.Manage().Timeouts().PageLoad = new TimeSpan(0, 0, 20);
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 30);
        }

        private IWebElement OledFilter
        {
            get => driver.FindElement(By.XPath("//input[@value='467745']"));
        }

        public FilterPhonesPage FilterPhonesByOledMatrix()
        {
            IJavaScriptExecutor javascriptExecutor = (IJavaScriptExecutor)driver;
            javascriptExecutor.ExecuteScript("arguments[0].click();", OledFilter);
            return new FilterPhonesPage(driver).OpenPage() as FilterPhonesPage;
        }
        public void SelectPhone(string phone)
        {
            IWebElement parentElement = driver.FindElement(By.XPath($"//*[contains(text(),'{phone}')]/ancestor::*"));
        }
        public override PageObject OpenPage()
        {
            driver.Navigate().GoToUrl("https://agroup.by/elektronika/smartfony-i-aksessuary/mobilnye-telefony/");
            return this;
        }
    }
}
