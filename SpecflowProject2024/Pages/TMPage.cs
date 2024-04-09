using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowProject2024.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject2024.Pages
{
    public class TMPage
    {
        public void CreateTMRecord(IWebDriver driver)
        {
            //Create a new Time record
            //Click on the Create New button
            IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            createNewButton.Click();
            ////a[contains(text(),'Create New')]

            //Select Time on TypeCode
            IWebElement typeCodeMainDropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span"));
            typeCodeMainDropdown.Click();

            Thread.Sleep(2000);

            IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
            typeCodeDropdown.Click();

            //Enter Code
            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.SendKeys("CodeTest");

            //Enter Description
            IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
            descriptionTextbox.SendKeys("DescriptionTest");

            //Enter Price Unit
            IWebElement priceTextbox = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceTextbox.SendKeys("10");

            //Click on Save
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id='tmsGrid']/div[4]/a[4]/span", 10);
        }
        public void CreateTMRecordAssert(IWebDriver driver)
        {
            //Check if the new time record has been created
            IWebElement goToTheLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToTheLastPageButton.Click();

            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]", 2);

            IWebElement newRecordCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement newTypeCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[2]"));
            IWebElement newDescription = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            IWebElement newPrice = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));

            //Option 1 Validation
            Assert.That(newRecordCode.Text == "CodeTest", "New record code and expected code do not match");
            Assert.That(newTypeCode.Text == "T", "New type code and expected type code do not match");
            Assert.That(newDescription.Text == "DescriptionTest", "New description and expected description do not match");
            Assert.That(newPrice.Text == "$10.00", "New price and expected price do not match");

            //Option 2 Validation
            //if (newRecordCode.Text == "CodeTest")
            //{
            //    Assert.Pass("New Time record has been created successfully");
            //}
            //else
            //{
            //    Assert.Fail("Test failed");
            //}
        }
        public void EditTMRecord(IWebDriver driver)
        {
            //Wait until entire TM page is displayed
            //Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]", 2);
            Thread.Sleep(3000);

            //Go to the last page
            IWebElement goToTheLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToTheLastPageButton.Click();

            IWebElement findRecordCreated = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            Console.WriteLine(findRecordCreated.Text);

            if (findRecordCreated.Text == "CodeTest")
            {
                //Click on edit button
                IWebElement editButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
                editButton.Click();
            }
            else 
            {
                Assert.Fail("Record to be edited hasn't been found. Record not edited");
            }

            // Edit Code
            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.Clear();
            codeTextbox.SendKeys("EditedCodeTest");

            // Edit Description
            IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
            descriptionTextbox.Clear();
            descriptionTextbox.SendKeys("EditedDescriptionTest");

            // Edit Price
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]", 3);
            IWebElement priceTag = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            // //*[@id="TimeMaterialEditForm"]/div/div[4]/div/span[1]/span/input[1]
            IWebElement priceTextbox = driver.FindElement(By.Id("Price"));

            priceTag.Click();
            priceTextbox.Clear();
            priceTag.Click();
            priceTextbox.SendKeys("20");

            // Click on save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id='tmsGrid']/div[4]/a[4]/span", 2);
        }

        public void EditTMRecordAssertion(IWebDriver driver)
        {
            // Go to the last page button
            IWebElement goToTheLastPageButton1 = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToTheLastPageButton1.Click();
            Thread.Sleep(1000);

            // Assertion
            IWebElement createdCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement createdTypeCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[2]"));
            IWebElement createdDescription = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            IWebElement createdPrice = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));

            Assert.That(createdCode.Text == "EditedCodeTest", "New record code and expected code do not match");
            Assert.That(createdTypeCode.Text == "T", "New type code and expected type code do not match");
            Assert.That(createdDescription.Text == "EditedDescriptionTest", "New description and expected description do not match");
            Assert.That(createdPrice.Text == "$20.00", "New price and expected price do not match");
        }
        public void DeleteTMRecord(IWebDriver driver)
        {
            //Wait until entire TM page is displayed
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]", 2);

            //Go to the last page
            IWebElement goToTheLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToTheLastPageButton.Click();

            IWebElement findEditedRecord = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            if (findEditedRecord.Text == "EditedCodeTest")
            {
                //Click on delete button
                IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
                deleteButton.Click();
                Thread.Sleep(1000);

                driver.SwitchTo().Alert().Accept();
            }
            else 
            {
                Assert.Fail("Record to be deleted has been found. Record not deleted");
            }

            //Assert that record has been deleted
            driver.Navigate().Refresh();
            Thread.Sleep(1000);
        }
        public void DeleteTMRecordAssertion(IWebDriver driver)
        {
            //Go to the last page
            IWebElement goToTheLastPageButton1 = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToTheLastPageButton1.Click();
            Thread.Sleep(1000);

            // Assertion
            IWebElement editedCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement editedDescription = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            IWebElement editedPrice = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));

            Assert.That(editedCode.Text != "EditedCodeTest", "New record code and expected code do not match");
            Assert.That(editedDescription.Text != "EditedDescriptionTest", "New description and expected description do not match");
            Assert.That(editedPrice.Text != "$20.00", "New price and expected price do not match");
        }
    }
}
