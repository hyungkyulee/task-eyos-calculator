using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ExpressionEvaluator.Domains
{
    public class Evaluator
    {
        public int Evaluate(string input)
        {
            if (!input.Contains("+") &&
                !input.Contains("*") &&
                !input.Contains("(") &&
                !input.Contains(")"))
            {
                var element = new Elem(input);
                return element.Number;
            }

            var updatedExpression = "";
            
            updatedExpression = HighOrderBracketOperation(input);

            return MixedOperation(updatedExpression);
        }

        private string HighOrderBracketOperation(string input)
        {
            while (true)
            {
                var pattern = @"\([\d\s\*\+]+\)";
                var regEx = new Regex(pattern);
                var bracketExpressions = regEx.Matches(input);

                if (bracketExpressions.Count <= 0)
                {
                    break;
                }

                var delimiters = new char[] {'(', ')'};


                foreach (Match expression in bracketExpressions)
                {
                    var braketResult = MixedOperation(expression.Value.Trim(delimiters)).ToString();
                    input = input.Replace(expression.Value, braketResult);
                }
            }

            return input;
        }

        private int MixedOperation(string input)
        {
            var addExpressions = input.Split("+");
            var elements = new List<string>();
            var result = 0;
            foreach (var expression in addExpressions)
            {
                if (!expression.Contains("*"))
                {
                    elements.Add(expression);
                    continue;
                }

                var multiplyExpressions = expression.Split("*");
                result += Multiply(multiplyExpressions.Select(x => new Elem(x)));
            }

            return result + Add(elements.Select(x => new Elem(x)));
        }

        private int Multiply(IEnumerable<Elem> elements)
        {
            var result = 1;
            foreach (var element in elements)
            {
                result *= element.Number;
            }
            return result;
        }

        private static int Add(IEnumerable<Elem> elements)
        {
            var result = 0;
            foreach (var element in elements)
            {
                result += element.Number;
            }
            return result;
        }
    }
}