using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Portability;
using Benchmarks.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Benchmarks._2020.Day1
{
    [MemoryDiagnoser]
    public class Day1: Solution
    { 
        public Day1(): base(2020, 1)
        {
            Part_One_WithLinq();
            Part_One_With_Out_Linq();
        }

        [Benchmark]
        public void Part_One_WithLinq()
        {
            var input = Input.ToLines();
            var ints = input.Select(int.Parse).ToList();
            var result = ints.SelectMany((a, i) => ints.Skip(i + 1), (a, b) => new { a, b })
                              .Where(pair => pair.a + pair.b == 2020)
                              .Select(pair => pair.a * pair.b)
                              .Sum();
        }

        [Benchmark]
        public void Part_One_With_Out_Linq()
        {
            var input = Input.ToLines()
                             .Select(int.Parse).ToList();
            Span<int> spans = CollectionsMarshal.AsSpan(input);
            var r = 0;
            for (int i = 0; i < spans.Length; i+=2)
            {
                var a = input[i];
                var b = input[i+1];
                var result = a + b;

                if (result == 2020)
                    r = a * b;
            }
        }
    }
}
