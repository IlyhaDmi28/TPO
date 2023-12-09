using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAgroup.Pages
{
    public class LaptopePage : PageObject
    {
        public LaptopePage(WebDriver driver) : base(driver)
        {
            driver.Manage().Timeouts().PageLoad = new TimeSpan(0, 0, 20);
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 30);
        }

        private IWebElement sortAlphabetButton
        {
            get => driver.FindElement(By.XPath("//span[text()='По алфавиту']/preceding-sibling::input[@type='radio']"));
        }

        public LaptopePage sortByAlphabet()
        {
            IJavaScriptExecutor javascriptExecutor = (IJavaScriptExecutor)driver;
            javascriptExecutor.ExecuteScript("arguments[0].click();", sortAlphabetButton);
            return this;
        }

        public bool IsSortdeByAlphabet()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            var sotrtedResults = wait.Until((d) => d.FindElements(By.XPath("//div[@class='product-list-item__name']")));

            List<string> laptopNames = sotrtedResults.Select(laptop => laptop.Text).ToList();

            return laptopNames.SequenceEqual(laptopNames.OrderBy(name => name));
        }
        public void SelectPhone(string phone)
        {
            IWebElement parentElement = driver.FindElement(By.XPath($"//*[contains(text(),'{phone}')]/ancestor::*"));
        }
        public override PageObject OpenPage()
        {
            driver.Navigate().GoToUrl("https://agroup.by/kompyuternaya-tekhnika/noutbuki-i-aksessuary/noutbuki/");
            return this;
        }
    }
}
