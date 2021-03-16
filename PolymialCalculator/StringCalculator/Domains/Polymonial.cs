using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator.Domains
{
    public class Polymonial : IElement
    {
        private readonly int _number = 0;
        private readonly List<Monomial> _monomials = new List<Monomial>();

        public int Value { get => _number; }

        public IEnumerable<IElement> Elements
        {
            get => _monomials;
        }

        public Polymonial(string expression)
        {
            var elements = expression.Split("+");

            var number = 0;
            foreach (var element in elements)
            {
                if (element != string.Empty)
                {
                    if (int.TryParse(element, out number))
                    {
                        _number += number;
                        continue;
                    }
                    _monomials.Add(new Monomial(element));
                }
            }
        }

        public Polymonial(Number number, Monomial monomial)
        {
            _number = number.Value;
            _monomials.Add(monomial);
        }

        public Polymonial(Number number, IEnumerable<Monomial> monomials)
        {
            _number = number.Value;
            _monomials.AddRange(monomials);
        }
        
        public Polymonial(IEnumerable<Monomial> monomials)
        {
            _monomials.AddRange(monomials);
        }

        public string Evaluate()
        {
            if(_number == 0) return $"{string.Join("+", Elements.Select(e => e.Evaluate()))}";
            return $"{string.Join("+", Elements.Select(e => e.Evaluate()))}+{_number}";
        }

        public IElement DoMultiply(IElement element)
        {
            if (element.GetType() == typeof(Polymonial))
            {
                // poly * polymonial = e.g. (1 + 2x +1) * (x + 1)

                var numPoly = new Number(_number);
                numPoly.DoMultiply(new Polymonial(element.Evaluate()));
                
                
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