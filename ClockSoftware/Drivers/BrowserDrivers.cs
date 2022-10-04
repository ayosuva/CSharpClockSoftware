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
    public class BrowserDrivers
    {
        private IWebDriver? driver=null ;
        private readonly ScenarioContext _scenarioContext;
        public BrowserDrivers(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        public IWebDriver GetWebDriver()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            //driver = new ChromeDriver("C:\\Yosuva\\CSharpWorkspace\\ClockSoftware\\ClockSoftware\\Drivers\\");
            _scenarioContext.Set(driver, "WebDriver");
            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}
