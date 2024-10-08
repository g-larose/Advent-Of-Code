using BenchmarkDotNet.Running;
using Benchmarks._2020.Day1;

namespace Benchmarks
{
    public class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Day1>();
        }
    }
}
