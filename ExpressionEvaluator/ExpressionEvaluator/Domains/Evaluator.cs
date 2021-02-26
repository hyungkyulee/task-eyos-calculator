using System.Collections.Generic;
using System.Linq;

namespace ExpressionEvaluator.Domains
{
    public class Evaluator
    {
        public int Evaluate(string input)
        {
            if (!input.Contains("+"))
            {
                var elem = new Elem(input);
                return elem.Number;
            }

            var numbers = input.Split("+");

            return Add(numbers.Select(x => new Elem(x)));
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