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
    class StartPage : BasePage
    {


        [FindsBy(How = How.LinkText, Using = "Log in")]
        private IWebElement lnkLogin { get; set; }

        public LoginPage ClickLoginLink()
        {
            lnkLogin.ClickAndWaitForPageToLoad();
            //return new LoginPage(); // Even this works , If BasePage has PageFactory Init
            return GetInstance<LoginPage>();
        }

    }
}
