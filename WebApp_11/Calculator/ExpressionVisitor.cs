using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace WebApp_11.Calculator
{
    public class ExpressionVisitor : IExpressionVisitor
    {
        protected  Expression VisitBinary(BinaryExpression node)
        {
            Thread.Sleep(1000);
            var right = Task.Run(() => Visit(node.Right));
            var left = Task.Run(() => Visit(node.Left));

            var varb= Task.WhenAll(right, left);
            varb.Wait();
            var rightRes = (double) (varb.Result[0] as ConstantExpression)?.Value!;
            var leftRes = (double) (varb.Result[1] as ConstantExpression)?.Value!;

            var result = node.NodeType switch
            {
                ExpressionType.Add => rightRes+leftRes,
                ExpressionType.Subtract => leftRes-rightRes,
                ExpressionType.Multiply => leftRes*rightRes,
                ExpressionType.Divide => leftRes/rightRes
            };
            return Expression.Constant(result);
        }

        public Expression Visit(Expression expression)
        {
            return expression;
        }
    }
}