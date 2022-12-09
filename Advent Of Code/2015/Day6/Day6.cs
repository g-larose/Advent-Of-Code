using AOC._2021.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code._2015.Day6
{
    public class Day6 : Solution
    {
        public Day6() : base(2015, 6)
        {
            Part_One();
            Part_Two();
        }

        public int Part_One()
        {
            var inputCommands = Input.ToLines().ToList();
            var details = inputCommands.Select(x =>x.SplitBy(" ").ToList());
            var commands = new List<(string command, string distance, int x, int y)>();
            foreach (var detail in details)
            {
                var posX = int.Parse(detail[2].Split(',')[0]);
                var posY = int.Parse(detail[4].Split(',')[1]);
                commands.Add((detail[1], detail[3], posX, posY));
            }
            return 1;
        }

        public int Part_Two()
        {
            return 1;
        }
    }
}
