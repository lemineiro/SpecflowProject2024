using NUnit.Framework;

namespace SpecFlowProject2024.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        int number1;
        int number2;
        int sum;

        int result1;
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            //TODO: implement arrange (precondition) logic
            // For storing and retrieving scenario-specific data see https://go.specflow.org/doc-sharingdata
            // To use the multiline text or the table argument of the scenario,
            // additional string/Table parameters can be defined on the step definition
            // method. 

            number1 = number;
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            //TODO: implement arrange (precondition) logic

            number2 = number;
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            //TODO: implement act (action) logic

            sum = number1 + number2;
        }

        [When(@"the two numbers are multiplied")]
        public void WhenTheTwoNumbersAreMultiplied()
        {
            //result2 = 10 * 20;
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int result1)
        {
            //TODO: implement assert (verification) logic

            Assert.IsTrue(result1 == sum);
        }

        

    }
}
