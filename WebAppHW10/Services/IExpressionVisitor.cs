using System.Linq.Expressions;

namespace WebAppHW10.Calculator
{
    public interface IExpressionVisitor 
    {
        public Expression Visit(Expression expression);
    }
}