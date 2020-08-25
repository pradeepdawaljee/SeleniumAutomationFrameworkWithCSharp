using AutomationFramework.Base;
using AutomationFramework.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.Extensions
{
    public static class WebDriverExtensions
    {

        public static void WaitForPageToLoad(this IWebDriver driver)
        {
            // Using Lambda expression
            driver.WaitForCondition(dri => 
            {

                string state = dri.ExecuteJs("return document.readyState").ToString();
                return state == "complete";
            
            }, 10);

            LogHelpers.WriteLine("*******  Page Load Completed   ********");
        }


        public static void WaitForCondition<T>(this T obj, Func<T,bool> condition, int timeOut)
        {

            Func<T, bool> execute = (args) =>
             {
                 try
                 {
                     return condition(args);
                 }
                 catch(Exception)
                 {
                     return false;
                 }
             };

            Stopwatch stopwatch = Stopwatch.StartNew();

            while (stopwatch.ElapsedMilliseconds<timeOut)
            {
                if (execute(obj))
                {
                    break;
                }
            }

        }

        internal static object ExecuteJs(this IWebDriver driver,string script)
        {
            return ((IJavaScriptExecutor)DriverContext.Driver).ExecuteScript(script);
        }

    }
}
