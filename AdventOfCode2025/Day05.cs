using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025
{
    internal class Day05 : IDay
    {
        public static void Solve1()
        {
            Shared.WriteHeader("Day 05 (part 1)");

            var lines = File.ReadAllLines("Data/Day05.txt");

            List<long> rangeStart = new List<long>();
            List<long> rangeEnd = new List<long>();
            List<long> numbers = new List<long>();

            bool readSwitch = false;

            foreach (var line in lines)
            {
                if (line == "")
                {
                    readSwitch = true;
                    continue;
                }
                    

                if (!readSwitch)
                {
                    rangeStart.Add(long.Parse(line.Split("-")[0]));
                    rangeEnd.Add(long.Parse(line.Split("-")[1]));
                }
                else
                {
                    numbers.Add(long.Parse(line));
                }
            }

            int result = 0;

            foreach (var number in numbers)
            {
                for (int i = 0; i < rangeStart.Count; i++)
                {
                    if (rangeStart[i] <= number && number <= rangeEnd[i])
                    {
                        result++;
                        break;
                    }
                }
            }

            Console.WriteLine($"Result {result}");
        }

        public static void Solve2()
        {
            Shared.WriteHeader("Day 05 (part 2)");

            var lines = File.ReadAllLines("Data/Day05.txt");

            List<long> rangeStart = new List<long>();
            List<long> rangeEnd = new List<long>();

            bool readSwitch = false;

            foreach (var line in lines)
            {
                if (line == "")
                {
                    readSwitch = true;
                    continue;
                }

                if (!readSwitch)
                {
                    rangeStart.Add(long.Parse(line.Split("-")[0]));
                    rangeEnd.Add(long.Parse(line.Split("-")[1]));
                }
                else
                {
                    break;
                }
            }

            for (int i = rangeStart.Count-1; i >= 0 ; i--)
            {
                for (int j = 0; j < rangeStart.Count; j++)
                {
                    if (i == j)
                        continue;

                    if (rangeEnd[i] >= rangeStart[j] && rangeEnd[i] <= rangeEnd[j])
                        rangeEnd[i] = rangeStart[j]-1;

                    if (rangeStart[i] > rangeEnd[i])
                    {
                        rangeStart[i] = 0;
                        rangeEnd[i] = 0;
                    }
                }
            }

            long result = 0;

            for (int i = 0; i < rangeStart.Count; i++)
            {
                long res = rangeEnd[i] - rangeStart[i] + 1;

                if (rangeStart[i] == 0 && rangeEnd[i] == 0)
                    res = 0;

                //Console.WriteLine($"{rangeStart[i]}-{rangeEnd[i]}  {res}");
                result += res;
            }

            Console.WriteLine($"Result {result}");
        }
    }
}
