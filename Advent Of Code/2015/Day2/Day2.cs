using AOC._2021.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code._2015.Day2
{
    public class Day2 : Solution
    {
        public Day2() : base(2015, 2)
        {
            Part_One();
            Part_Two();
        }

        public int Part_One()
        {
            var lines = Input.ToLines();
            var totalFeet = 0;
            foreach (string line in lines)
            {
                var dimensions = line.Split('x');
                var sizes = new List<int>();
                var length = int.Parse(dimensions[0]);
                var width = int.Parse(dimensions[1]);
                var height = int.Parse(dimensions[2]);
                var lw = length * width;
                var wh = width * height;
                var hl = height * length;
                var squareFeet = (2 * lw) + (2 * wh) + (2 * hl);
                sizes.Add(lw);
                sizes.Add(wh);
                sizes.Add(hl);
                sizes.Sort();
                var smallestSide = sizes.First();
                totalFeet += squareFeet + smallestSide;

            }

            return totalFeet;
        }

        public int Part_Two()
        {
            var totalFeet = 0;
            var lines = Input.ToLines();
            foreach (var line in lines)
            {
                var dimensions = line.Split("x");
                var sizes = new List<int>();
                var length = int.Parse(dimensions[0]);
                var width = int.Parse(dimensions[1]);
                var height = int.Parse(dimensions[2]);

                sizes.Add(length);
                sizes.Add(width);
                sizes.Add(height);
                sizes.Sort();

                var smallestSideOne = sizes[0];
                var smallestSideTwo = sizes[1];
                var ribbonSizeOne = smallestSideOne + smallestSideOne;
                var ribbonSizeTwo = smallestSideTwo + smallestSideTwo;
                var ribbonArea = ribbonSizeOne + ribbonSizeTwo;
                var area = smallestSideOne * smallestSideTwo * sizes[2] + ribbonArea;
                totalFeet += area;
            }
            return totalFeet;
        }
    }
}
