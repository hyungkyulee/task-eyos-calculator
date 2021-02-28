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
            // if (!input.Contains("+") &&
            //     !input.Contains("*") &&
            //     !input.Contains("(") &&
            //     !input.Contains(")"))
            // {
            //     var element = new Elem(input);
            //     return element.Number;
            // }

            // var simplifiedExpression = CalculateNumbersInParentheses(input);
            // return ParseExpr(simplifiedExpression);

            var expressions = ParseExpr(input);
            var result = 0;
            foreach (var expression in expressions)
            {
                result += expression.Evaluate();
            }

            return result;
        }

        private string CalculateNumbersInParentheses(string input)
        {
            var inputString = input;
            while (true)
            {
                var pattern = @"\([\d\s\*\+]+\)";
                var regEx = new Regex(pattern);
                var bracketExpressions = regEx.Matches(inputString);

                if (bracketExpressions.Count == 0)
                {
                    break;
                }

                var delimiters = new char[] {'(', ')'};
                
                foreach (Match expression in bracketExpressions)
                {
                    var braketResult = ParseExpr(expression.Value.Trim(delimiters)).ToString();
                    inputString = inputString.Replace(expression.Value, braketResult);
                }
            }

            return inputString;
        }

        private IEnumerable<IExpr> ParseExpr(string input)
        {
            var expressions = new List<IExpr>();
            
            
            if (!input.Contains("+") &&
                !input.Contains("*") &&
                !input.Contains("(") &&
                !input.Contains(")"))
            {
                expressions.Add(new Elem(input));
            }

            // it would be better to make it an eraser method.
            var inputSimplified = SimplifyParentheses(input);

            expressions = ParseAddMultiply(inputSimplified);
            
            // if (input.Contains("+"))
            // {
            //     var stringExpressions = input.Split("+");
            //     var addElements = stringExpressions.Select(x => new Elem(x));
            //
            //     elements.Add(new Add(addElements));
            // }
            //
            // if (input.Contains("*"))
            // {
            //     var stringExpressions = input.Split("*");
            //     var multElements = stringExpressions.Select(x => new Elem(x));
            //
            //     elements.Add(new Multiply(multElements));
            // }

            return expressions;
            // var elements = new List<string>();
            // var result = 0;
            // foreach (var expression in stringExpressions)
            // {
            //     if (!expression.Contains("*"))
            //     {
            //         elements.Add(expression);
            //         continue;
            //     }
            //
            //     var multiplyExpressions = expression.Split("*");
            //     result += Multiply(multiplyExpressions.Select(x => new Elem(x)));
            // }
            //
            // return result + Add(elements.Select(x => new Elem(x)));
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
                // var addElements = new List<Add>();
                // var multElements = new List<Multiply>();

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