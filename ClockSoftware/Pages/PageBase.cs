﻿using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using SeleniumExtras.WaitHelpers;
using ClockSoftware.Drivers;

namespace ClockSoftware.Pages
{
    public class PageBase
    {
        IWebDriver driver;

        public PageBase(Drivers.DriverManager driver)
        {
            this.driver = driver.GetDriver();
        }

        public IWebElement getWebElementVisible(By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(ExpectedConditions.ElementExists(by));
        }

        public IList<IWebElement> getWebElementsVisible(By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(by));
        }

        public void waitForElementToLoad()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(wd => js.ExecuteScript("return document.readyState").ToString() == "complete");
        }

        public Boolean retryClick(By by)
        {
            Boolean result = false;
            int attempts = 0;
            while (attempts < 2)
            {
                try
                {
                    driver.FindElement(by).Click();
                    result = true;
                    break;
                }
                catch (StaleElementReferenceException e)
                {
                    Console.WriteLine("StaleElementReferenceException caught. Going to Retry"+e.GetType());
                }
                attempts++;
            }
            return result;
        }

        public String getDateWithFormat(String format, String _date, int numberOfDaysToBeAdded)
        {
            DateTime date = Convert.ToDateTime(_date);
            date.AddDays(numberOfDaysToBeAdded);


            return date.AddDays(numberOfDaysToBeAdded).ToString(format);
        }
        public string ScreenshotAsBase64String()
        {
            Screenshot screenshot = (driver as ITakesScreenshot).GetScreenshot();
            return Convert.ToBase64String (screenshot.AsByteArray);
        }
    }
}
