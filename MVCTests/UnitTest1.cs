using System;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using WebApplicationMVC;
using WebApplicationMVC.Calculator;
using Xunit;

namespace MVCTests
{

    public class UnitTest1
    {
        private ICalculator _calculator = new Calculator();
        private IParser _parser = new Parser();
        private WebApplicationFactory<Startup> _factory;
        private HttpClient _client;
        
        private void Factory()
        {
            _factory = new WebApplicationFactory<Startup>();
        }

        [Theory]
        [InlineData("/")]
        public async Task Get_(string url)
        {
            Factory();
            var client = _factory.CreateClient();
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        
        [Theory]
        [InlineData(3, "+", 1)]
        public async Task CalculateAddition(int arg1, string operation, int arg2)
        {
            var result = _calculator.Calculate(arg1, arg1, _calculator.GetOperator(operation));
            Assert.Equal(4,result);
        }
        
        [Theory]
        [InlineData(3, "*", 1)]
        public async Task CalculateMult(int arg1, string operation, int arg2)
        {
            var result = _calculator.Calculate(arg1, arg1, _calculator.GetOperator(operation));
            Assert.Equal(3,result);
        }
        
        [Theory]
        [InlineData(3, "-", 1)]
        public async Task CalculateSubstraction(int arg1, string operation, int arg2)
        {
            var result = _calculator.Calculate(arg1, arg1, _calculator.GetOperator(operation));
            Assert.Equal(2,result);
        }
        
        [Theory]
        [InlineData(3, "/", 1)]
        public async Task CalculateDivision(int arg1, string operation, int arg2)
        {
            var result = _calculator.Calculate(arg1, arg1, _calculator.GetOperator(operation));
            Assert.Equal(3,result);
        }
        
        [Theory]
        [InlineData(3, "&", 1)]
        public async Task CalculateWrongOper(int arg1, string operation, int arg2)
        {
            try
            {
                var result = _calculator.Calculate(arg1, arg1, _calculator.GetOperator(operation));
            }
            catch (Exception e)
            {
                Assert.Equal("The operator doesn't exist.", e.Message);
            }
        }
    }
}