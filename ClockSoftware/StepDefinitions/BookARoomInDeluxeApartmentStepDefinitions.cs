using ClockSoftware.Drivers;
using ClockSoftware.Pages;
using NUnit.Framework;
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
        HomePage homePage;
        RoomSelectionPage roomSelectionPage;
        ExtraServicesPage extraServicesPage;
        ContactDetailsPage contactDetailsPage;
        PaymentPage paymentPage;
        String arrival_date="";
        IWebDriver driver;
        public BookARoomInDeluxeApartmentStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            driver = _scenarioContext.Get<BrowserDrivers>("DriverManager").GetWebDriver();
            homePage = new HomePage(driver);
            roomSelectionPage = new RoomSelectionPage(driver);
            extraServicesPage = new ExtraServicesPage(driver);
            contactDetailsPage = new ContactDetailsPage(driver);
            paymentPage = new PaymentPage(driver);
        }

        [Given(@"I am on homepage")]
        public void GivenIAmOnHomepage()
        {
            driver.Url = "https://www.clock-software.com/demo-clockpms/index.html";
        }

        [When(@"Select a valid date and number of nights and click book now")]
        public void WhenSelectAValidDateAndNumberOfNightsAndClickBookNow()
        {
          
            homePage.enter_Arrival_Date();
            homePage.enter_Number_Of_Nights("4");
            homePage.click_Book_Now();
        }

        [When(@"Under Deluxe Apartment select the most expensive package")]
        public void WhenUnderDeluxeApartmentSelectTheMostExpensivePackage()
        {
            arrival_date = roomSelectionPage.bookDeluxeApartment();

        }

        [When(@"Select any two add ons")]
        public void WhenSelectAnyTwoAddOns()
        {
            extraServicesPage.select_two_addons();
        }

        [Then(@"Validate all details - Date, no of nights, room type, rate, add on \(extra services charges\), total")]
        public void ThenValidateAllDetails_DateNoOfNightsRoomTypeRateAddOnExtraServicesChargesTotal()
        {
            Assert.AreEqual(arrival_date,contactDetailsPage.arrival_date() );
            Assert.AreEqual("4",contactDetailsPage.no_of_nights());
            Assert.AreEqual("Deluxe Appartment",contactDetailsPage.room_type());
            Assert.AreEqual("Rack Rate Standard Max +",contactDetailsPage.rate());
            Assert.AreEqual("75.00 EUR",contactDetailsPage.addon() );
            Assert.AreEqual(Convert.ToString(roomSelectionPage.highest_value + 75.0),Convert.ToString(contactDetailsPage.total()));

        }

        [Then(@"Add traveler details and payment method to CC")]
        public void ThenAddTravelerDetailsAndPaymentMethodToCC()
        {
            contactDetailsPage.enter_user_details_and_create_booking();
        }

        [Then(@"Use a dummy Visa CC and complete payment")]
        public void ThenUseADummyVisaCCAndCompletePayment()
        {
            paymentPage.enterPaymentDetails();
        }

        [Then(@"Validate Booking complete msg")]
        public void ThenValidateBookingCompleteMsg()
        {
            Assert.AreEqual(paymentPage.bookingMsg(), "Check your e-mail for booking confirmation.");
        }
    }
}
