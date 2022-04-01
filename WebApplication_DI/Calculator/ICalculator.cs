namespace WebApplicationMVC.Calculator
{
    public interface ICalculator
    {
        public double Calculate(int arg1, int arg2, Calculator.operation operation);
        public Calculator.operation GetOperator(string operation);
    }
}