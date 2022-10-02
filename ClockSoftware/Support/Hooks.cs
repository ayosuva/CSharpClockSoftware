using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.Support
{
    [Binding]
    public sealed class Hooks
    {
        private readonly ScenarioContext _scenarioContext;

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            DriverManager driverManager = new DriverManager(_scenarioContext);
            _scenarioContext.Set(driverManager, "DriverManager");

        }

      

        [AfterScenario]
        public void AfterScenario()
        {
            _scenarioContext.Get<IWebDriver>("WebDriver").Quit();
        }
    }
}