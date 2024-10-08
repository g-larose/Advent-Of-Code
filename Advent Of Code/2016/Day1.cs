using AOC._2021.Extensions;
using SuperLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code._2016
{
    public class Day1: Solution
    {
        public int direction = 0;
        int x = 0;
        int y = 0;

        public Day1(): base(2016, 1)
        {
            Part_One();
            Part_Two();
        }

        public int Part_One()
        {
            var commands = Input.Split(",");

            for (int i = 0; i < commands.Count(); i++)
            {
                var command = commands[i].ToString().Trim();
                var dir = command!.Substring(0, 1);
                var dist = command!.Substring(1);
                var result = int.TryParse(dist, out int mov);
                Move(dir, mov);
                var test = "";
            }

            return 0;
        }

        public int Part_Two()
        {
            return 0;
        }

        private void Move(string d, int m)
        {
            switch(d)
            {
                case "L":

                    break;
                case "R":

                    break;
            }
        }
    }
}
