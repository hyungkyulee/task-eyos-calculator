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
            var input = "1+3+1*2*3+1";
            
            // act
            var result = _evaluator.Handle(input);

            // assert
            Assert.That(result, Is.EqualTo(11));
        }
        
        [Test]
        public void Should_evluate_mixed_operator_expression_with_spaces()
        {
            // arrange
            var input = "1 +3 +1* 2+1";
            
            // act
            var result = _evaluator.Handle(input);

            // assert
            Assert.That(result, Is.EqualTo(7));
        }
        
        [Test]
        public void Should_evluate_mixed_operator_expression_with_brackets()
        {
            // arrange
            var input = "2 *((3 +4)+ 2)+ (2+3)*4";
            
            // act
            var result = _evaluator.Handle(input);
            // var example4 = _evaluator.Handle("((1+2+1)*(1+1))");

            // assert
            Assert.That(result, Is.EqualTo(38));
            // Assert.That(example4, Is.EqualTo(8));
        }
    }
}