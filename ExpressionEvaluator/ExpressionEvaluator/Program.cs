using System;
using ExpressionEvaluator.Domains;

namespace ExpressionEvaluator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var expression = Console.ReadLine();
            var answer = new Evaluator().Handle(expression);
            Console.WriteLine($"The answer is {answer}");
        }
        
    }
}