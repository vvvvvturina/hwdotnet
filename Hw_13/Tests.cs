namespace Hw_13
{
    public class Tests
    {
        public string Method(string str)
        {
            str += str;
            return str;
        }

        public virtual string VirtualMethod(string str)
        {
            str += str;
            return str;
        }

        public static string StaticMethod(string str)
        {
            str += str;
            return str;
        }

        public string GenericMethod<T>(T str)
        {
            return str.ToString() + str;
        }

        public string DynamicMethod(string str)
        {
            str += str.ToString();
            return str;
        }

        public string ReflectionMethod(string str)
        {
            str += str;
            return str;
        }
    }
}