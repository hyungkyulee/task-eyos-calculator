using NUnit.Framework;
using StringCalculator.Controllers;
using StringCalculator.Domains;

namespace StringCalculator.Tests
{
    [TestFixture]
    public class PolynomialsTests
    {
        private Evaluator _evaluator;
        
        [SetUp]
        public void Setup()
        {
            _evaluator = new Evaluator();
        }

        [Test]
        public void Should_handle_multiply_poly_poly()
        {
            // arrange
            var input = "1+2x+1";
            var polymonial = new Polymonial(input);

            // act
            var result = polymonial.DoMultiply(new Polymonial("x+1")).Evaluate();

            // assert
            Assert.That(result, Is.EqualTo("2x^2+4x+2"));
        }

    }
}