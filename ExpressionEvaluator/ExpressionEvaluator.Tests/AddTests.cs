using ExpressionEvaluator.Domains;
using NUnit.Framework;

namespace ExpressionEvaluator.Tests
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
        public void Should_evaluate_single_add_operation()
        {
            // arrange
            var input = "1+1";
            
            // act
            var result = _evaluator.Handle(input);
                
            // assert
            Assert.That(result, Is.EqualTo(2));
        }
        
        [Test]
        public void Should_evaluate_multi_add_operation()
        {
            // arrange
            var input = "1 +2+ 3 + 4";
            
            // act
            var result = _evaluator.Handle(input);
            
            // Asert
            Assert.That(result, Is.EqualTo(10));
        }
    }
}