using NUnit.Framework;
using StringCalculator.Controllers;
using StringCalculator.Domains;

namespace StringCalculator.Tests
{
    [TestFixture]
    public class MonomialsTests
    {
        private Evaluator _evaluator;
        
        [SetUp]
        public void Setup()
        {
            _evaluator = new Evaluator();
        }

        [Test]
        public void Should_handle_single_variables()
        {
            // arrange
            var input = "x";
            var monomial = new Monomial(input);

            // act
            var result = monomial.Evaluate();

            // assert
            Assert.That(result, Is.EqualTo("x"));
        }
        
        [Test]
        public void Should_handle_1stpower_number_variables()
        {
            // arrange
            var input = "3xy";
            var monomial = new Monomial(input);

            // act
            var result = monomial.Evaluate();

            // assert
            Assert.That(result, Is.EqualTo("3xy"));
        }
        
        [Test]
        public void Should_handle_combined_variables()
        {
            // arrange
            var input = "2x^3y^4";
            var monomial = new Monomial(input);

            // act
            var result = monomial.Evaluate();

            // assert
            Assert.That(result, Is.EqualTo("2x^3y^4"));
        }
        
        [Test]
        public void Should_handle_add_variable_variable()
        {
            // arrange
            var input = "2x";
            var monomial = new Monomial(input);

            // act
            var result = monomial.DoAdd(new Monomial("3y")).Evaluate();

            // assert
            Assert.That(result, Is.EqualTo("2x+3y"));
        }
        
        [Test]
        public void Should_handle_add_variable_variable2()
        {
            // arrange
            var input = "2x^3";
            var monomial = new Monomial(input);

            // act
            var result = monomial.DoAdd(new Monomial("3x^3")).Evaluate();

            // assert
            Assert.That(result, Is.EqualTo("5x^3"));
        }
        
        [Test]
        public void Should_handle_multiply_mono_poly()
        {
            // arrange
            var input = "2x";
            var monomial = new Monomial(input);

            // act
            var result = monomial.DoMultiply(new Polymonial("3x+1")).Evaluate();

            // assert
            Assert.That(result, Is.EqualTo("6x^2+2x"));
        }
        
        [Test]
        public void Should_handle_multiply_mono_mono()
        {
            // arrange
            var input = "5x";
            var monomial = new Monomial(input);

            // act
            var result = monomial.DoMultiply(new Monomial("3x")).Evaluate();

            // assert
            Assert.That(result, Is.EqualTo("15x^2"));
        }
        
        [Test]
        public void Should_handle_multiply_b_a()
        {
            // arrange
            var input = "ba";
            var monomial = new Monomial(input);

            // act
            var result = monomial.DoMultiply(new Monomial("a")).Evaluate();

            // assert
            Assert.That(result, Is.EqualTo("ab"));
        }

    }
}