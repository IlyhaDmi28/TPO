using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestAgroup
{
    [TestClass]
    public class AGroupSearchTest
    {
        private IWebDriver driver;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://agroup.by");
        }

        [TestMethod]
        public void SearchTest()
        {
            string searchText = "MSI Pulse"; // Замените текст на нужный

            IWebElement searchInput = driver.FindElement(By.XPath("//input[@class='text-input']"));
            searchInput.SendKeys(searchText);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement searchResultItem = wait.Until((d) => (IWebElement)d.FindElement(By.XPath("//div[@class='search-menu__name']")));

            var searchResults = driver.FindElements(By.XPath("//div[@class='search-menu__name']"));

            bool isCorrectFind = true;
            foreach (var resuslt in searchResults)
            {
                if(!resuslt.Text.Contains(searchText)) isCorrectFind = false;
            }
            Assert.IsTrue(isCorrectFind);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}