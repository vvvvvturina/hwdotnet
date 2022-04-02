using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using WebApp_11.Calculator;

namespace WebApp_11.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly IExpressionVisitor _expressionVisitor;

        public CalculatorController(IExpressionVisitor expressionVisitor)
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