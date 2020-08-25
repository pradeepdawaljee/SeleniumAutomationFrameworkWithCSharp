using AutomationFramework.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using SUT_UnitTestProject.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUT_UnitTestProject.Tests
{
    public class SmokeTest
    {

        [TestMethod]
        public void Testcase()
        {

            Console.WriteLine("Starting First Testcase execution");

            DriverContext.Driver = new ChromeDriver();

            DriverContext.Driver.Navigate().GoToUrl("");

            StartPage startPage = new StartPage();

            LoginPage loginPage=startPage.ClickLoginLink();

            loginPage.LoginToApplication("Username", "Password");



        }


    }
}
