using System.Linq.Expressions;

namespace WebApp_13.Calculator
{
    public interface IExpressionVisitor
    {
        public Expression Visit(Expression expression);
    }
}