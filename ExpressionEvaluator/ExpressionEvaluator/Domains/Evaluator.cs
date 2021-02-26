using System.Collections.Generic;
using System.Linq;

namespace ExpressionEvaluator.Domains
{
    public class Evaluator
    {
        public int Evaluate(string input)
        {
            if (input.Contains("+"))
            {
                var numbers = input.Split("+");
                return Add(numbers.Select(x => new Elem(x)));
            }

            if (input.Contains("*"))
            {
                var numbers = input.Split("*");
                return Multiply(numbers.Select(x => new Elem(x)));
            }

            var elem = new Elem(input);
            return elem.Number;
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