using AutomationFramework.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using AutomationFramework.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUT_UnitTestProject.Pages
{
    class LoginPage : BasePage
    {

        [FindsBy(How = How.Id, Using = "Email")]
        private IWebElement txtUsername { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input#Password")]
        private IWebElement txtPassword { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@value='Log in']")]
        private IWebElement btnLogin { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@value='Register']")]
        private IWebElement btnRegister { get; set; }

        internal void CheckIfLoginPageExists()
        {
            txtUsername.AssertElementPresent();
        }

        public HomePage LoginToApplication(string Username,string Password)
        {

            txtUsername.SendKeys(Username);
            txtPassword.SendKeys(Password);
            btnLogin.ClickAndWaitForPageToLoad();
            //return new HomePage(); // Even this works, If BasePage has PageFactory Init
            return GetInstance<HomePage>();

        }

        public RegisterationPage ClickOnRegisterButton()
        {
            btnRegister.ClickAndWaitForPageToLoad();
            //return new RegisterationPage();// Even this works, If BasePage has PageFactory Init
            return GetInstance<RegisterationPage>();
        }


    }
}
