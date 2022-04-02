using System;
using System.Net.Http;
using System.Text;
using JetBrains.dotMemoryUnit;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using Xunit.Abstractions;

namespace TestProject1
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper _helper;
        private readonly HttpClient _client = new WebApplicationFactory<WebApp_13.Startup>().CreateClient();

        public UnitTest1(ITestOutputHelper helper)
        {
            _helper = helper;
            DotMemoryUnitTestOutput.SetOutputMethod(_helper.WriteLine);
        }
        [DotMemoryUnit(CollectAllocations = true, FailIfRunWithoutSupport = false)]
        [Fact]
        public void Test1()
        {
            var point = dotMemory.Check();
            long allocated = 0;
            for (long i = 0; i < 1e5; ++i)
            {
                var str = $"{i}+{i}";
                allocated += Encoding.UTF8.GetBytes(str).Length;
                _client.GetAsync($"https://localhost:5001/Calculator/Calculate?var1=1&var2=2&operation=plus")
                    .GetAwaiter().GetResult();
            }

            dotMemory.Check(memory =>
            {
                _helper.WriteLine(memory.GetTrafficFrom(point).CollectedMemory.SizeInBytes.ToString());
                _helper.WriteLine(allocated.ToString());
                Assert.True(memory.GetTrafficFrom(point).CollectedMemory.SizeInBytes >= allocated);
            });
        }
    }
}