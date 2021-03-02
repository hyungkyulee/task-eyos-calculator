using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ExpressionEvaluator.Domains
{
    public class Evaluator
    {
        public int Handle(string input)
        {
            var expressions = ParseExpr(input);
            var result = 0;
            foreach (var expression in expressions)
            {
                result += expression.Evaluate();
            }

            return result;
        }

        private IEnumerable<IExpr> ParseExpr(string input)
        {
            var expressions = new List<IExpr>();
            var inputSimplified = input;
            
            if (input.Contains("(") ||
                input.Contains(")"))
            { 
                inputSimplified = SimplifyParentheses(input);   
            }
            
            if (!inputSimplified.Contains("+") &&
                !inputSimplified.Contains("*") &&
                !inputSimplified.Contains("(") &&
                !inputSimplified.Contains(")"))
            {
                expressions.Add(new Elem(inputSimplified));
            }

            if (input.Contains("+") ||
                input.Contains("*"))
            {
                expressions.AddRange(ParseAddMultiply(inputSimplified));
            }

            return expressions;
        }

        private static string SimplifyParentheses(string input)
        {
            var simplifiedString = input;
            var bracketSigns = new char[] {'(', ')'};
            
            while (true)
            {
                var pattern = @"\([\d\s\+\*]+\)";
                var regEx = new Regex(pattern);
                var parenthesisExpressions = regEx.Matches(simplifiedString);

                if (parenthesisExpressions.Count == 0) break;

                foreach (Match parenthesisExpression in parenthesisExpressions)
                {
                    var highOderResult = 0;
                    var highOrderExpressions = ParseAddMultiply(parenthesisExpression.Value.Trim(bracketSigns));
                    foreach (var highOrderExpression in highOrderExpressions)
                    {
                        highOderResult += highOrderExpression.Evaluate();
                    }

                    simplifiedString = simplifiedString.Replace(parenthesisExpression.Value, highOderResult.ToString());
                }
            }

            return simplifiedString;
        }

        private static List<IExpr> ParseAddMultiply(string input)
        {
            var addMultiplyExpressions = new List<IExpr>();
            
            if (input.Contains("+") ||
                input.Contains("*"))
            {
                var addStringExpressions = input.Split("+");
                foreach (var addStringExpression in addStringExpressions)
                {
                    if (addStringExpression.Contains("*"))
                    {
                        var multStringExpressions = addStringExpression.Split("*");
                        var multExpressions = multStringExpressions.Select(x => new Elem(x));
                        addMultiplyExpressions.Add(new Multiply(multExpressions));
                    }
                    else
                    {
                        var addExpression = new Elem(addStringExpression);
                        addMultiplyExpressions.Add(new Add(addExpression));
                    }
                }
            }

            return addMultiplyExpressions;
        }
    }
}