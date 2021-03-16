using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

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
            // 2x^3y^4 => val = 2, variable[0] = x^3, var[1] = y^4

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
            var output = $"{string.Join("", _variables.OrderBy(x => x._base).Select(v => v.Evaluate()))}";

            // var result = output.OrderBy(x => x);
            
            
            return output;
        }

        public IElement DoAdd(IElement element)
        {
            if (element.GetType() == typeof(Monomial))
            {
                // 2x + 3y vs 2x + 3x
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
            if (element.GetType() == typeof(Monomial))
            {
                // mono * polymonial = e.g. 2x*(3x+1)
                var resultMonomials = new List<Monomial>();
                
                // this monomial x monomials of poly
                var variablePattern = @"(?<=[\d])?[a-z]+";
                var pureMonomial = new Regex(variablePattern).Match(this.Evaluate());
                // var leftVariables = Elements.Select(e => new Variable(e.Evaluate()));
                
                var leftVariables = new List<Variable>();
                foreach (var e in Elements)
                {
                    leftVariables.Add(new Variable(e.Evaluate()));
                }
                // var rightVariables = element.Elements.Select(e => new Variable(e.Evaluate()));
                var rightVariables = new List<Variable>();
                foreach (var e in element.Elements)
                {
                    rightVariables.Add(new Variable(e.Evaluate()));
                }
                
                var newVariables = new List<Variable>();
                newVariables.AddRange(leftVariables);
                newVariables.AddRange(rightVariables);
                
                foreach (var leftVariable in leftVariables)
                {
                    foreach (var rightVariable in rightVariables)
                    {
                        if (leftVariable._base == rightVariable._base)
                        {
                            var sameVariables = new List<Variable>(); 
                            sameVariables.Add(new Variable(leftVariable.Value * rightVariable.Value,
                                leftVariable._base,
                                leftVariable._power + rightVariable._power));
                            newVariables.Remove(leftVariable);
                            newVariables.Remove(rightVariable);
                            newVariables.Add(sameVariables.Last());
                        }
                    }
                }
                
                resultMonomials.Add(new Monomial(string.Join("", newVariables.Select(v => v.Evaluate()))));

                return new Monomial(resultMonomials.First().Evaluate());
            }
            
            if (element.GetType() == typeof(Polymonial))
            {
                // mono * polymonial = e.g. 2x*(3x+1)
                var resultMonomials = new List<Monomial>();
                
                // number of poly * this monomial
                var number = new Number(element.Value);
                var tempResult = number.DoMultiply(new Monomial(this.Evaluate())).Evaluate();
                resultMonomials.Add(new Monomial(tempResult));
                
                // this monomial x monomials of poly
                var variablePattern = @"(?<=[\d])?[a-z]+";
                var pureMonomial = new Regex(variablePattern).Match(this.Evaluate());
                // var leftVariables = Elements.Select(e => new Variable(e.Evaluate()));
                
                var leftVariables = new List<Variable>();
                foreach (var e in Elements)
                {
                    leftVariables.Add(new Variable(e.Evaluate()));
                }
                // var rightVariables = element.Elements.Select(e => new Variable(e.Evaluate()));
                var rightVariables = new List<Variable>();
                foreach (var e in element.Elements)
                {
                    rightVariables.Add(new Variable(e.Evaluate()));
                }
                
                var newVariables = new List<Variable>();
                newVariables.AddRange(leftVariables);
                newVariables.AddRange(rightVariables);
                
                foreach (var leftVariable in leftVariables)
                {
                    foreach (var rightVariable in rightVariables)
                    {
                        if (leftVariable._base == rightVariable._base)
                        {
                            var sameVariables = new List<Variable>(); 
                            sameVariables.Add(new Variable(leftVariable.Value * rightVariable.Value,
                                leftVariable._base,
                                leftVariable._power + rightVariable._power));
                            newVariables.Remove(leftVariable);
                            newVariables.Remove(rightVariable);
                            newVariables.Add(sameVariables.Last());
                        }
                    }
                }
                
                resultMonomials.Add(new Monomial(string.Join("", newVariables.Select(v => v.Evaluate()))));

                return new Polymonial(resultMonomials);

                // foreach (var variable in element.Elements)
                // {
                //     var matchVariable = new Regex(variablePattern).Match(variable.Evaluate());
                //     Elements.Where(e => e.Evaluate().Contains(matchVariable.ToString()));
                // }

            }

            return null;
        }
    }
}