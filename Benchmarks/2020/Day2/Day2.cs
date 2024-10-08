using BenchmarkDotNet.Attributes;
using Benchmarks.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Benchmarks._2020.Day2
{
    [MemoryDiagnoser]
    public class Day2: Solution
    {
        public Day2(): base(2020, 2)
        {
            Part_One();
        }

        [Benchmark]
        public void Part_One()
        {
            var input = Input.ToLines();
            var valid = 0;

            for (int i = 0; i < input.Length; i++)
            {

                var policy = input[i].Split(":")[0];
                var password = input[i].Split(":")[1].Trim();
                var spaceIndex = policy.IndexOf(" ");
                var dashIndex = policy.IndexOf("-");
                var length = spaceIndex - dashIndex;
                var lowest = int.Parse(policy.Split("-")[0]);
                var highest = int.Parse(policy.Substring(dashIndex + 1, length));
                var letterToContain = policy.Substring(policy.Length - 1);
                var containsCount = 0;
                for (int j = 0; j < password.Length; j++)
                {
                    var curLetter = password[j];
                    if (curLetter.ToString().Equals(letterToContain))
                    {
                        containsCount++;
                    }

                }
                if (containsCount >= lowest && containsCount <= highest)
                    valid++;
            }
        }

        [Benchmark]
        public void Part_Two()
        {
            var input = Input.ToLines();
            var pattern = "(?<index1>\\d+)-(?<index2>\\d+) (?<contains>\\w): (?<pass>\\w+)";
            var regex = new Regex(pattern);

            var valid = 0;
            for (int i = 0; i < input.Length; i++)
            {
                var matches = regex.Match(input[i]);
                var password = matches.Groups["pass"].Value;
                var contains = matches.Groups["contains"].Value;
                var minPosIndex = int.Parse(matches.Groups["index1"].Value) - 1;
                var maxPosIndex = int.Parse(matches.Groups["index2"].Value) - 1;

                if ((password.Substring(minPosIndex, 1).Equals(contains) && password.Substring(maxPosIndex, 1) != contains) ||
                    (password.Substring(maxPosIndex, 1).Equals(contains) && password.Substring(minPosIndex, 1) != contains))
                {
                    valid++;

                }
            }
        }
    }
}
