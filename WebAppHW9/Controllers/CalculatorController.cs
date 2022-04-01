using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using WebAppHW9.Calculator;

namespace WebAppHW9.Controllers
{
    public class CalculatorController : Controller
    {
        public ExpressionVisitor _expressionVisitor;

        public CalculatorController(ExpressionVisitor expressionVisitor)
        {
            _expressionVisitor = expressionVisitor;
        }
        
        [HttpGet, Route("Calculate")]
        public IActionResult Calculate(string str)
        {
            str = str.Replace(" ", "+");
            var t = Parser.Parse(str);
            var visit = _expressionVisitor.Visit(t);
            var varb = (double) (_expressionVisitor.Visit(t) as ConstantExpression)?.Value!;
            return Ok(varb);
        }
    }
}