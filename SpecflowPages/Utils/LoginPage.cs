﻿using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static SpecflowPages.CommonMethods;

namespace SpecflowPages.Utils
{
  public class LoginPage
    {
        public static void LoginStep()
        {
            Driver.NavigateUrl();
            Thread.Sleep(2000);

            //Enter Url
            Driver.driver.FindElement(By.XPath("//*[@id='home']/div/div/div[1]/div/a")).Click();
            //*[@id="home"]/div/div/div[1]/div/a

            //Enter Username
            Driver.driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input")).SendKeys("josheela_89@yahoo.com");
            
            //Enter password
            Driver.driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input")).SendKeys("123123");
            Thread.Sleep(1000);
            //Click on Login Button
            Driver.driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button")).Click();

            //string msg = "Add New Job";
            //string Actualmsg = Driver.driver.FindElement(By.XPath("//*[@id='addnewjob']")).Text;

            //if (msg == Actualmsg)
            //{
                //Console.WriteLine("Test Passed");
                //CommonMethods.ExtentReports();
                //Thread.Sleep(500);
                //test = CommonMethods.extent.StartTest("Login with valid data");
                //Thread.Sleep(1000);
                //CommonMethods.test.Log(LogStatus.Pass, "Test Passed");
                //SaveScreenShotClass.SaveScreenshot(Driver.driver, "HomePage");
            //}
            //else
            //{
                //Console.WriteLine("Test Failed");
                //CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
            //}
        }

    }
}
