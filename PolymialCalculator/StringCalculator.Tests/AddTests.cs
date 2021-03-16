using NUnit.Framework;
using StringCalculator.Controllers;
using StringCalculator.Domains;

namespace StringCalculator.Tests
{
    [TestFixture]
    public class AddTests
    {
        private Evaluator _evaluator;
        
        [SetUp]
        public void Setup()
        {
            _evaluator = new Evaluator();
        }
        
        [Test]
        public void Should_handle_simple_add()
        {
            // arrange
            var input = "1+2";

            // act
            var result = _evaluator.Handle(input);

            // assert
            Assert.That(result, Is.EqualTo("3"));
        }
        
        [Test]
        public void Should_handle_variable_add()
        {
            // arrange
            var input = "x+3";

            // act
            var result = _evaluator.Handle(input);

            // assert
            Assert.That(result, Is.EqualTo("3+x"));
        }
        
        [Test]
        public void Should_handle_variable_add_with_parenthesis()
        {
            // arrange
            var input = "(x+1)";

            // act
            var result = _evaluator.Handle(input);

            // assert
            Assert.That(result, Is.EqualTo("1+x"));
        }

    }
}