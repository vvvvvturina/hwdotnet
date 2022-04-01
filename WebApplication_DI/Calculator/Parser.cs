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
    }
}