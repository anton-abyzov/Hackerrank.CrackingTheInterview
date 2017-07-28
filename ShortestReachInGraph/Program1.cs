using System;
using System.IO;

namespace ShortestReachInGraph
{
    class Program1
    {
        static void Main(string[] args)
        {
            var fileStream = new StreamReader( @"seed_data.txt");
            var q = Convert.ToInt32(fileStream.ReadLine());
            for (int i = 0; i < q; i++)
            {
                var nmline = Array.ConvertAll(fileStream.ReadLine().Split(' '), int.Parse);
                var n = nmline[0];
                var graph = new Graph(n);
                var m = nmline[1];
                for (int j = 0; j < m; j++)
                {
                    var uvline = Array.ConvertAll(fileStream.ReadLine().Split(' '), int.Parse);
                    var u = uvline[0];
                    var v = uvline[1];
                    graph.AddEdge(u, v);
                }
                var s = Convert.ToInt32(fileStream.ReadLine());
                graph.PrintDistance(s);
                Console.WriteLine();
            }
        }
    }
}