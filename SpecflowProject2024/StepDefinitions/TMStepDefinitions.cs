using OpenQA.Selenium.Chrome;
using SpecFlowProject2024.Pages;
using SpecFlowProject2024.Utilities;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject2024.StepDefinitions
{
    [Binding]
    public class TMStepDefinitions : CommonDriver
    {
        LoginPage loginPageObj = new LoginPage();
        HomePage homePageObj = new HomePage();
        TMPage tMPageObj = new TMPage();

        [BeforeScenario]
        public void LoginFunction()
        {
            driver = new ChromeDriver();
        }

        [AfterScenario]
        public void QuitTestRun()
        {
            driver.Quit();
        }

        [Given(@"user logs into turnup portal")]
        public void GivenUserLogsIntoTurnupPortal()
        {
            //driver = new ChromeDriver();

            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginActions(driver, "hari", "123123");
        }

        [Given(@"user navigates to the TM page")]
        public void GivenUserNavigatesToTheTMPage()
        {
            HomePage homePageObj = new HomePage();
            //homePageObj.VerifyLoggedInUser(driver);
            homePageObj.NavigateToTMPage(driver);
        }

        [When(@"user creates a new TM record")]
        public void WhenUserCreatesANewTMRecord()
        {
            TMPage tMPageObj = new TMPage();
            tMPageObj.CreateTMRecord(driver);
        }

        [Then(@"system should save the new TM record")]
        public void ThenSystemShouldSaveTheNewTMRecord()
        {
            tMPageObj.CreateTMRecordAssert(driver);
            //driver.Quit();
        }
        [When(@"user edits an existing TM record")]
        public void WhenUserEditsAnExistingTMRecord()
        {
            tMPageObj.EditTMRecord(driver);
        }

        [Then(@"system should save the edited TM record")]
        public void ThenSystemShouldSaveTheEditedTMRecord()
        {
            tMPageObj.EditTMRecordAssertion(driver);
        }

        [When(@"user deletes an existing TM record")]
        public void WhenUserDeletesAnExistingTMRecord()
        {
            tMPageObj.DeleteTMRecord(driver);
        }

        [Then(@"system should delete the TM record")]
        public void ThenSystemShouldDeleteTheTMRecord()
        {
            tMPageObj.DeleteTMRecordAssertion(driver);
        }



    }
}
