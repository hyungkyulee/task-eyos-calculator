using System.Collections.Generic;

namespace ExpressionEvaluator.Domains
{
    public class Add : IExpr
    {
        //public IEnumerable<Elem> Elements { get; }
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
            // 2, (1+2), (2*3)
            foreach (var expression in Expressions)
            {
                result += expression.Evaluate();
            }
            return result;
        }
    }
}