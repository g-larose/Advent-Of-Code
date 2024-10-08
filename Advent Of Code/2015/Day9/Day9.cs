using AOC._2021.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code._2015.Day9
{
    public class Day9: Solution
    {
        public Day9():base(2015, 9)
        {
            Part_One();
        }

        public int Part_One()
        {
            var input = Input.ToLines();
            var shortest = int.Parse(input[0].Split("=")[1]);

            for (int i = 0; i < input.Length; i++)
            {
                var curItem = input[i].Split("=");
                var distance = int.Parse(curItem[1]);
                if (shortest < distance)
                {

                }
                else
                    shortest = distance;
            }
            return 0;
        }

        public long Part_Two()
        {
            return 0;
        }
    }
}
