using System;
using System.Diagnostics.CodeAnalysis;

namespace calculator
{
    [ExcludeFromCodeCoverage]
    class Program
    {
        static void Main(string[] args)
        {
            Parser.CheckArgsLength(args);
            Parser.CheckIfArgsIsCorrect(args);
            var operation = Calculator.GetOperator(args[1]);
            var result = Calculator.Calculate(int.Parse(args[0]), int.Parse(args[2]), operation);
            Console.WriteLine(result);
            
        }
    }
}
