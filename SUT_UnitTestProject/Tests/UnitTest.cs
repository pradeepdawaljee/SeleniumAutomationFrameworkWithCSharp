using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using AutomationFramework.Base;
using SUT_UnitTestProject.Pages;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using AutomationFramework.Helpers;
using AutomationFramework.Config;

namespace SUT_UnitTestProject.Tests
{
    /// <summary>
    /// Summary description for UnitTest
    /// </summary>
    [TestClass]
    public class UnitTest : HookInitialize
    {
        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        //string url = "http://demowebshop.tricentis.com/";

        

        [TestMethod]
        public void TestMethod1()
        {


            //ExcelHelpers.PopulateInCollection(@"C:\\MyStuff\\Work\\C#\\Projects\\AutomationFrameworkSolution\\SeleniumAutomationFrameworkSolution\\SUT_UnitTestProject\\Data\\TestData.xlsx", "sheet1");

            ExcelHelpers excelHelpers = new ExcelHelpers();

            excelHelpers.PopulateInCollection(@"C:\\MyStuff\\Work\\C#\\Projects\\AutomationFrameworkSolution\\SeleniumAutomationFrameworkSolution\\SUT_UnitTestProject\\Data\\TestData.xlsx", "loginsheet");

            string username=excelHelpers.ReadData(2, "Username");

            string password=excelHelpers.ReadData(2, "Password");


            excelHelpers.PopulateInCollection(@"C:\\MyStuff\\Work\\C#\\Projects\\AutomationFrameworkSolution\\SeleniumAutomationFrameworkSolution\\SUT_UnitTestProject\\Data\\TestData.xlsx", "RegisterationSheet");

            string firstName = excelHelpers.ReadData(2, "FirstName");

            string lastName = excelHelpers.ReadData(2, "LastName");

            Console.WriteLine("Starting First Testcase execution");

            LogHelpers.WriteLine("Starting First Testcase execution");            
            
            CurrentPage=GetInstance<StartPage>();

            CurrentPage=CurrentPage.AS<StartPage>().ClickLoginLink();

            CurrentPage.AS<LoginPage>().CheckIfLoginPageExists();

            CurrentPage.AS<LoginPage>().LoginToApplication(username, password);

            CurrentPage = CurrentPage.AS<LoginPage>().ClickOnRegisterButton();

            CurrentPage.AS<RegisterationPage>().EnterFirstName(firstName);

            CurrentPage.AS<RegisterationPage>().EnterLastName(lastName);

            CurrentPage.AS<RegisterationPage>().ClickOnRegisterButton();                       

            Console.WriteLine("First Testcase execution completed.");

            LogHelpers.WriteLine("First Testcase execution completed.");

            Console.WriteLine("Check Logs @ " + Settings.LogPath);
        }

        public void CodeBeforeModification1()
        {

            DriverContext.Driver = new ChromeDriver();

            DriverContext.Driver.Navigate().GoToUrl("http://demowebshop.tricentis.com/");

            StartPage startPage = new StartPage();

            LoginPage loginPage = startPage.ClickLoginLink();

            loginPage.LoginToApplication("Username", "Password");

            RegisterationPage registerationPage = loginPage.ClickOnRegisterButton();

            registerationPage.EnterFirstName("FirstName");

            registerationPage.EnterLastName("LastName");

            registerationPage.ClickOnRegisterButton();

        }

        public void CodeBeforeModification2()
        {

            DriverContext.Driver = new ChromeDriver();

            DriverContext.Driver.Navigate().GoToUrl("http://demowebshop.tricentis.com/");

            StartPage startPage = new StartPage();

            CurrentPage = startPage.ClickLoginLink();

            ((LoginPage)CurrentPage).LoginToApplication("Username", "Password");

            CurrentPage = ((LoginPage)CurrentPage).ClickOnRegisterButton();

            ((RegisterationPage)CurrentPage).EnterFirstName("FirstName");

            ((RegisterationPage)CurrentPage).EnterLastName("Lastname");

            ((RegisterationPage)CurrentPage).ClickOnRegisterButton();

        }

    }

}
