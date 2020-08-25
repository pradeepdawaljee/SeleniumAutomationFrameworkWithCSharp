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
    class RegisterationPage : BasePage
    {

        [FindsBy(How=How.Id,Using = "FirstName")]
        IWebElement txtFirstName { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input#LastName")]
        IWebElement txtLastName { get; set; }        

        [FindsBy(How = How.XPath, Using = "//*[@value='Register']")]
        IWebElement btnRegister { get; set; }


        public void EnterFirstName(string FirstName)
        {
            txtFirstName.SendKeys(FirstName); //Example for Select custom method written : txtFirstName.SelectValueFromDropdownList("gender");
        }

        public void EnterLastName(string LastName)
        {
            txtLastName.SendKeys(LastName);
        }

        public void ClickOnRegisterButton()
        {
            btnRegister.ClickAndWaitForPageToLoad();
        }


    }
}
