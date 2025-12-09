using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025
{
    internal class Day08 : IDay
    {
        public static void Solve1()
        {
            Shared.WriteHeader("Day 08 (part 1)");

            var lines = File.ReadAllLines("Data/Day08.txt");
            int connectionCount = 1000;

            List<Vector3> boxes = new List<Vector3>();
            List<(Vector3, Vector3)> connections = new List<(Vector3, Vector3)>();

            foreach (var line in lines)
            {
                string[] split = line.Split(',');
                boxes.Add(new Vector3(long.Parse(split[0]), long.Parse(split[1]), long.Parse(split[2])));
            }

            for (int i = 0; i < boxes.Count; i++)
            {
                for (int j = i; j < boxes.Count; j++)
                {
                    if (j == i)
                        continue;
                    /*if (!connections.Contains((boxes[j], boxes[i])))*/
                        connections.Add((boxes[i], boxes[j]));
                }
            }

            connections.Sort((p1, p2) =>
            {
                float d1 = Dist(p1.Item1, p1.Item2);
                float d2 = Dist(p2.Item1, p2.Item2);

                if (d1 > d2)
                    return 1;
                else if (d1 < d2)
                    return -1;
                else
                    return 0;
            });

            

            connections = connections.GetRange(0, connectionCount);

            

            List<List<Vector3>> nets = new List<List<Vector3>>();

            /*foreach (var con in connections)
            {
                Console.WriteLine($"{Dist(con.Item1, con.Item2)} - {con.Item1} -> {con.Item2}");   
            }*/


            while (connections.Count > 0)
            {
                bool run = true;

                for (int i = 0; i < connections.Count && run; i++)
                {
                    for (int j = 0; nets.Count > 0 && j < nets[0].Count && run; j++)
                    {
                        if (nets[0][j] == connections[i].Item1)
                        {
                            run = false;
                            nets[0].Add(connections[i].Item2);
                            //Console.WriteLine($"From {connections[i].Item1} to {connections[i].Item2}");
                            connections.RemoveAt(i);
                            break;
                        }

                        if (nets[0][j] == connections[i].Item2)
                        {
                            run = false;
                            nets[0].Add(connections[i].Item1);
                            //Console.WriteLine($"From {connections[i].Item2} to {connections[i].Item1}");
                            connections.RemoveAt(i);
                            break;
                        }
                    }
                }

                if (run)
                {
                    nets.Insert(0, new List<Vector3>());
                    nets[0].Add(connections[0].Item1);
                    nets[0].Add(connections[0].Item2);
                    //Console.WriteLine($"From {connections[0].Item2} to {connections[0].Item1}");
                    connections.RemoveAt(0);
                }
            }

            for (int i = 0; i < nets.Count; i++)
            {
                nets[i] = nets[i].Distinct().ToList();
            }

            /*foreach (var net in nets)
            {
                Console.Write($"{net.Count}\t");
                foreach (var box in net)
                {
                    Console.Write(box + "\t");
                }
                Console.WriteLine();
            }*/

            long result = 1;

            List<long> counts = new List<long>();
            foreach (var net in nets)
            {
               counts.Add(long.Parse(net.Count.ToString()));
            }

            counts = counts.Distinct().ToList();
            counts.Sort();
            counts.Reverse();

            for (int i = 0; i < 3; i++)
            {
                result *= counts[i];
            }

            Console.WriteLine($"Result {result}");
        }

        public static void Solve2()
        {
            Shared.WriteHeader("Day 08 (part 2)");

            var lines = File.ReadAllLines("Data/Day08.txt");

            List<Vector3> boxes = new List<Vector3>();
            List<(Vector3, Vector3)> connections = new List<(Vector3, Vector3)>();

            foreach (var line in lines)
            {
                string[] split = line.Split(',');
                boxes.Add(new Vector3(long.Parse(split[0]), long.Parse(split[1]), long.Parse(split[2])));
            }

            for (int i = 0; i < boxes.Count; i++)
            {
                for (int j = i; j < boxes.Count; j++)
                {
                    if (j == i)
                        continue;
                    connections.Add((boxes[i], boxes[j]));
                }
            }

            connections.Sort((p1, p2) =>
            {
                float d1 = Dist(p1.Item1, p1.Item2);
                float d2 = Dist(p2.Item1, p2.Item2);

                if (d1 > d2)
                    return 1;
                else if (d1 < d2)
                    return -1;
                else
                    return 0;
            });

            List<List<Vector3>> nets = new List<List<Vector3>>();

            long result = 0;

            while (connections.Count > 0)
            {
                bool run = true;
                (Vector3, Vector3) lastCon = connections[0];

                for (int i = 0; i < connections.Count && run; i++)
                {
                    for (int j = 0; nets.Count > 0 && j < nets[0].Count && run; j++)
                    {
                        if (nets[0][j] == connections[i].Item1)
                        {
                            run = false;
                            nets[0].Add(connections[i].Item2);
                            lastCon = connections[i];
                            //Console.WriteLine($"From {connections[i].Item1} to {connections[i].Item2}");
                            connections.RemoveAt(i);
                            break;
                        }

                        if (nets[0][j] == connections[i].Item2)
                        {
                            run = false;
                            nets[0].Add(connections[i].Item1);
                            lastCon = connections[i];
                            //Console.WriteLine($"From {connections[i].Item2} to {connections[i].Item1}");
                            connections.RemoveAt(i);
                            break;
                        }
                    }
                }

                if (run)
                {
                    nets.Insert(0, new List<Vector3>());
                    nets[0].Add(connections[0].Item1);
                    nets[0].Add(connections[0].Item2);
                    //Console.WriteLine($"From {connections[0].Item2} to {connections[0].Item1}");
                    connections.RemoveAt(0);
                }

                if (nets[0].Distinct().Count() == boxes.Count)
                {
                    result = ((long)lastCon.Item1.X * (long)lastCon.Item2.X);
                    break;
                }
            }

            Console.WriteLine($"Result {result}");
        }


        private static float Dist(Vector3 p1, Vector3 p2) => (p1 - p2).LengthSquared();
    }
}
