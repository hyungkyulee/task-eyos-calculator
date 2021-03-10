using NUnit.Framework;
using StringCalculator.Controllers;

namespace StringCalculator.Tests
{
    [TestFixture]
    public class ElementTests
    {
        private Evaluator _evaluator;
        
        [SetUp]
        public void Setup()
        {
            _evaluator = new Evaluator();
        }
        
        [Test]
        public void Should_handle_single_digit_variable()
        {
            // arrange
            var input = "b";

            // act
            var result = _evaluator.Handle(input);

            // assert
            Assert.That(result, Is.EqualTo("b"));
        }

        [Test]
        public void Should_handle_single_number()
        {
            // arrange
            var input = "12";

            // act
            var result = _evaluator.Handle(input);

            // assert
            Assert.That(result, Is.EqualTo("12"));
        }

    }
}