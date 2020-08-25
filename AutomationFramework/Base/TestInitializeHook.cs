using AutomationFramework.Config;
using AutomationFramework.Helpers;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace AutomationFramework.Base
{
    public abstract class TestInitializeHook : Base
    {

        public readonly BrowserType Browser;

        public TestInitializeHook(BrowserType browser)
        {

            Browser = browser;

        }

        public void InitializeSettings()
        {
            //Set settings for framework
            ConfigReader.SetFrameworkSettings();
            //Set Log
            LogHelpers.CreateLogFile();

            OpenBrowser(Browser);

            LogHelpers.WriteLine("Initialized Settings");

        }

        private void OpenBrowser(BrowserType browserType = BrowserType.Chrome)
        {
            // Type SW and double tab & give browserType & press down arrow for auto code snippet
            // For Default value of switch just add in parameters as optional

            switch (browserType)
            {
                case BrowserType.Chrome:
                    DriverContext.Driver = new ChromeDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                case BrowserType.Firefox:
                    DriverContext.Driver = new FirefoxDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                case BrowserType.InternetExplorer:
                    DriverContext.Driver = new InternetExplorerDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
            }

            LogHelpers.WriteLine("Opened Browser");

        }

        // Virtual because you can overwrite anytime if you want to
        public virtual void NavigateSite()
        {
            DriverContext.Browser.GoToUrl(Settings.AUT);
            LogHelpers.WriteLine("Navigated to the Application");
        }

    }
}
