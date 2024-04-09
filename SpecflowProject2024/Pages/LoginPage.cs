using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SpecFlowProject2024.Pages
{
    public class LoginPage
    {
        private readonly By usernameTextboxLocator = By.Id("UserName");
        IWebElement usernameTextbox;
        private readonly By passwordTextboxLocator = By.Id("Password");
        IWebElement passwordTextbox;
        private readonly By loginButtonLocator = By.XPath("//*[@id='loginForm']/form/div[3]/input[1]");
        IWebElement loginButton;

        public void LoginActions(IWebDriver driver, string username, string password)
        {
            //Open Chrome browser
            
            driver.Manage().Window.Maximize();

            //Launch TurnUp portal and navigate to website login page
            string baseURL = "http://horse.industryconnect.io/";
            driver.Navigate().GoToUrl(baseURL);

            try
            {
                //Identify username textbox and enter valid username
                IWebElement usernameTextbox = driver.FindElement(usernameTextboxLocator);
                usernameTextbox.SendKeys(username);

                //Identify password textbox and enter password
                IWebElement passwordTextbox = driver.FindElement(passwordTextboxLocator);
                passwordTextbox.SendKeys(password);

                //Identify login button and click on Login Button
                IWebElement loginButton = driver.FindElement(loginButtonLocator);
                loginButton.Click();
            }
            catch (Exception)
            {
                Assert.Fail("TurnUp Portal login page did not launch");
                throw;
            }
        }
    }
}
