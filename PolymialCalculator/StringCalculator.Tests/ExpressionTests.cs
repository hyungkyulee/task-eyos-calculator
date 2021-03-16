using NUnit.Framework;
using StringCalculator.Controllers;
using StringCalculator.Domains;

namespace StringCalculator.Tests
{
    [TestFixture]
    public class ExpressionTests
    {
        private Evaluator _evaluator;
        
        [SetUp]
        public void Setup()
        {
            _evaluator = new Evaluator();
        }
        
        [Test]
        public void Should_handle_multiplying_numbers()
        {
            // arrange
            var input = "2*3";

            // act
            var result = _evaluator.Handle(input);

            // assert
            Assert.That(result, Is.EqualTo("6"));

        }
 
        [Test]
        public void Should_handle_multiplying_variable_and_numbers()
        {
            // arrange
            var input = "a*5*2";

            // act
            var result = _evaluator.Handle(input);

            // assert
            Assert.That(result, Is.EqualTo("10*a"));
        }

        [Test]
        public void Should_handle_multiplying_two_variable_and_numbers()
        {
            // arrange
            var input = "a*5*2*10*c";

            // act
            var result = _evaluator.Handle(input);

            // assert
            Assert.That(result, Is.EqualTo("100*a*c"));
        }
        
        [Test]
        public void Should_handle_multiplying_with_parentheses()
        {
            // arrange
            var input = "(b+2)*3";

            // act
            var result = _evaluator.Handle(input);

            // assert
            Assert.That(result, Is.EqualTo("6+3*b"));
        }
    }
}