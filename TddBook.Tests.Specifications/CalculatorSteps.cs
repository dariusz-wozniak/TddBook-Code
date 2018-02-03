using NUnit.Framework;
using TddBook.Calculators;
using TechTalk.SpecFlow;

namespace TddBook.Tests.Specifications
{
    [Binding]
    public class CalculatorSteps
    {
        private readonly CalculatorWithRegisteredNumbers _calculator = new CalculatorWithRegisteredNumbers();
        private int _result;

        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int number)
        {
            _calculator.FirstNumber = number;
        }

        [Given(@"I have also entered (.*) into the calculator")]
        public void GivenIHaveAlsoEnteredIntoTheCalculator(int number)
        {
            _calculator.SecondNumber = number;
        }
        
        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            _result = _calculator.Add();
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int expectedNumber)
        {
            Assert.That(_result, Is.EqualTo(expectedNumber));
        }
    }
}
