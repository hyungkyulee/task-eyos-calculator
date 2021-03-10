using System.Collections.Generic;
using System.Linq;

namespace StringCalculator.Domains
{
    public class Add : IElement
    {
        private readonly IEnumerable<IElement> _variables;
        private readonly IEnumerable<IElement> _numbers;

        public Add(IElement element)
        {
            if(!int.TryParse(element.Evaluate(), out _)) _variables = new[] {element};
            if(int.TryParse(element.Evaluate(), out _)) _numbers = new[] {element};
        }
        public Add(IEnumerable<IElement> elements)
        {
            _variables = elements.Where(x => !int.TryParse(x.Evaluate(), out _));
            _numbers = elements.Where(x => int.TryParse(x.Evaluate(), out _));
        }
        
        public string Evaluate()
        {
            int valueSum = 0;
            string variableName = string.Empty;

            if (_numbers != null)
            {
                foreach (var number in _numbers)
                {
                    valueSum += int.Parse(number.Evaluate());
                }    
            }

            if (_variables != null)
            {
                foreach (var variable in _variables)
                {
                    variableName += variable.Evaluate() + "+";
                }   
            }

            if (variableName == string.Empty)
            {
                return (valueSum > 0) ? valueSum.ToString() : "";
            }
            else
            {
                return (valueSum > 0) ? $"{valueSum}+{variableName.Trim('+')}" : variableName.Trim('+');
            }
        }
    }
}