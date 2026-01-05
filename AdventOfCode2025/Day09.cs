using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025
{
    internal class Day09 : IDay
    {
        public static void Solve1()
        {
            Shared.WriteHeader("Day 09 (part 1)");

            var lines = File.ReadAllLines("Data/Day09.txt");

            List<Vector2> points = new List<Vector2>();

            foreach (var line in lines)
            {
                int x = int.Parse(line.Split(",")[0]);
                int y = int.Parse(line.Split(",")[1]);
                points.Add(new Vector2(x, y));
            }


            long largestArea = 0;
            int pointAId = 0;
            int pointBId = 0;

            for (int i = 0; i < points.Count; i++)
            {
                for (int j = 0; j < points.Count; j++)
                {
                    long area = (Math.Abs((long)points[i].X - (long)points[j].X)+1) * (Math.Abs((long)points[i].Y - (long)points[j].Y)+1);

                    if (area > largestArea)
                    {
                        largestArea = area;
                        pointAId = i; 
                        pointBId = j;
                    }
                }
            }

            long result = (Math.Abs((long)points[pointAId].X - (long)points[pointBId].X)+1) * (Math.Abs((long)points[pointAId].Y - (long)points[pointBId].Y)+1);

            Console.WriteLine($"Result {result}");
        }

        public static void Solve2()
        {
            Shared.WriteHeader("Day 09 (part 2)");

            var lines = File.ReadAllLines("Data/Day09_test.txt");

            List<Vector2> points = new List<Vector2>();
            List<(Vector2, Vector2)> outline = new List<(Vector2, Vector2)>(); 

            foreach (var line in lines)
            {
                int x = int.Parse(line.Split(",")[0]);
                int y = int.Parse(line.Split(",")[1]);
                points.Add(new Vector2(x, y));

                if (points.Count > 1)
                {
                    var last = points.TakeLast(2).ToArray();
                    outline.Add((last[0], last[1]));
                }
            }

            long largestArea = 0;
            int pointAId = 0;
            int pointBId = 0;

            for (int i = 0; i < points.Count; i++)
            {
                for (int j = 0; j < points.Count; j++)
                {
                    long area = (Math.Abs((long)points[i].X - (long)points[j].X) + 1) * (Math.Abs((long)points[i].Y - (long)points[j].Y) + 1);

                    if (area > largestArea)
                    {
                        largestArea = area;
                        pointAId = i;
                        pointBId = j;
                    }
                }
            }

            long result = (Math.Abs((long)points[pointAId].X - (long)points[pointBId].X) + 1) * (Math.Abs((long)points[pointAId].Y - (long)points[pointBId].Y) + 1);

            Console.WriteLine($"Result {result}");
        }
    }
}
