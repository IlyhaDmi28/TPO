using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAgroup.Pages
{
    public class MainPage : PageObject
    {

        public MainPage(WebDriver driver) : base(driver)
        {
            driver.Manage().Timeouts().PageLoad = new TimeSpan(0, 0, 20);
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 30);
        }

        private IWebElement searchInput
        {
            get => driver.FindElement(By.XPath("//input[@class='text-input']"));
        }

        private IWebElement scrollSliderButton
        {
            get => driver.FindElement(By.XPath("//button[@class='main-slider-arrow main-slider-arrow--next btn btn--secondary slick-arrow']"));
        }
        public MainPage SetSearchText(string searchText)
        {
            searchInput.SendKeys(searchText);
            return this;
        }

        public MainPage ScrollSlider()
        {
            scrollSliderButton.Click();
            return this;
        }

        public bool HasScroollSliderAnimate()
        {
            scrollSliderButton.Click();
            return driver.FindElement(By.XPath("//button[@class='main-slider-arrow main-slider-arrow--next btn btn--secondary slick-arrow']")) != null; 
        }
        public bool HasItemWithSearchTextOnFindResult()
        {
            string searchText = searchInput.Text;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            var searchResults = wait.Until((d) => d.FindElements(By.XPath("//div[@class='search-menu__name']")));

            foreach (var resuslt in searchResults)
            {
                if (!resuslt.Text.Contains(searchText)) return false;
            }

            return true;
        }
        public override PageObject OpenPage()
        {
            driver.Navigate().GoToUrl("https://agroup.by");
            return this;
        }


    }
}
