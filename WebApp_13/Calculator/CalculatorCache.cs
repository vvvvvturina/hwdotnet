using System.Collections.Concurrent;
using System.Linq.Expressions;

namespace WebApp_13.Calculator
{
    public class CalculatorCache : IExpressionVisitor
    {
        private IExpressionVisitor _visitor;
        private static readonly ConcurrentDictionary<string, int> Cache = new();
        public CalculatorCache(IExpressionVisitor visitor)
        {
            _visitor = visitor;
        }

        public Expression Visit(Expression expression)
        {
            if (Cache.ContainsKey(expression.ToString()))
            {
                return Expression.Constant(Cache[expression.ToString()]);
            }

            var res = _visitor.Visit(expression) as ConstantExpression;
            Cache[expression.ToString()] = (int) res?.Value!;
            return res;
        }
    }
}