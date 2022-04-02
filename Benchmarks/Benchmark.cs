using System.Net.Http;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Benchmarks
{
    [MinColumn]
    [MaxColumn]
    public class Benchmarks
    {
        public readonly WebApplicationFactory<WebApplicationMVC.Startup> calcCs = new();
        public readonly WebApplicationFactory<fcalcASP.Startup> calcFc = new();
        private HttpClient _clientCs;
        private HttpClient _clientFs;
        
        
        public Benchmarks()
        {
            _clientCs = calcCs.CreateClient();
            _clientFs = calcFc.CreateClient();
        }
        
        [Benchmark]
        public void PlusCs()
        {
            _clientCs.GetAsync("https://localhost:5001/Calculator/Calculate?var1=1&var=2&operation=plus").GetAwaiter()
                .GetResult();
        }
        [Benchmark]
        public  void PlusFs()
        { 
            _clientFs.GetAsync("https://localhost:5001/Calculator/Calculate?var1=1&var2=2&operation=plus").GetAwaiter().GetResult();
        }
        [Benchmark]
        public void MinusCs()
        {
            _clientCs.GetAsync("https://localhost:5000/Calculator/Calculate?var1=2&var2=1&operation=-").GetAwaiter().GetResult();

        }
        [Benchmark]
        public void MinusFs()
        {
            _clientFs.GetAsync("https://localhost:5001/Calculator/Calculate?var1=1&var2=2&operation=minus").GetAwaiter().GetResult();

        }
    }
}