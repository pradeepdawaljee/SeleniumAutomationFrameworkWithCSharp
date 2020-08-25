using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.Base
{
    public abstract class BasePage : Base
    {


        public BasePage()
        {
            PageFactory.InitElements(DriverContext.Driver, this); // Can comment this code as Base ontains this
        }

    }
}
