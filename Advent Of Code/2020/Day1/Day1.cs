using AOC._2021.Extensions;

namespace Advent_Of_Code._2020.Day1
{
    public class Day1: Solution
    {
        public Day1(): base(2020, 1)
        {
            Part_One();
            Part_Two();
        }

        public int Part_One()
        {
            var input = Input.ToLines();
            var ints = input.Select(int.Parse).ToList();
            var result = ints.SelectMany((a, i) => ints.Skip(i + 1), (a, b) => new { a, b })
                              .Where(pair => pair.a + pair.b == 2020)
                              .Select(pair => pair.a * pair.b)
                              .Sum();

            Console.WriteLine(result.ToString());
            return 0;
        }

        public int Part_Two()
        {
            var input = Input.ToLines().Select(int.Parse).ToList();
            var result = input.SelectMany((a, i) => input.Skip(i + 1)
                               .SelectMany((b, j) => input.Skip(j + i + 2)
                               .Select(c => new { a, b, c })))
                               .FirstOrDefault(trip => trip.a + trip.b + trip.c == 2020);
            var trips = result.a * result.b * result.c;
            Console.WriteLine(trips.ToString());             
            return 0;
        }
    }
}
