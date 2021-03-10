using System.Collections.Generic;

namespace ExpressionEvaluator.Domains
{
    public class Multiply : IExpr
    {
        public IEnumerable<IExpr> Expressions { get; }

        public Multiply(IEnumerable<IExpr> expressions)
        {
            Expressions = expressions;
        }

        public int Evaluate()
        {
            var result = 1;
            foreach (var expression in Expressions)
            {
                result *= expression.Evaluate();
            }
            return result;
        }
        
        public string EvaluateVariable()
        {
            return "";
        }
    }
}