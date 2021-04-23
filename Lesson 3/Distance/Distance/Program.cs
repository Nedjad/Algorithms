using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Distance
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
            
        }
    }
}
