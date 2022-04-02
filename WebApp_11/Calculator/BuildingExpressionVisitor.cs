using System;
using System.Linq.Expressions;
using Microsoft.Extensions.Logging;

namespace WebApp_11
{
    public class BuildingExpressionVisitor 
    {
        private readonly ILogger<ExpressionVisitor> _logger;
       
        public BuildingExpressionVisitor(ILogger<ExpressionVisitor> logger)
        {
            _logger = logger;
        }

        private void Visitor(LogLevel logLevel, Exception exception)
        {
            _logger.Log(logLevel,exception.Message);
        }
        private void Visitor(LogLevel logLevel, NullReferenceException exception)
        {
            _logger.Log(logLevel, $"null exception {exception.Message}");
        }
        private void Visitor(LogLevel logLevel, DivideByZeroException exception)
        {
            _logger.Log(logLevel, $"division by zero {exception.Message}");
        }
        private void doVisitor(LogLevel logLevel, Exception exception)
        {
            Visitor(logLevel,(dynamic) exception);
        }
    }
}