using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;

namespace StringCalculator.Domains
{
    public class Number : IElement
    {
        private int _number;

        public int Value
        {
            get => _number;
        }
        
        public IEnumerable<IElement> Elements
        {
            // get => new[] { new Number(_number)};
            get => null;
        }
        
        public Number(string input)
        {
            if (!int.TryParse(input, out _number)) _number = 0;
        }

        public Number(int number)
        {
            _number = number;
        }

        public string Evaluate()
        {
            return _number.ToString();
        }

        public IElement DoAdd(IElement element)
        {
            if (element.GetType() == typeof(Number))
            {
                // number + number
                var number = element.Value;
                var result = _number + number;
                return new Number(result);
            }

            if (element.GetType() == typeof(Monomial))
            {
                // number + monomial
                return new Polymonial(new Number(_number), new Monomial(element.Evaluate()));
            }

            if (element.GetType() == typeof(Polymonial))
            {
                // number + polymonial
                var number = _number + element.Value;
                var monomials = element.Elements.Select(e => new Monomial(e.Evaluate()));

                return new Polymonial(new Number(number), monomials);
            }

            return null;
        }
        
        public IElement DoMultiply(IElement element)
        {
            if (element.GetType() == typeof(Number))
            {
                // number * number
                var number = element.Value;
                var result = _number * number;
                return new Number(result);
            }

            if (element.GetType() == typeof(Monomial))
            {
                // number * monomial = e.g. 2*3x
                var value = _number * element.Value;
                var variables = element.Evaluate().Split(element.Value.ToString(), 2);
                return new Monomial($"{value}{variables.Last()}");
            }

            if (element.GetType() == typeof(Polymonial))
            {
                // number + polymonial = e.g. 2*(x+3)
                var number = _number * element.Value;
                var monomials = element.Elements.Select(e => new Monomial(e.Evaluate()));

                var updatedMonos = new List<Monomial>();
                foreach (var monomial in monomials)
                {
                    var result = this.DoMultiply(monomial);
                    updatedMonos.Add(new Monomial(result.Evaluate()));
                }

                return new Polymonial(new Number(number), updatedMonos);
            }

            return null;
        }
    }
}