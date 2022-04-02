using System.Linq.Expressions;

namespace WebApp_11
{
    public interface IExpressionVisitor 
    {
        public  Expression Visit(Expression expression);
    }
}