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
        DriverManager driverManager;

        static string reportPath = Directory.GetParent(@"../../../").FullName
            + Path.DirectorySeparatorChar + "Reports"
            + Path.DirectorySeparatorChar + "Html_Report_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss")+"\\";
        public Hooks(ScenarioContext scenarioContext, DriverManager context)
        {
            _scenarioContext = scenarioContext;
            this.driverManager = context;

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
            

        }
        [BeforeStep]
        public void BeforeStep()
        {
            step = scenario;
        }

        [AfterStep]
        public void AfterStep(ScenarioContext context)
        {
            PageBase pageBase = new PageBase(driverManager);
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
            driverManager.GetDriver().Quit();
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            extent.Flush();
        }
    }
}