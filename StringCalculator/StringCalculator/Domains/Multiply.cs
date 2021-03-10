using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator.Domains
{
    public class Multiply : IElement
    {
        private readonly IEnumerable<IElement> _variables;
        private readonly IEnumerable<IElement> _numbers;

        public Multiply(IEnumerable<IElement> elements)
        {
            _variables = elements.Where(x => !int.TryParse(x.Evaluate(), out _));
            _numbers = elements.Where(x => int.TryParse(x.Evaluate(), out _));
        }

        public string Evaluate()
        {
            int valueSum = 1;
            string variableName = string.Empty;
            
            foreach (var number in _numbers)
            {
                var value = int.Parse((string) number.Evaluate());
                valueSum *= value;
            }

            foreach (var variable in _variables)
            {
                if (variable.Evaluate() != string.Empty)
                {
                    variableName += variable.Evaluate() + "*";   
                }
            }

            if(valueSum == 0) {return "0";}
            else if (variableName == string.Empty)
            {
                return (valueSum > 1) ? valueSum.ToString() : "";
            }
            else
            {
                return (valueSum > 1) ? $"{valueSum}*{variableName.Trim('*')}" : variableName.Trim('*');
            }
        }
    }
}