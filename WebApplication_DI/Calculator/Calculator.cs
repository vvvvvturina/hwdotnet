using System;

namespace WebApplicationMVC.Calculator
{
    public class Calculator : ICalculator
    {
        public enum operation
        {
            Addition,
            Substraction,
            Multiply,
            Division,
            NotOperator
        }
        
        public static Exception NotAnOperatorException = new Exception("The operator doesn't exist.");
        public static Exception CanNotDivideByZero = new Exception("Can not divide by zero.");

        public double Calculate(int a, int b, operation operation)
        {
            double result;
            switch (operation)
            {
                case operation.Addition:
                    result = a + b;
                    break;
                case operation.Division:
                    if (b==0)
                    {
                        throw CanNotDivideByZero;
                    }
                    else
                    {
                        result = a / b;
                    }
                    break;
                case operation.Multiply:
                    result = a * b;
                    break;
                case operation.Substraction:
                    result = a - b;
                    break;
                case operation.NotOperator:
                    throw NotAnOperatorException;
                default:
                    result = 0;
                    break;
            }
            return result;
        }
    }
}