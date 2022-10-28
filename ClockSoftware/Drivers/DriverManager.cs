using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;

namespace ClockSoftware.Drivers
{
    public class DriverManager
    {
        private IWebDriver? driver ;

        public IWebDriver GetDriver()
        {
            if (driver == null)
            {
                new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
            }            
            return driver;
        }
    }
}
