using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC._2021.Extensions
{
    public static class Extensions
    {
        public static string[] ToLines(this string input) => input.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        public static List<int> AsInt32s(this string[] input) => input.Select(x => int.Parse(x)).ToList();
        public static List<int> AsInt32s(this char[] input) => input.Select(x => int.Parse(x.ToString())).ToList();
        public static List<int?> TryAsInt32s(this string[] input) => input.Select(x => int.TryParse(x, out int y) ? (int?)y : null).ToList();
        public static int MisMatchCount(this string input, string other) => input.ToCharArray().Except(other.ToCharArray()).Count() + other.ToCharArray().Except(input.ToCharArray()).Count();
        public static IEnumerable<(int index, T value)> WithIndexes<T>(this IEnumerable<T> values)
        {
            int index = 0;
            foreach (T val in values)
            {
                yield return (index++, val);
            }
        }
        public static List<(int index, Int32 value)> NonNull(this IEnumerable<(int index, Int32? value)> values) => values.Where(x => x.value.HasValue).Select(x => (x.index, x.value.Value)).ToList();
        public static List<long> AsInt64s(this string[] input) => input.Select(x => long.Parse(x)).ToList();
        public static ValueTuple<FirstType, SecondType> As<FirstType, SecondType>(this string[] input, Func<string, FirstType> p1, Func<string, SecondType> p2)
            => (p1(input[0]), p2(input[1]));
        public static ValueTuple<FirstType, SecondType, ThirdType> As<FirstType, SecondType, ThirdType>(this string[] input, Func<string, FirstType> p1, Func<string, SecondType> p2, Func<string, ThirdType> p3)
            => (p1(input[0]), p2(input[1]), p3(input[2]));
        public static ValueTuple<FirstType, SecondType, ThirdType, FourthType> As<FirstType, SecondType, ThirdType, FourthType>(this string[] input, Func<string, FirstType> p1, Func<string, SecondType> p2, Func<string, ThirdType> p3, Func<string, FourthType> p4)
            => (p1(input[0]), p2(input[1]), p3(input[2]), p4(input[3]));
        public static ValueTuple<T, T> AsValueTuple<T>(this IEnumerable<T> input) => (input.First(), input.Skip(1).First());
        public static IEnumerable<string> SplitBy(this string contents, string splitBy)
        {
            int splitLength = splitBy.Length;
            int previousIndex = 0;
            int ix = contents.IndexOf(splitBy);
            while (ix >= 0)
            {
                yield return contents.Substring(previousIndex, ix - previousIndex);
                previousIndex = ix + splitLength;
                ix = contents.IndexOf(splitBy, previousIndex);
            }
            string remain = contents.Substring(previousIndex);
            if (!string.IsNullOrEmpty(remain)) yield return remain;
        }
        public static bool[][] MapAsBool(this string[] lines, char mapAsTrue = '#') => lines.Select(row => row.Select(x => x == mapAsTrue).ToArray()).ToArray();
        public static IEnumerable<(int row, int col)> JustTrue(this bool[][] map)
        {
            bool[] rowData;
            for (int row = 0; row < map.Length; ++row)
            {
                rowData = map[row];
                for (int col = 0; col < rowData.Length; ++col)
                {
                    if (rowData[col]) yield return (row, col);
                }
            }
        }
        public static List<T> With<T>(this List<T> list, T value)
        {
            list.Add(value);
            return list;
        }
        public static List<T> With<T>(this List<T> list, params T[] values)
        {
            list.AddRange(values);
            return list;
        }
        public static long GetModWithOffset(this IEnumerable<(int offset, int value)> values)
        {
            long value = values.First().value, step = value;
            foreach (var record in values.Skip(1))
            {
                while ((value + record.offset) % record.value != 0)
                {
                    value += step;
                }
                step *= record.value;
            }
            return value;
        }
        public static int gcf(this int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
        public static int lcm(this int a, int b)
        {
            return (a / gcf(a, b)) * b;
        }

        public static string SimplifyDayString(this string s) 
        {
            var result = s switch
            {
                "01" => "1",
                "02" => "2",
                "03" => "3",
                "04" => "4",
                "05" => "5",
                "06" => "6",
                "07" => "7",
                "08" => "8",
                "09" => "9",
                _ => s
            };

            return result;
        }
    }


}

