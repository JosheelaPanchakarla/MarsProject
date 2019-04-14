using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class SpecFlowFeature1Steps : Utils.Start
    {
        [Given(@"I clicked on the Language tab under Profile page")]
        public void GivenIClickedOnTheLanguageTabUnderProfilePage()
        {
            //Wait
            Thread.Sleep(1500);
       
            // Click on Profile tab
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[2]")).Click();
                        
        }
        
        [When(@"I add a new language")]
        public void WhenIAddANewLanguage()
        {
            //Click on Add New button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div")).Click();

            //Add Language
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input")).SendKeys("English");

            //Click on Language Level
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select")).Click();

            //Choose the language level
            IWebElement Lang = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option"))[1];
            Lang.Click();

            //Click on Add button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]")).Click();

        }

        [Then(@"that language should be displayed on my listings")]
        public void ThenThatLanguageShouldBeDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a New Language");

                Thread.Sleep(1000);
                string ExpectedValue = "English";
                string ActualValue = Driver.driver.FindElement(By.XPath("//td[text()='English']")).Text;                                                                         
                Thread.Sleep(500);                                        
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Language Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageAdded");
                }

                else
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed Language could not be added");

            }
            catch(Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed",e.Message);
            }           

        }

        [When(@"I cancel adding a new language")]
        public void WhenICancelAddingANewLanguage()
        {
            //Click on Add New button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div")).Click();
            Thread.Sleep(500);
            //Add Language
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input")).SendKeys("English");

            //Click on Language Level
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select")).Click();

            //Choose the language level
            IWebElement Lang = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option"))[1];
            Lang.Click();
            Thread.Sleep(1000);
            //Click on Cancel button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[2]")).Click();
            
        }

        [Then(@"that language should not be displayed on my listings")]
        public void ThenThatLanguageShouldNotBeDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Language should not be added to the Listings");

                string ExpectedLang = "English";
                bool Flag = false;
                IList<IWebElement> rows = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]"));
                Thread.Sleep(500);
                Console.WriteLine("Rows count is :" + rows.Count);

                for (int i = 0; i < rows.Count; i++)
                {
                    if (ExpectedLang == rows[i].Text)
                    {
                        Flag = true;
                        break;
                    }
                    else
                        Flag = false;
                    Console.WriteLine("Iteration" + i);
                }

                if (Flag == true)
                {
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed as the Language is present in the table.");

                }
                else
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, as the Language is not in the listing");
                SaveScreenShotClass.SaveScreenshot(Driver.driver, " Language should not be found");
            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }

        [When(@"I add the same language and same level")]
        public void WhenIAddTheSameLanguageAndSameLevel()
        {
            Thread.Sleep(2000);
            //Click on Add New button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div")).Click();

            Thread.Sleep(2000);
            //Add Language
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input")).SendKeys("English");
            Thread.Sleep(2000);
            //Click on Language Level
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select")).Click();
            Thread.Sleep(2000);
            //Choose the language level
            IWebElement Lang = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option"))[1];
            Lang.Click();

            //Click on Add button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]")).Click();

        }

        [Then(@"I should able to get an error message ""(.*)""")]
        public void ThenIShouldAbleToGetAnErrorMessage(string p)
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a same Language which already exist");

                Thread.Sleep(1000);
                string ExpectedValue = "This language is already exist in your language list.";
                string ActualValue = Driver.driver.FindElement(By.XPath("/html/body/div[1]/div")).Text;
                Thread.Sleep(2000);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Have shown the message that language is already exist");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "Laguage already Exist");
                }

                else
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed, as the language is added" + ActualValue);

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }

        [When(@"I add the same language and different level")]
        public void WhenIAddTheSameLanguageAndDifferentLevel()
        {
            Thread.Sleep(2000);
            //Click on Add New button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div")).Click();
            Thread.Sleep(500);
            //Add Language
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input")).SendKeys("English");
            Thread.Sleep(1000);
            //Click on Language Level
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select")).Click();

            //Choose the language level
            IWebElement Lang = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option"))[3];
            Lang.Click();

            //Click on Add button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]")).Click();

        }

        [Then(@"I should able to get an information message ""(.*)""")]
        public void ThenIShouldAbleToGetAnInformationMessage(string p0)
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Duplicate data");

                Thread.Sleep(1000);
                string ExpectedValue = "Duplicated data";
                string ActualValue = Driver.driver.FindElement(By.XPath("/html/body/div[1]/div")).Text;
                Thread.Sleep(2000);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Have shown the message that its a Duplicate data");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "Duplicated data");
                }

                else
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed, as the language is Duplicated" + ActualValue);

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }

        }

        [When(@"I add 4 new Languages")]
        public void WhenIAddNewLanguages(Table table)
        {
            var details = table.CreateSet<LanguageDetails>();
            foreach(LanguageDetails lang in details)
            {
                Thread.Sleep(2000);
                //Click on Add New button
                Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div")).Click();
                                                    
                //Add Language
                Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input")).SendKeys(lang.Language);

                //Enter Level
                Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select")).SendKeys(lang.Level);

                //Click on Add button
                Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]")).Click();

            }

        }

        [Then(@"the add New button should be invisible")]
        public void ThenTheAddNewButtonShouldBeInvisible()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Maximum of 4 Languages only");

                Thread.Sleep(1000);
                string xpathofAddnewbutton = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div";
                if (!ElementVisible(driver, "XPath", xpathofAddnewbutton))
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Add New button was invisible after adding maximum of 4 languages");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "No Add new Button after Maximum Languges are added");
                }

                else
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed As the New button is still visible after maximum languages are added");

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }

        }

        [When(@"I add a new language by not entering one of the fields (.*) and (.*)")]
        public void WhenIAddANewLanguageByNotEnteringOneOfTheFieldsEnglish(string Language, string Level)
        {
            Thread.Sleep(1000);
            //Click on Add New button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div")).Click();

            //Add Language
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input")).SendKeys(Language);

            //Enter Level
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select")).SendKeys(Level);

            //Click on Add button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]")).Click();
        }

        [Then(@"there should be a pop up Please enter language and level")]
        public void ThenThereShouldBeAPopUpPleaseEnterLanguageAndLevel()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Language by missing a field");

                Thread.Sleep(1000);
                string ExpectedValue = "Please enter language and level";
                string ActualValue = Driver.driver.FindElement(By.XPath("/html/body/div[1]/div")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Have shown a message Please enter language and level");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "Please enter language and level message displayed");
                }

                else
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed Could not match with message" + ActualValue);

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }

        }

        [When(@"Try to Edit the Language and update")]
        public void WhenTryToEditTheLanguageAndUpdate()
        {
            Thread.Sleep(2000);
            //Find English from the list and click update
            driver.FindElement(By.XPath("//td[text()='English']/parent::tr//following-sibling::td[2]/child::span/child::i")).Click();

            IWebElement edit = driver.FindElement(By.XPath("//input[@value='English']"));
                edit.Clear();
            Thread.Sleep(500);
            edit.SendKeys("EnglishNew");                                                                            
            driver.FindElement(By.XPath("//input[@value='Update']")).Click();
                                         

        }

        [Then(@"that new language should be displayed on my listings")]
        public void ThenThatNewLanguageShouldBeDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Update an Existing language");

                Thread.Sleep(1000);
                string ExpectedValue = "EnglishNew";
                string ActualValue = Driver.driver.FindElement(By.XPath("//td[text()='EnglishNew']")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Successfully Updated a Language");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageUpdated");
                }

                else
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed Language update failed" + ActualValue);

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }

        [When(@"I try to click on Edit and click on cancel button")]
        public void WhenITryToClickOnEditAndClickOnCancelButton()
        {
            Thread.Sleep(2000);
            //Find English from the list and click update
            driver.FindElement(By.XPath("//td[text()='English']/parent::tr//following-sibling::td[2]/child::span/child::i")).Click();

            IWebElement edit = driver.FindElement(By.XPath("//input[@value='English']"));
            edit.Clear();
            Thread.Sleep(500);
            edit.SendKeys("NewLanguage");
            driver.FindElement(By.XPath("//input[@value='Cancel']")).Click();
        }

        [Then(@"that same language should be displayed on my listings")]
        public void ThenThatSameLanguageShouldBeDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Cancel an Editing of a Language");

                Thread.Sleep(1000);
                string ExpectedValue = "English";
                string ActualValue = Driver.driver.FindElement(By.XPath("//td[text()='English']")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Cancelled an Editing of a Language Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "Language Editing Cancelled");
                }

                else
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed as it could not cancel the editing" + ActualValue);

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }

        [When(@"Try not to Edit anything and click on update")]
        public void WhenTryNotToEditAnythingAndClickOnUpdate()
        {
            Thread.Sleep(2000);
            //Find English from the list and click update
            driver.FindElement(By.XPath("//td[text()='English']/parent::tr//following-sibling::td[2]/child::span/child::i")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//input[@value='Update']")).Click();
            Thread.Sleep(1000);
        }

        [Then(@"I should able to get an error message that ""(.*)""")]
        public void ThenIShouldAbleToGetAnErrorMessageThat(string p0)
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Update without edting any input");

                Thread.Sleep(1000);
                string ExpectedValue = "This language is already added to your language list.";
                string ActualValue = Driver.driver.FindElement(By.XPath("/html/body/div[1]/div")).Text;
                Thread.Sleep(2000);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Have shown the message that language is already added");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "Cannot Update to the same language");
                }

                else
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed, as the language is added" + ActualValue);

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }

        [When(@"Try to Delete the Language")]
        public void WhenTryToDeleteTheLanguage()
        {
            Thread.Sleep(2000);
            //Find English from the list and click update
            driver.FindElement(By.XPath("//td[text()='English']/parent::tr//following-sibling::td[2]/child::span[2]/child::i")).Click();

        }

        

    }

}


