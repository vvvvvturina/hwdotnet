using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WebAppHW9.Controllers;

namespace WebAppHW9.Calculator
{
    public class Parser
    {
        public static Expression Parse(string str)
        {
            int count = 0;
            int index = -1;
            for (int i = 0; i < str.Length; i++)
            {
                char varb = str[i];
                if (varb == '(') count++;
                else if (varb == ')') count--;
                else if ((varb is '+' or '-') && count == 0)
                {
                    index = i;
                    break;
                }
                else if ((varb is '*' or '/') && count == 0 && index < 0)
                {
                    index = i;
                }
            }

            if (index < 0)
            {
                str = str.Trim();
                if (str[0] == '(' && str[^1] == ')')
                {
                    return Parse(str.Substring(1, str.Length - 2));
                }

                return Expression.Constant(int.Parse(str));
            }

            return Expression.MakeBinary(ParseOperator(str[index]), Parse(str[..index]), Parse(str[(index + 1)..]));
        }

        private static ExpressionType ParseOperator(char str)
        {
            return str switch
            {
                '+' => ExpressionType.Add,
                '-' => ExpressionType.Subtract,
                '*' => ExpressionType.Multiply,
                '/' => ExpressionType.Divide,
                _ => throw new ArgumentException()
            };
        }
    }
}