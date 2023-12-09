using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace TestAgroup.Driver
{
    public static class DriverSingletone
    {
        private static WebDriver _instance;

        public static WebDriver GetDriver(string Browser)
        {
            if (_instance == null)
            {
                switch (Browser.ToLower())
                {
                    case "firefox":
                        {
                            new DriverManager().SetUpDriver(new FirefoxConfig());
                            _instance = new FirefoxDriver();
                            break;
                        }
                    case "chrome":
                        {
                            new DriverManager().SetUpDriver(new ChromeConfig());
                            _instance = new ChromeDriver();
                            break;
                        }
                    case "edge":
                        {
                            new DriverManager().SetUpDriver(new EdgeConfig());
                            _instance = new EdgeDriver();
                            break;
                        }
                    default: break;
                }
            }
            return _instance;
        }
        public static void CloseDriver()
        {
            _instance.Quit();
            _instance = null;
        }

    }
}
