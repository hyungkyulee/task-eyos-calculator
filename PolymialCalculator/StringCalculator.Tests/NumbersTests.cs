using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using StringCalculator.Controllers;
using StringCalculator.Domains;

namespace StringCalculator.Tests
{
    [TestFixture]
    public class NumbersTests
    {
        private Evaluator _evaluator;
        
        [SetUp]
        public void Setup()
        {
            _evaluator = new Evaluator();
        }
        
        [Test]
        public void Should_handle_single_number_string()
        {
            // arrange
            var input = "56";
            var number = new Number(input);

            // act
            var result = number.Evaluate();

            // assert
            Assert.That(result, Is.EqualTo("56"));
        }
        
        [Test]
        public void Should_handle_single_number_int()
        {
            // arrange
            var input = "56";
            var number = new Number(input);

            // act
            var result = number.Value;

            // assert
            Assert.That(result, Is.EqualTo(56));
        }

        [Test]
        public void Should_handle_add_numbers()
        {
            // arrange
            var input = "2";
            var number = new Number(input);
        
            // act
            var result = number.DoAdd(new Number("3")).Evaluate();
        
            // assert
            Assert.That(result, Is.EqualTo("5"));
        }
        
        [Test]
        public void Should_handle_add_number_monomial()
        {
            // arrange
            var input = "2";
            var number = new Number(input);
        
            // act
            var result = number.DoAdd(new Monomial("3x")).Evaluate();
        
            // assert
            Assert.That(result, Is.EqualTo("3x+2"));
        }
        
        [Test]
        public void Should_handle_add_number_polynomial()
        {
            // arrange
            var input = "2";
            var number = new Number(input);
        
            // act
            var result = number.DoAdd(new Polymonial("3x^2+5")).Evaluate();
        
            // assert
            Assert.That(result, Is.EqualTo("3x^2+7"));
        }
        
        [Test]
        public void Should_handle_multiply_numbers()
        {
            // arrange
            var input = "2";
            var number = new Number(input);
        
            // act
            var result = number.DoMultiply(new Number("3")).Evaluate();
        
            // assert
            Assert.That(result, Is.EqualTo("6"));
        }
        
        [Test]
        public void Should_handle_multiply_number_monomial()
        {
            // arrange
            var input = "2";
            var number = new Number(input);
        
            // act
            var result = number.DoMultiply(new Monomial("3x")).Evaluate();
        
            // assert
            Assert.That(result, Is.EqualTo("6x"));
        }
        
        [Test]
        public void Should_handle_multiply_number_polynomial()
        {
            // arrange
            var input = "2";
            var number = new Number(input);
        
            // act
            var result = number.DoMultiply(new Polymonial("3x^2+5")).Evaluate();
        
            // assert
            Assert.That(result, Is.EqualTo("6x^2+10"));
        }
        
        [Test]
        public void Should_handle_multiply_number_polynomial2()
        {
            // arrange
            var input = "3";
            var number = new Number(input);
        
            // act
            var result = number.DoMultiply(new Polymonial("1+2x+3")).Evaluate();
        
            // assert
            Assert.That(result, Is.EqualTo("6x+12"));
        }
    }
}