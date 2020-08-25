using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace PracticeSpecflowBDD.StepDefinitions
{

    [Binding]
    public class SampleFeatureStep
    {

        private string _oper;

        [Given(@"the first number is (.*)")]
        public void GivenTheFirstNumberIs(int num1)
        {

            /*//ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(@"C:\MyStuff\Work\C#\Projects\AutomationFrameworkSolution\SeleniumAutomationFrameworkSolution\PracticeSpecflowBDD\Reports\");
            ExtentReports extent=new ExtentReports();
            
            extent.AttachReporter(htmlReporter);

            //Feature
            ExtentTest feature=extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);

            //Scenario
            ExtentTest scenario=feature.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);


            //Steps
            scenario.CreateNode<Given>("the first number is (.*)");

            //Flush the reports everytime
            extent.Flush();*/

            //ScenarioContext.Current.Pending();
            Console.WriteLine(num1);


        }

        [Given(@"the second number is (.*)")]
        public void GivenTheSecondNumberIs(int num2)
        {
            //ScenarioContext.Current.Pending();
            Console.WriteLine(num2);
        }

        [When(@"the two numbers are (.*)")]
        public void WhenTheTwoNumbersAreAdded(string oper)
        {
            _oper = oper;
            //ScenarioContext.Current.Pending();
            Console.WriteLine("Performing {0}", oper);
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            //ScenarioContext.Current.Pending();
            if(_oper.Equals("added") && result == 120)
            {
                Console.WriteLine("Adds Test Passed");
            }
            else if (_oper.Equals("Substracted") && result == 20)
            {
                Console.WriteLine("Subs Test Passed");
            }
            else
            {
                Console.WriteLine("Test not passed");
                throw new Exception("Test not passed");
            }
        }

        [Then(@"this step should be pending for reports to be displayed")]
        public void ThenThisStepShouldBePendingForReportsToBeDisplayed()
        {
            ScenarioContext.Current.Pending();
        }



    }
}
