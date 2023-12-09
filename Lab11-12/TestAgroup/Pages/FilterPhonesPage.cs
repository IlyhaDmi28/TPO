using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAgroup.Pages
{
    public class FilterPhonesPage : PageObject
    {
        public FilterPhonesPage(WebDriver driver) : base(driver)
        {
            driver.Manage().Timeouts().PageLoad = new TimeSpan(0, 0, 20);
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 30);
        }

        public bool isFilteredPhonesByOledMatrix()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            var omledParams = wait.Until((d) => d.FindElements(By.XPath("//span[@class='product-list-item__param-value' and contains(text(), 'OLED')]")));
            var phones = wait.Until((d) => d.FindElements(By.XPath("//div[@class='product-list-item__left-wrap']")));

            return omledParams.Count == phones.Count;
        }

        public override PageObject OpenPage()
        {
            driver.Navigate().GoToUrl("https://agroup.by/elektronika/smartfony-i-aksessuary/mobilnye-telefony/tip-ekrana-oled-f/");
            return this;
        }
    }
}
