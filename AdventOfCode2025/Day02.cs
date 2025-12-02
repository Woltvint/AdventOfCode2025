using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2025
{
    internal class Day02 : IDay
    {
        public static void Solve1()
        {
            Shared.WriteHeader("Day 02 (part 1)");

            var ranges = File.ReadAllText("Data/Day02_1.txt").Split(',');

            long result = 0;

            foreach (var range in ranges)
            {
                long start = long.Parse(range.Split('-')[0]);
                long end = long.Parse(range.Split('-')[1]);

                for (long i = start; i <= end; i++)
                {
                    string number = i.ToString();

                    if (number.Length % 2 == 1)
                        continue;

                    string left = number.Substring(0, number.Length / 2);
                    string right = number.Substring(number.Length / 2, number.Length / 2);

                    if (left.Equals(right))
                        result += i;
                }
            }

            Console.WriteLine($"Result: {result}");
        }

        public static void Solve2()
        {
            Shared.WriteHeader("Day 02 (part 2)");

            var ranges = File.ReadAllText("Data/Day02_1.txt").Split(',');

            long result = 0;

            foreach (var range in ranges)
            {
                long start = long.Parse(range.Split('-')[0]);
                long end = long.Parse(range.Split('-')[1]);

                for (long i = start; i <= end; i++)
                {
                    string number = i.ToString();

                    bool good = false;

                    for (int j = 1; j <= number.Length/2; j++)
                    {
                        string pattern = number.Substring(0, j);

                        int found = Regex.Count(number, pattern);

                        if (found * pattern.Length == number.Length)
                            good = true;
                    }

                    if (good)
                        result += i;
                }
            }

            Console.WriteLine($"Result: {result}");
        }
    }
}
