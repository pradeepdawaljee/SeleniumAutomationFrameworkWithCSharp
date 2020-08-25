using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TechTalk.SpecFlow;

namespace PracticeSpecflowBDD
{
    [Binding]
    public class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks



            private static ExtentTest featureName;
            private static ExtentTest scenario;
            private static ExtentReports extent;


        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Console.WriteLine("*********************       BeforeTestRun        *******************************");
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(@"C:\MyStuff\Work\C#\Projects\AutomationFrameworkSolution\SeleniumAutomationFrameworkSolution\PracticeSpecflowBDD\Reports\Extent.html");
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter); // If you don't attach then reports will not be displayed
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            Console.WriteLine("*********************       BeforFeature        *******************************");
            featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);

        }

        [BeforeScenario]
        public static void BeforeScenario()
        {
            //TODO: implement logic that has to run before executing each scenario
            Console.WriteLine("*********************       BeforeScenario        *******************************");
            scenario = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);

        }

        [BeforeStep]
        public static void BeforeStep()
        {
            Console.WriteLine("*********************       BeforeStep        *******************************");
        }

        [AfterStep]
        public static void AfterStep()
        {

            Console.WriteLine("*********************       AfterStep        *******************************");


            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();                

            switch (stepType)
            {
                case "Given":
                    if(ScenarioContext.Current.TestError == null)
                    {
                        scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                    }else if(ScenarioContext.Current.TestError != null)
                    {
                        scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
                    }                    
                    break;

                case "When":
                    if (ScenarioContext.Current.TestError == null)
                    {
                        scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                    }
                    else if (ScenarioContext.Current.TestError != null)
                    {
                        scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
                    }
                    break;

                case "Then":
                    if (ScenarioContext.Current.TestError == null)
                    {
                        scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                    }
                    else if (ScenarioContext.Current.TestError != null)
                    {
                        scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                    }
                    break;

                default:
                    if (ScenarioContext.Current.TestError == null)
                    {
                        scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
                    }
                    else if (ScenarioContext.Current.TestError != null)
                    {
                        scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
                    }
                    break;
            }


            //Below code for the steps that are not implemented/ Skipped / Pending . This was supposed to work but throws null exception


            PropertyInfo propertyInfo=typeof(ScenarioContext).GetProperty("TestStatus", BindingFlags.Instance | BindingFlags.NonPublic);
            MethodInfo getter= propertyInfo.GetGetMethod(nonPublic: true);
            object TestResult=getter.Invoke(ScenarioContext.Current, null);

            //Pending Status
            if (TestResult.ToString() == "StepDefinitionPending")
            {
                if (stepType == "Given")
                {
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                }
                else if (stepType == "When")
                {
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                }
                else if (stepType == "Then")
                {
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending , Check this = "+ScenarioContext.Current.TestError.InnerException);
                }
                else
                {
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                }
            }


        }

        [AfterScenario]
        public static void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
            Console.WriteLine("*********************       AfterScenario        *******************************");
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            Console.WriteLine("*********************       AfterFeature        *******************************");
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Console.WriteLine("*********************       AfetrTestRun        *******************************");
            extent.Flush();
        }
    }
}
