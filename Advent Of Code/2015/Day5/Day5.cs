using AOC._2021.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code._2015.Day5
{
    public class Day5 : Solution
    {
        public Day5() : base(2015, 5)
        {
            Part_One();
            Part_Two();
        }

        public void Part_One()
        {
            var lines = Input.ToLines().ToList();
            var count = 0;

            foreach (var line in lines)
            {
                var threeVowels = line.Count(ch => "aeiou".Contains(ch)) >= 3;
                var duplicate = Enumerable.Range(0, line.Length - 1).Any(i => line[i] == line[i + 1]);
                var reserved = "ab,cd,pq,xy".Split(',').Any(line.Contains);

                if (threeVowels && duplicate && !reserved)
                    count++;
            }
            Console.WriteLine(count);
        }

        public void Part_Two()
        {
            var lines = Input.ToLines().ToList();
            var count = 0;

            foreach (var line in lines)
            {
                var appearsTwice = Enumerable.Range(0, line.Length - 1).Any(i => line.IndexOf(line.Substring(i, 2), i + 2) >= 0);
                var repeats = Enumerable.Range(0, line.Length - 2).Any(i => line[i] == line[i + 2]);

                if (appearsTwice && repeats) count++;
            }
            Console.WriteLine($"Part Two: {count}");
        }
    }
}
