using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;

namespace ClockSoftware.Pages
{
    public class ExtraServicesPage : PageBase
    {
    

    By input_Airport_Transfer_AddOn = By.XPath("//*[contains(text(),'Airport')]/../following-sibling::div/input");
    By input_Business_Services_AddOn = By.XPath("//*[contains(text(),'Business')]/../following-sibling::div/input");
    By btn_Add_Selected_Service = By.XPath("//input[@value='Add the selected services >>']");

        public ExtraServicesPage(IWebDriver driver) : base(driver)
        {
        }

        public void select_two_addons()
    {
        getWebElementVisible(input_Airport_Transfer_AddOn).SendKeys("1");
        getWebElementVisible(input_Business_Services_AddOn).SendKeys("1");
        getWebElementVisible(btn_Add_Selected_Service).Click();
    }

}
}
