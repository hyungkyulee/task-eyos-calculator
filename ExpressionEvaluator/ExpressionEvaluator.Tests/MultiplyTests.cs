using ExpressionEvaluator.Domains;
using NUnit.Framework;

namespace ExpressionEvaluator.Tests
{
    [TestFixture]
    public class MultiplyTests
    {
        private Evaluator _evaluator;

        [SetUp]
        public void Setup()
        {
            _evaluator = new Evaluator();
        }

        [Test]
        public void Should_evaluate_multiply_operation()
        {
            // arrange
            var input = "1 *2*3 * 4 *5";

            // act
            var result = _evaluator.Handle(input);

            // assert
            Assert.That(result, Is.EqualTo("120"));
        }
    }
}