namespace WebApplicationMVC.Calculator
{
    public interface IParser
    {
        public bool CheckIfArgIsInteger(string arg);
        public void CheckArgsLength(string[] args);
        public void CheckIfArgsIsCorrect(string[] args);
    }
}