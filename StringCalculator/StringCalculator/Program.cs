using System;
using StringCalculator.Controllers;

namespace StringCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var expression = Console.ReadLine();
            var result = new Evaluator().Handle(expression);
            Console.WriteLine($"The resut is : {result}");
        }
    }
}