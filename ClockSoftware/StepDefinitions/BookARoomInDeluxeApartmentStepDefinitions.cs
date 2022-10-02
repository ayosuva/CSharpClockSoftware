using OpenQA.Selenium;
using SpecFlowProject1.Support;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class BookARoomInDeluxeApartmentStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        IWebDriver driver;
        public BookARoomInDeluxeApartmentStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I am on homepage")]
        public void GivenIAmOnHomepage()
        {
            driver = _scenarioContext.Get<DriverManager>("DriverManager").GetWebDriver();
            driver.Url = "https://www.clock-software.com/demo-clockpms/index.html";
        }

        [When(@"Select a valid date and number of nights and click book now")]
        public void WhenSelectAValidDateAndNumberOfNightsAndClickBookNow()
        {
            Console.WriteLine("To be implemented");
        }

        [When(@"Under Deluxe Apartment select the most expensive package")]
        public void WhenUnderDeluxeApartmentSelectTheMostExpensivePackage()
        {
            Console.WriteLine("To be implemented");
        }

        [When(@"Select any two add ons")]
        public void WhenSelectAnyTwoAddOns()
        {
            Console.WriteLine("To be implemented");
        }

        [Then(@"Validate all details - Date, no of nights, room type, rate, add on \(extra services charges\), total")]
        public void ThenValidateAllDetails_DateNoOfNightsRoomTypeRateAddOnExtraServicesChargesTotal()
        {
            Console.WriteLine("To be implemented");
        }

        [Then(@"Add traveler details and payment method to CC")]
        public void ThenAddTravelerDetailsAndPaymentMethodToCC()
        {
            Console.WriteLine("To be implemented");
        }

        [Then(@"Use a dummy Visa CC and complete payment")]
        public void ThenUseADummyVisaCCAndCompletePayment()
        {
            Console.WriteLine("To be implemented");
        }

        [Then(@"Validate Booking complete msg")]
        public void ThenValidateBookingCompleteMsg()
        {
            Console.WriteLine("To be implemented");
        }
    }
}
