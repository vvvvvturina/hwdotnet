using System.Reflection;
using BenchmarkDotNet.Attributes;

namespace Hw_13
{
    [MemoryDiagnoser]
    [MinColumn]
    [MaxColumn]
    [MedianColumn]
    [MeanColumn]
    [StdDevColumn]
    public class Benchmarks
    {
        private Tests _tests;
        private string _testStr;
        private static MethodInfo _methodInfo;

        [GlobalSetup]
        public void Setup()
        {
            _tests = new Tests();
            _methodInfo = typeof(Tests).GetMethod("ReflectionMethod");
            _testStr = "aoaoa";
        }

        [Benchmark]
        public void TestMethod()
        {
            _tests.Method(_testStr);
        }

        [Benchmark]
        public void TestVirtual()
        {
            _tests.VirtualMethod(_testStr);
        }

        [Benchmark]
        public void TestStatic()
        {
            Tests.StaticMethod(_testStr);
        }

        [Benchmark]
        public void TestGeneric()
        {
            _tests.GenericMethod(_testStr);
        }

        [Benchmark]
        public void TestReflection()
        {
            _methodInfo.Invoke(_tests, new object[]{_testStr});
        }

        [Benchmark]
        public void TestDynamic()
        {
            _tests.DynamicMethod(_testStr);
        }
    }
}