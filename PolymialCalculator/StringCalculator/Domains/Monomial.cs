using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator.Domains
{
    public class Monomial : IElement
    {
        private readonly int _number = 0;
        private readonly List<Variable> _variables = new List<Variable>();

        public int Value { get => _number; }

        public IEnumerable<IElement> Elements
        {
            get => _variables;
        }

        public Monomial(string element)
        {
            // 5
            // x
            // 23x 
            // 4x^2
            // 2x^3y^4
            
            // (x + 2) * (2x + y) => (var + num) * (var + var) => 

            var valuePattern = @"[\d]+(?=[a-z]+\^)?";
            var variablePattern = @"(?<=[\d])?[a-z]+";
            var powerPattern = @"(?<=\^)[\d]+";
            
            if(!int.TryParse(new Regex(valuePattern).Match(element).ToString(), out _number) && element != string.Empty) _number = 1;
            var variables = new Regex(variablePattern).Matches(element);
            var powers = new Regex(powerPattern).Matches(element);

            if (variables.Count > 0)
            {
                for(var i=0;i<variables.Count;i++)
                {
                    var varBase = variables[i].ToString();
                    var varPower = powers.Count > 0 ? int.Parse(powers[i].ToString()) : 1;
                    if(i==0) _variables.Add(new Variable(_number, varBase, varPower));
                    else _variables.Add(new Variable(1, varBase, varPower));
                }
            }
        }

        public string Evaluate()
        {
            return $"{string.Join("", _variables.Select(v => v.Evaluate()))}";
        }

        public IElement DoAdd(IElement element)
        {
            if (element.GetType() == typeof(Monomial))
            {
                // 2x + 3y
                var pattern = @"(?<=[\d])?[a-z]+[\^]?[\d]?";

                var leftMono = new Regex(pattern).Match(this.Evaluate());
                var rightMono = new Regex(pattern).Match(element.Evaluate());
                if (leftMono.ToString() == rightMono.ToString())
                {
                    var sum = Value + element.Value;
                    return new Monomial($"{sum}{leftMono.ToString()}");
                }
                // for (var i = 0; i < element.Elements.Count(); i++)
                // {
                //     // var matches = element.Elements.Where(v => new Variable(v.Evaluate())._base == _variables[i]._base);
                // }

                var monomials = new List<Monomial>() {new Monomial(Evaluate()), new Monomial(element.Evaluate())};
                return new Polymonial(monomials);
            }

            return null;
        }

        public IElement DoMultiply(IElement element)
        {
            if (element.GetType() == typeof(Polymonial))
            {
                // mono * polymonial = e.g. 2x*(3x+1)
                
                // number of poly * mono
                var number = new Number(element.Value);
                
                var result1 = number.DoMultiply(new Monomial(this.Evaluate())).Evaluate();
                
                var variablePattern = @"(?<=[\d])?[a-z]+";

                foreach (var variable in element.Elements)
                {
                    var matchVariable = new Regex(variablePattern).Match(variable.Evaluate());
                    Elements.Where(e => e.Evaluate().Contains(matchVariable.ToString()));
                }
                
                
                
                
                // mono of poly * mono
                // var number = _number * element.Value;
                // var monomials = element.Elements.Select(e => new Monomial(e.Evaluate()));
                //
                // var updatedMonos = new List<Monomial>();
                // foreach (var monomial in monomials)
                // {
                //     var result = this.DoMultiply(monomial);
                //     updatedMonos.Add(new Monomial(result.Evaluate()));
                // }
                //
                // return new Polymonial(new Number(number), updatedMonos);
            }

            return null;
        }
    }
}