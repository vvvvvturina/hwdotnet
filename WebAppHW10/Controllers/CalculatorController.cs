using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using WebAppHW10.Calculator;

namespace WebApp_10.Controllers
{
    public class CalculatorController : Controller
    {
        public ExpressionVisitor ExpressionVisitor;
        
        [HttpGet, Route("Calculate")]
        public IActionResult Calculate(string str)
        {
            str = str.Replace(" ", "+");
            var t = Parser.Parse(str);
            var visit = ExpressionVisitor.Visit(t);
            var varb = (double) (ExpressionVisitor.Visit(t) as ConstantExpression)?.Value!;
            return Ok(varb);
        }
    }
}