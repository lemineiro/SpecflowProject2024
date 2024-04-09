using OpenQA.Selenium;
using SpecFlowProject2024.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject2024.Pages
{
    public class HomePage
    {
        public void NavigateToTMPage(IWebDriver driver)
        {
            //Click on the Admin dropdown menu and navigate to Time and Material module
            IWebElement administrationDropdwon = driver.FindElement(By.XPath("//*[contains(text(),'Administration')]"));
            administrationDropdwon.Click();

            Wait.WaitToBeClickable(driver, "XPath", "//a[contains(text(),'Time & Materials')]", 2);

            IWebElement timeAndMaterialOption = driver.FindElement(By.XPath("//a[contains(text(),'Time & Materials')]"));
            timeAndMaterialOption.Click();
            ///html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a
        }

        //public void VerifyLoggedInUser(IWebDriver driver)
        //{
        //    //Check if the user has logged in successfully
        //    IWebElement helloHari = driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));
        //    if (helloHari.Text == "Hello hari!")
        //    {
        //        Console.WriteLine("User has logged in successfully");
        //    }
        //    else
        //    {
        //        Console.WriteLine("User has not logged in");
        //    }
        //}
    }
}
