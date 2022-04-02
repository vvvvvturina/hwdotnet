using System;
using System.Linq.Expressions;
using System.Threading;
using WebAppHW10;
using WebAppHW10.Models;

namespace WebAppHW10.Calculator
{
    public class CalculatorCache : IExpressionVisitor
    {
        private IExpressionVisitor _visitor;
        private Context _context;
        public CalculatorCache(IExpressionVisitor visitor, Context context)
        {
            _visitor = visitor;
            _context = context;
        }

        public Expression Visit(Expression expression)
        {
            var cache = _context.ExpressionCache.Find(expression.ToString());
            var varb = "varb";
            if (cache != null)
            {
                return Expression.Constant(cache.Value);
            }
            var result = _visitor.Visit(expression) as ConstantExpression;
            _context.ExpressionCache.Add(new ExpressionModel()
            {
                Expression = expression.ToString(),
                Value = (int) result?.Value!
            });
            _context.SaveChanges();
            return result;
        }
    }
}