using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TestAgroup.Pages;

namespace TestAgroup
{
    [TestClass]
    public class AGroupSearchTest
    {
        private MainPage mainPage;
        private ProductPage productPage;
        private BasketPage basketPage;
        private ChromeDriver driver;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            mainPage = new MainPage(driver);
            productPage = new ProductPage(driver);
            basketPage = new BasketPage(driver);

        }

        [TestMethod]
        public void SearchTest()
        {
            mainPage.OpenPage();
            Thread.Sleep(2000);
            string searchText = "MSI Pulse";
            mainPage.SetSearchText(searchText);
            Thread.Sleep(5000);
            Assert.IsTrue(mainPage.HasItemWithSearchTextOnFindResult(searchText));
        }

        [TestMethod]
        public void BasketTest()
        {
            productPage.OpenPage();
            Thread.Sleep(2000);
            productPage.AddProductToBasket();
            Thread.Sleep(2000);
            string productName = productPage.GetProductName();
            basketPage.OpenPage();
            Thread.Sleep(4000);
            Assert.IsNotNull(basketPage.GetProductOnBasket(productName));
        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}