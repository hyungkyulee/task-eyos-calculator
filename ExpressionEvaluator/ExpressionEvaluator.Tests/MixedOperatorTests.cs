using ExpressionEvaluator.Domains;
using NUnit.Framework;

namespace ExpressionEvaluator.Tests
{
    [TestFixture]
    public class MixedOperatorTests
    {
        private Evaluator _evaluator;

        [SetUp]
        public void Setup()
        {
            _evaluator = new Evaluator();            
        }

        [Test]
        public void Should_evluate_mixed_operator_expression()
        {
            // arrange
            var input = "1+2+1*2+1";
            
            // act
            var result = _evaluator.Evaluate(input);

            // assert
            Assert.That(result, Is.EqualTo(6));
        }
        
        [Test]
        public void Should_evluate_mixed_operator_expression_with_spaces()
        {
            // arrange
            var input = "1 +2 +1* 2+1";
            
            // act
            var result = _evaluator.Evaluate(input);

            // assert
            Assert.That(result, Is.EqualTo(6));
        }
    }
}