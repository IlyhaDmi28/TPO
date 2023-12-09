using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAgroup.Pages
{
    public abstract class PageObject
    {
        protected WebDriver driver;

        public PageObject(WebDriver driver)
        {
            this.driver = driver;
        }

        public abstract void OpenPage();
    }
}
