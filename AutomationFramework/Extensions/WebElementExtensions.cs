using AutomationFramework.Base;
using AutomationFramework.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.Extensions
{
    public static class WebElementExtensions
    {

        public static void ClickAndWaitForPageToLoad(this IWebElement element)
        {
            element.Click();
            LogHelpers.WriteLine("Clicked on " + element.Text+" "+element.GetAttribute("value"));
            DriverContext.Driver.WaitForPageToLoad();
        }

        public static string GetSelectedDropdown(this IWebElement element)
        {
            SelectElement oSelect = new SelectElement(element);
            return oSelect.AllSelectedOptions.First().ToString();
        }

        public static IList<IWebElement> GetSelectedListOptions(this IWebElement element)
        {
            SelectElement oSelect = new SelectElement(element);
            return oSelect.AllSelectedOptions;
        }

        public static void SelectValueFromDropdownList(this IWebElement element,string visibleText)
        {

            SelectElement oSelect = new SelectElement(element);

            oSelect.SelectByText(visibleText);

        }

        public static void MouseHover(this IWebElement element)
        {

            Actions action = new Actions(DriverContext.Driver);

            action.MoveToElement(element).Perform();
        }

        // Check this method once
        public static string GetTextFromAnElement(this IWebElement element)
        {
            return element.GetAttribute("value");
        }

        private static bool IsElementPresent(IWebElement element)
        {

            try
            {
                bool ele = element.Displayed;
                return true;

            }
            catch(Exception e)
            {
                return false;
            }

        }

        public static void AssertElementPresent(this IWebElement element)
        {

            if (!IsElementPresent(element))
            {
                LogHelpers.WriteLine(string.Format("Element :" + element.Text + element.GetAttribute("value") + "  is not present. Hence Exception"));
                throw new Exception(string.Format("Element is not present. Hence Exception"));
            }
            else
            {
                LogHelpers.WriteLine("*******    Verified Element :"+element.Text+element.GetAttribute("value")+" Present    **********");
            }
        }


    }
}
