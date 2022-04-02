using System;

namespace WebApplicationMVC.Calculator
{
    public class Parser : IParser
    {
        public bool CheckIfArgIsInteger(string arg)
        {
            return int.TryParse(arg, out int result);
        }


        public void CheckArgsLength(string[] args)
        {
            if (args.Length < 3)
            {
                throw new ArgumentException();
            }
        }
        
        public void CheckIfArgsIsCorrect(string[] args)
        {
            if (CheckIfArgIsInteger(args[0]) == false || CheckIfArgIsInteger(args[2]) == false)
            {
                throw new ArgumentException();
            }
        }

        public Calculator.operation ParseOperator(string arg)
        {
            var oper = arg switch
            {
                "+" => Calculator.operation.Addition,
                "-" => Calculator.operation.Substraction,
                "/" => Calculator.operation.Division,
                "*" => Calculator.operation.Multiply,
                _ => Calculator.operation.NotOperator
            };
            return oper;
        }
    }
}