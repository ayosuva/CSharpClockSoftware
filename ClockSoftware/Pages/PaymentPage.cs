using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;

namespace ClockSoftware.Pages
{
    public class PaymentPage: PageBase
    {
        public PaymentPage(Drivers.DriverManager driver) : base(driver)
        {
        }
        By input_CardNumber = By.XPath("//input[@id='cardNumber']");
        By dropdown_cardTypes = By.XPath("//select[@id='credit_card_collect_purchase_brand']");
        By dropdown_expiryMonth = By.XPath("//select[@id='cardExpirationMonth']");
        By dropdown_expiryYear = By.XPath("//select[@id='cardExpirationYear']");
        By input_address = By.XPath("//input[@id='credit_card_collect_purchase_address']");
        By input_zip = By.XPath("//input[@id='credit_card_collect_purchase_zip']");
        By input_city = By.XPath("//input[@id='credit_card_collect_purchase_city']");
        By input_state = By.XPath("//input[@id='credit_card_collect_purchase_state']");
        By dropdown_country = By.XPath("//select[@id='credit_card_collect_purchase_country']");
        By btn_confirm = By.XPath("//button[@class='btn btn-success btn-lg btn-block']");
        By bookingConfirmationMsg = By.XPath("//h3[text()='Check your e-mail for booking confirmation.']");

        

        public void enterPaymentDetails()
        {
            getWebElementVisible(input_CardNumber).SendKeys("4444333322221111");
            var cardType = new SelectElement(getWebElementVisible(dropdown_cardTypes));
            cardType.SelectByText("VISA");
            var expiryMonth = new SelectElement(getWebElementVisible(dropdown_expiryMonth));
            expiryMonth.SelectByText("09");
            var expiryYear = new SelectElement(getWebElementVisible(dropdown_expiryYear));
            expiryYear.SelectByText("2024");
            getWebElementVisible(input_address).SendKeys("Flat");
            getWebElementVisible(input_zip).SendKeys("GL1 1QX");
            getWebElementVisible(input_city).SendKeys("City");
            getWebElementVisible(input_state).SendKeys("State");
            var country = new SelectElement(getWebElementVisible(dropdown_country));
            country.SelectByText("United Kingdom");
            getWebElementVisible(btn_confirm).Click();
        }
        public String bookingMsg()
        {
            return getWebElementVisible(bookingConfirmationMsg).Text;
        }
    }
}
