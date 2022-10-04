using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;

namespace ClockSoftware.Pages
{
    public class HomePage : PageBase
    {
        

        By input_Arrival_Date = By.XPath("//input[@id='date-start']");
        By input_Number_Of_Nights = By.XPath("//input[@id='to-place']");
        By btn_Book_Now = By.XPath("//input[@value='Book now !']");

        public HomePage(IWebDriver driver) : base(driver)
        {

        }

        public void enter_Arrival_Date()
        {
            String date =DateTime.Now.ToString("dd-MM-yyyy");
            getWebElementVisible(input_Arrival_Date).SendKeys(date);
        }

        public void enter_Number_Of_Nights(String numberOfNights)
        {
            getWebElementVisible(input_Number_Of_Nights).Clear();
            getWebElementVisible(input_Number_Of_Nights).SendKeys(numberOfNights);
        }

        public void click_Book_Now()
        {
            getWebElementVisible(btn_Book_Now).Click();
        }

    }
}
