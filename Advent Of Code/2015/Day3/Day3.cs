using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code._2015.Day3
{
    public class Day3 : Solution
    {
        public Day3() : base(2015, 3)
        {
            Part_One();
            Part_Two();
        }

        public int Part_One()
        {
            var input = Input.ToCharArray();
            var visited = new HashSet<(int, int)>();
            var delivered = 1;
            int y = 0;
            int x = 0;

            foreach (var item in input)
            {
                switch (item)
                {
                    case '>':
                        x += 1;
                        break;
                    case 'v':
                        y -= 1;
                        break;
                    case '<':
                        x -= 1;
                        break;
                    case '^':
                        y += 1;
                        break;
                    default:
                        break;
                }

                visited.Add((x, y));
                delivered++;

            }
            return visited.Count();
        }

        public int Part_Two()
        {
            var input = Input.ToCharArray();
            var visited = new HashSet<(int, int)>();
            var santaPosX = 0;
            var santaPosY = 0;
            var roboSantaPosX = 0;
            var roboSantaPosY = 0;
            var count = 0;

            foreach (var item in input)
            {
                switch (item)
                {
                    case '>':
                        if (count % 2 == 0)
                        {
                            santaPosX += 1;
                            count++;
                        }
                        else
                        {
                            roboSantaPosX += 1;
                            count++;
                        }

                        break;
                    case 'v':
                        if (count % 2 == 0)
                        {
                            santaPosY -= 1;
                            count++;
                        }
                        else
                        {
                            roboSantaPosY -= 1;
                            count++;
                        }

                        break;
                    case '<':
                        if (count % 2 == 0)
                        {
                            santaPosX -= 1;
                            count++;
                        }
                        else
                        {
                            roboSantaPosX -= 1;
                            count++;
                        }

                        break;
                    case '^':
                        if (count % 2 == 0)
                        {
                            santaPosY += 1;
                            count++;
                        }
                        else
                        {
                            roboSantaPosY += 1;
                            count++;
                        }

                        break;
                    default:
                        break;
                }
                visited.Add((santaPosX, santaPosY));
                visited.Add((roboSantaPosX, roboSantaPosY));
            }
            return visited.Count();
        }
    }
}
