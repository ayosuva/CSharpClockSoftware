using AngleSharp.Dom;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;
using System.Collections;

namespace ClockSoftware.Pages 
{
    public class RoomSelectionPage : PageBase
    {
        IWebDriver driver;
        public RoomSelectionPage(Drivers.DriverManager driver) : base(driver)
        {
            this.driver = driver.GetDriver();
        }

        By label_room_types = By.XPath("//div[contains(@class,'bookable-container bookable-location')]//h2");
        By btn_Check_availability_calendar = By.XPath("//a[contains(text(),'Check availability calendar')]");
        By label_Dates = By.XPath("//h4[contains(text(),'Deluxe Appartment')]/../../following-sibling::div[1]//a[contains(@class,'list-group-item list-group-item')]");
        By btn_Next_Page = By.XPath("//div[@class='icon-double-angle-right']");
        By btn_search_For_Available_Rooms = By.XPath("//input[@value='Search for available rooms']");
        By label_selected_Date = By.XPath("//div[@class='h2 text-center']");
        By label_price = By.XPath("//h2[contains(text(),'Deluxe Appartment')]/../../following-sibling::div[1]//tr[@class='room-type']//td[@class='text-right hidden-xs']//*[contains(text(),'EUR')]");
        By btn_Select = By.XPath("//span[@class='pull-right']//a[@class='btn btn-success ']//i");
        By label_from_date_period = By.XPath("//input[@id='form_period_from_date']");
        String iframe_id = "clock_pms_iframe_1";
        public Double highest_value;

        

        public String bookDeluxeApartment()
        {
            driver.SwitchTo().Frame(iframe_id);
            IList<IWebElement> room_types = driver.FindElements(label_room_types);
            String room_type = "";
            String date = "";
            foreach (IWebElement element in room_types)
            {
                room_type = room_type + element.Text;
            }
            if (!room_type.Contains("Deluxe Appartment"))
            {
                getWebElementVisible(btn_Check_availability_calendar).Click();
                int numberOfNights = 0;
                IList<IWebElement> list_dates_availability;
                while (numberOfNights <= 3)
                {
                    list_dates_availability = getWebElementsVisible(label_Dates);
                    for (int i = 0; i < list_dates_availability.Count; i++)
                    {
                        String class_attribute = "";
                        try
                        {
                            class_attribute = list_dates_availability[i].GetAttribute("class");
                        }
                        catch (StaleElementReferenceException e)
                        {
                        }

                        if (class_attribute.Contains("danger"))
                        {
                            numberOfNights = 0;
                        }
                        else
                        {
                            numberOfNights += 1;
                        }
                        if (numberOfNights == 4)
                        {
                            list_dates_availability[i - 3].Click();
                            break;
                        }
                    }
                    if (numberOfNights != 4)
                    {
                        String current_Date = driver.FindElement(label_from_date_period).GetAttribute("value");
                        String next_date = getDateWithFormat("dd MMM yyyy", current_Date, 12);
                        retryClick(btn_Next_Page);
                        WebDriverWait wait = new WebDriverWait(driver, timeout: TimeSpan.FromSeconds(20))
                        {
                            PollingInterval = TimeSpan.FromSeconds(1),
                        };
                        wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
                        wait.Until(ExpectedConditions.ElementExists(By.XPath("//input[@id='form_period_from_date' and @value='"+next_date+"']")));
                 }
                 else{
                     getWebElementVisible(btn_search_For_Available_Rooms).Click();
                     break;
                 }


                numberOfNights = 0;
             }
             date = select_Highest_Price_Deluxe_Apartment();
         }
         else
        {
            date = select_Highest_Price_Deluxe_Apartment();

        }
        return date;
    }   

    public String select_Highest_Price_Deluxe_Apartment()
    {
    waitForElementToLoad();
    String arrival_date = getWebElementVisible(label_selected_Date).Text.Split(" - ")[0];
    DateTime _date = Convert.ToDateTime(arrival_date);
    String date=_date.ToString("dd MMM yyyy");
            

    IList<IWebElement> list_prices = driver.FindElements(label_price);
    var  list_prices_values = new List<double>();
    foreach (IWebElement price in list_prices) {
    list_prices_values.Add(Convert.ToDouble(price.Text.Split(" ")[0].Replace(",", "")));
    }
    highest_value = list_prices_values.Max();
    IList<IWebElement> list_select_button = driver.FindElements(btn_Select);
    for (int i = 0; i < list_prices.Count; i++)
    {
        if (Convert.ToDouble(list_prices[i].Text.Split(" ")[0].Replace(",", "")) == highest_value)
        {
                    list_select_button[i].Click();
        }
    }
    return date;
    }
    }
}
