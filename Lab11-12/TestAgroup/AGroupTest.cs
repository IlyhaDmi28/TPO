using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TestAgroup.Driver;
using TestAgroup.Pages;
using TestAgroup.Utils;
using TestAgroup.Model;

namespace TestAgroup
{
    [TestClass]
    public class AGroupTest
    {
        private WebDriver driver;
        private TestingData testingData;

        private MainPage mainPage;
        private ProductPage productPage;
        private BasketPage basketPage;
        private LaptopePage laptopePage;
        private PhonePage phonePage;

        

        [TestInitialize]
        public void TestInitialize()
        {
            driver = DriverSingletone.GetDriver("Edge");
            driver.Manage().Window.Maximize();


            testingData = new TestingData();

            mainPage = new MainPage(driver);
            productPage = new ProductPage(driver);
            basketPage = new BasketPage(driver);
            laptopePage = new LaptopePage(driver);
            phonePage = new PhonePage(driver);  
        }

        [TestMethod]
        public void SearchTest()
        {
            bool ItemWithSearchTextOnFindResult = (mainPage.OpenPage() as MainPage)
                .SetSearchText(testingData.SearchText)
                .HasItemWithSearchTextOnFindResult();

            if(ItemWithSearchTextOnFindResult) Logger.WriteLine($"Test search with text {testingData.SearchText} finished successful!");
            else Logger.WriteLine($"Test search with text {testingData.SearchText} failed!");

            Assert.IsTrue(ItemWithSearchTextOnFindResult);
        }

        [TestMethod]
        public void BasketTest()
        {
            bool isAdd = (productPage.OpenPage() as ProductPage)
                .AddProductToBasket()
                .HasProductOnBasket();

            if (isAdd) Logger.WriteLine($"Test add product to basket finished successful!");
            else Logger.WriteLine($"Test add product to basket failed!");

            Assert.IsTrue(isAdd);
        }

        [TestMethod]
        public void ScrollSliderTest()
        {
            bool isScroll = (mainPage.OpenPage() as MainPage)
                .ScrollSlider()
                .HasScroollSliderAnimate();

            if (isScroll) Logger.WriteLine($"Test scroll slider finished successful!");
            else Logger.WriteLine($"Test scroll slider failed!");

            Assert.IsTrue(isScroll);
        }

        [TestMethod]
        public void FilterPhonesByOmledMatrixTest()
        {
            bool isFiltered = (phonePage.OpenPage() as PhonePage)
                .FilterPhonesByOledMatrix()
                .isFilteredPhonesByOledMatrix();

            if (isFiltered) Logger.WriteLine($"Test filter phones by matrix OLED finished successful!");
            else Logger.WriteLine($"Test filter phones by matrix OLED failed!");

            Assert.IsTrue(isFiltered);
        }

        [TestMethod]
        public void PromocodeTest()
        {
            bool isActivePomocode = (basketPage.OpenPage() as BasketPage)
                .SetPromocode(testingData.Promocode)
                .ApplyPromocode()
                .IsActivePomocode();

            if (isActivePomocode) Logger.WriteLine($"Test active promocode {testingData.Promocode} finished successful!");
            else Logger.WriteLine($"Test active promocode {testingData.Promocode} failed!");

            Assert.IsTrue(isActivePomocode);
        }

        [TestMethod]
        public void SortlLaptopsByAlphabetTest()
        {
            bool isSorted = (laptopePage.OpenPage() as LaptopePage)
                .sortByAlphabet()
                .IsSortdeByAlphabet();

            if (isSorted) Logger.WriteLine($"Test sort laptops by alphabet finished successful!");
            else Logger.WriteLine($"Test sort laptops by alphabet failed!");

            Assert.IsTrue(isSorted);
        }
    }
}