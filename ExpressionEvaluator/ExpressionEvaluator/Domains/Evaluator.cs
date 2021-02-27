using System;
using System.Collections.Generic;
using System.Linq;

namespace ExpressionEvaluator.Domains
{
    public class Evaluator
    {
        public int Evaluate(string input)
        {
            if (!input.Contains("+") &&
                !input.Contains("*"))
            {
                var element = new Elem(input);
                return element.Number;
            }

            // var delimiters = new string[] {"+", "*", "(", ")"};

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