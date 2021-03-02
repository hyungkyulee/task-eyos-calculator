using System.Collections.Generic;

namespace ExpressionEvaluator.Domains
{
    public class Add : IExpr
    {
        public IEnumerable<IExpr> Expressions { get; }

        public Add(IExpr expression)
        {
            Expressions = new [] {expression};
        }
        public Add(IEnumerable<IExpr> expressions)
        {
            Expressions = expressions;
        }

        public int Evaluate()
        {
            var result = 0;
            foreach (var expression in Expressions)
            {
                result += expression.Evaluate();
            }
            return result;
        }
    }
}