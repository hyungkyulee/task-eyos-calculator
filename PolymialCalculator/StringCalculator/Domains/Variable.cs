using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace StringCalculator.Domains
{
    public class Variable : IElement
    {
        private readonly int _value;
        public string _base { get; private set; }
        public int _power { get; private set; }
        
        public int Value
        {
            get => _value;
        }

        public IEnumerable<IElement> Elements
        {
            get => new[] {new Variable(_value, _base, _power)};
        }

        public Variable(string element)
        {
            var valuePattern = @"[\d]+(?=[a-z]+\^)?";
            var variablePattern = @"(?<=[\d])?[a-z]+";
            var powerPattern = @"(?<=\^)[\d]+";
            
            if(!int.TryParse(new Regex(valuePattern).Match(element).ToString(), out _value) && element != string.Empty) _value = 1;
            _base = new Regex(variablePattern).Match(element).ToString();
            _power = int.Parse(new Regex(powerPattern).Match(element).ToString());
        }
        public Variable(int value, string varBase, int power)
        {
            _value = value;
            _base = varBase;
            _power = power;
        }

        public string Evaluate()
        {
            if (_value == 0) return "0";
            if (_value == 1)
            {
                if (_power == 0) return "1";
                if (_power == 1) return _base;
                return $"{_base}^{_power}";
            }

            if (_power == 0) return _value.ToString();
            if (_power == 1) return $"{_value.ToString()}{_base}";
            return $"{_value.ToString()}{_base}^{_power}";
        }
    }
}