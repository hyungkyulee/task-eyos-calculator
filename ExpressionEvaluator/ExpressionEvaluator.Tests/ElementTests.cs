using System.Runtime.CompilerServices;
using ExpressionEvaluator.Domains;
using NUnit.Framework;

namespace ExpressionEvaluator.Tests
{
    public class Tests
    {
        private Evaluator _evaluator;

        [SetUp]
        public void Setup()
        {
            _evaluator = new Evaluator();
        }

        [Test]
        public void Should_evaluate_single_digit_number()
        {
            var result = _evaluator.Evaluate("1");
            
            Assert.That(result, Is.EqualTo(1));
        }
        
        [Test]
        public void Should_evaluate_double_digit_number()
        {
            var result = _evaluator.Evaluate("11");
            
            Assert.That(result, Is.EqualTo(11));
        }
    }
}