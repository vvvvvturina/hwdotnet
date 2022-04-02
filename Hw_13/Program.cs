using System;
using BenchmarkDotNet.Running;

namespace Hw_13
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Benchmarks>();
        }
    }
}