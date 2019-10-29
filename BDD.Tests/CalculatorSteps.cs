using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using Xunit;

namespace BDD.Tests
{
    [Binding]
    public class CalculatorSteps : IDisposable
    {
        private const string URL = "http://localhost:10751/Home/Calculate";
        private IWebDriver _browser;
        private WebDriverWait _wait;

        public CalculatorSteps()
        {
            _browser = new ChromeDriver(Environment.CurrentDirectory);
            _wait = new WebDriverWait(_browser, TimeSpan.FromSeconds(1));

            _browser.Navigate().GoToUrl(URL);
        }

        public void Dispose()
        {
            _browser.Close();
            _browser.Dispose();
        }

        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int number)
        {
            var input = _wait.Until(ExpectedConditions.ElementExists(By.Id("FirstNumber")));
            input.Clear();
            input.SendKeys(number.ToString());
        }
        
        [Given(@"I have also entered (.*) into the calculator")]
        public void GivenIHaveAlsoEnteredIntoTheCalculator(int number)
        {
            var input = _wait.Until(ExpectedConditions.ElementExists(By.Id("SecondNumber")));
            input.Clear();
            input.SendKeys(number.ToString());
        }
        
        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            var input = _wait.Until(ExpectedConditions.ElementExists(By.Id("submit")));
            input.Click();
        }
        
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int result)
        {
            var input = _wait.Until(ExpectedConditions.ElementExists(By.Id("Result")));
            Assert.Equal(result, Convert.ToInt32(input.GetAttribute("value")));
        }
    }
}
