using AOC._2021.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code._2015.Day1
{
    public class Day1 : Solution
    {
        public Day1() : base(2015, 1)
        {
            Part_One();
            Part_Two();
        }

        public int Part_One()
        {
            var commands = Input.ToCharArray();
            var floor = 0;
            foreach (var ch in Input)
            {
                if (ch.Equals('('))
                    floor++;
                else
                    floor--;

            }
            return floor;
        }

        public int Part_Two()
        {
            var commands = Input.ToCharArray();
            var floor = 0;
            var pos = 0;
            var basement = -1;
            foreach (var ch in commands)
            {
                pos++;
                if (ch.Equals('('))
                {
                    floor++;
                    if (floor == -1)
                    {
                        return pos;
                    }
                }

                else
                {
                    floor--;
                    if (floor == -1)
                    {
                        return pos;
                    }
                }


            }
            return pos;
        }
    }
}
