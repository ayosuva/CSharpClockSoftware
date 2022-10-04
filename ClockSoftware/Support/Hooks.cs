using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using ClockSoftware.Drivers;
using ClockSoftware.Pages;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.Support
{
    [Binding]
    public sealed class Hooks
    {
        private readonly ScenarioContext _scenarioContext;
        static AventStack.ExtentReports.ExtentReports extent;
        static AventStack.ExtentReports.ExtentTest feature;
        AventStack.ExtentReports.ExtentTest scenario,step;
        static string reportPath = Directory.GetParent(@"../../../").FullName
            + Path.DirectorySeparatorChar + "Result"
            + Path.DirectorySeparatorChar + "Html_Report_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss")+"\\";
        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            ExtentHtmlReporter htmlReport = new ExtentHtmlReporter(reportPath);
            extent = new AventStack.ExtentReports.ExtentReports();
            extent.AttachReporter(htmlReport);
        }
        [BeforeFeature]
        public static void BeforeFeature(FeatureContext context)
        {
            feature = extent.CreateTest(context.FeatureInfo.Title);
        }


        [BeforeScenario]
        public void BeforeScenario(ScenarioContext context)
        {
            scenario = feature.CreateNode(context.ScenarioInfo.Title);
            BrowserDrivers driverManager = new BrowserDrivers(_scenarioContext);
            _scenarioContext.Set(driverManager, "DriverManager");

        }
        [BeforeStep]
        public void BeforeStep()
        {
            step = scenario;
        }

        [AfterStep]
        public void AfterStep(ScenarioContext context)
        {
            PageBase pageBase = new PageBase(_scenarioContext.Get<IWebDriver>("WebDriver"));
            if (context.TestError == null)
            {
                step.Log(Status.Pass, context.StepContext.StepInfo.Text, MediaEntityBuilder.CreateScreenCaptureFromBase64String(pageBase.ScreenshotAsBase64String()).Build());
            }
            else if (context.TestError != null) {
                step.Log(Status.Fail, context.StepContext.StepInfo.Text, MediaEntityBuilder.CreateScreenCaptureFromBase64String(pageBase.ScreenshotAsBase64String()).Build());
            }
        }


        [AfterScenario]
        public void AfterScenario()
        {
            _scenarioContext.Get<IWebDriver>("WebDriver").Quit();
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            extent.Flush();
        }
    }
}