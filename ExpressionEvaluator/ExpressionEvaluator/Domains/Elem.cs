using System;

namespace ExpressionEvaluator.Domains
{
    public class Elem : IExpr
    {
        public int Number { get; }
        public Elem(string input)
        {
            var totalNumber = 0;
            var cleanedInput = input.Trim();
            for (int i = 0; i < cleanedInput.Length; i++)
            {
                totalNumber += ParseNumber(cleanedInput[i]) * (int)Math.Pow(10, cleanedInput.Length-i-1);
            }
            
            Number = totalNumber;    
        }

        private static int ParseNumber(char input)
        {
            var number = -1;
            switch (input)
            {
                case '0':
                    number = 0;
                    break;
                case '1':
                    number = 1;
                    break;
                case '2':
                    number = 2;
                    break;
                case '3':
                    number = 3;
                    break;
                case '4':
                    number = 4;
                    break;
                case '5':
                    number = 5;
                    break;
                case '6':
                    number = 6;
                    break;
                case '7':
                    number = 7;
                    break;
                case '8':
                    number = 8;
                    break;
                case '9':
                    number = 9;
                    break;
            }

            return number;
        }

        public int Evaluate()
        {
            return Number;
        }
        public string EvaluateVariable()
        {
            return "";
        }
    }
}