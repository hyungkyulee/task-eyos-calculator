using System.Runtime.CompilerServices;
using ExpressionEvaluator.Domains;
using NUnit.Framework;

namespace ExpressionEvaluator.Tests
{
    public class VariableTests
    {
        private Evaluator _evaluator;

        [SetUp]
        public void Setup()
        {
            _evaluator = new Evaluator();
        }

        [Test]
        public void Should_evaluate_single_variable()
        {
            var result = _evaluator.Handle("x");
            
            Assert.That(result, Is.EqualTo("x"));
        }
        
        [Test]
        public void Should_evaluate_variables_with_operators()
        {
            var result = _evaluator.Handle("x+1");
            
            Assert.That(result, Is.EqualTo("x+1"));
        }
    }
}