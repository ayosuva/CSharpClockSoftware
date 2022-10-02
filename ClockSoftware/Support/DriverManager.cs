using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
namespace SpecFlowProject1.Support
{
    public class DriverManager
    {
        private IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;
        public DriverManager(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        public IWebDriver GetWebDriver()
        {

            driver = new ChromeDriver("C:\\Yosuva\\CSharpWorkspace\\ClockSoftware\\ClockSoftware\\Drivers\\");
            _scenarioContext.Set(driver, "WebDriver");
            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}
