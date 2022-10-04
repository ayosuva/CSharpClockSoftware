using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;

namespace ClockSoftware.Pages
{
    public class ContactDetailsPage : PageBase
    {

    public ContactDetailsPage(IWebDriver driver): base(driver)
    {
    
    }

    By input_Email = By.XPath("//input[@title='E-mail']");
    By input_LastName = By.XPath("//input[@id='booking_guest_attributes_last_name']");
    By input_FirstName = By.XPath("//input[@id='booking_guest_attributes_first_name']");
    By input_Phone = By.XPath("//input[@id='booking_guest_attributes_phone_number']");
    By radio_CreditCard = By.XPath("//input[@id='booking_payment_service_credit_card_collect']");
    By checkbox_TermsConditions = By.XPath("//input[@title='I agree with the hotel and guarantee policy']");
    By btn_create_Booking = By.XPath("//input[@value='Create Booking']");
    By label_arrival = By.XPath("//*[text()='Arrival']/../following-sibling::div");
    By label_No_of_nights = By.XPath("//*[text()='Stay']/../following-sibling::div");
    By label_Room_type = By.XPath("//*[text()='Room Type']/../following-sibling::div");
    By label_Rate = By.XPath("//*[text()='Rate']/../following-sibling::div");
    By label_Add_on = By.XPath("//*[text()='Extra Services']/../following-sibling::div");
    By label_Total = By.XPath("//div[@class='row total_charges']//*[contains(text(),'EUR')]");

    public void enter_user_details_and_create_booking()
    {
        getWebElementVisible(input_Email).SendKeys("test@testxx.com");
        getWebElementVisible(input_FirstName).SendKeys("Test Name");
        getWebElementVisible(input_LastName).SendKeys("Test Last Name");
        getWebElementVisible(input_Phone).SendKeys("1234567890");
        getWebElementVisible(radio_CreditCard).Click();
        getWebElementVisible(checkbox_TermsConditions).Click();
        getWebElementVisible(btn_create_Booking).Click();

    }

    public String arrival_date()
    {
        return getWebElementVisible(label_arrival).Text;
    }

    public String no_of_nights()
    {
        return getWebElementVisible(label_No_of_nights).Text;
    }

    public String room_type()
    {
        return getWebElementVisible(label_Room_type).Text;
    }

    public String rate()
    {
        return getWebElementVisible(label_Rate).Text;
    }

    public String addon()
    {
        return getWebElementVisible(label_Add_on).Text;
    }

    public Double total()
    {
        return Convert.ToDouble(getWebElementVisible(label_Total).Text.Split(" ")[0].Replace(",", ""));

    }
}
}
