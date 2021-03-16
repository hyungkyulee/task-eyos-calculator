using System.ComponentModel;
using System.Text.RegularExpressions;
using NUnit.Framework;
using StringCalculator.Controllers;
using StringCalculator.Domains;

namespace StringCalculator.Tests
{
    public class RealProblemTests
    {
        private Evaluator _evaluator;
        
        [SetUp]
        public void Setup()
        {
            _evaluator = new Evaluator();
        }

        [Test]
        public void Should_handle_simple_operation_with_parenthesis()
        {
            // arrange
            var input = "(1+(2*x)+1)";

            // act
            var result = _evaluator.Handle(input);

            // assert
            Assert.That(result, Is.EqualTo("2*x+2"));
        }

        [Test]
        public void Should_handle_mixed_operation_with_parenthesis()
        {
            // arrange
            var input = "((b+2)*3+a*(5+2)+c*7)";
        
            // act
            var result = _evaluator.Handle(input);
        
            // assert
            Assert.That(result, Is.EqualTo("3*b+7a+6+7*c"));
        }

        [Test]
        public void Should_handle_mixed_operation_task_final()
        {
            // arrange
            var input = "(1+2*x+1)*(x+1)";

            // act
            var result = _evaluator.Handle(input);

            // assert
            Assert.That(result, Is.EqualTo("2*x^2+4*x+2"));
        }
    }
}