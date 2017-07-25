using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace ShortestReachInGraph
{
    class Program
    {
        static void Main(string[] args)
        {
            var q = Convert.ToByte(Console.ReadLine());
            
            for (int i = 0; i < q; i++)
            {
                var nmline = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                var n = nmline[0];
                var graph = new Graph(n);
                var m = nmline[1];
                for (int j = 0; j < m; j++)
                {
                    var uvline = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                    var u = uvline[0];
                    var v = uvline[1];
                    graph.AddEdge(u, v);
                }
                var s = Convert.ToInt32(Console.ReadLine());
                graph.PrintDistance(s);
            }
        }
    }

    public class Graph
    {
        private const int DistanceLength = 6;

        public class PriorityNode : Node
        {
            public PriorityNode(Node node,int level) : base(node.Id, node.Adjacents)
            {
                Level = level;
            }

            public int Level { get;  }
        }

        public class Node
        {
            public Node(int id): this(id, new HashSet<Node>())
            {
            }

            public Node(int id, HashSet<Node> adjacents)
            {
                Id = id;
                Adjacents = adjacents;
            }

            public int Id { get; }

            public HashSet<Node> Adjacents { get; set; }

            public override int GetHashCode()
            {
                return Id.GetHashCode();
            }

            public override bool Equals(object obj)
            {
                if (!(obj is Node)) return false;
                return Id.Equals(((Node)obj).Id);
            }

            public static bool operator ==(Node left, Node right)
            {
                return left?.Equals(right) ?? false;
            }

            public static bool operator !=(Node left, Node right)
            {
                return !left?.Equals(right) ?? false;
            }
        }

        public Graph(int nodesCount)
        {
            NodeLookup = new Node[nodesCount];
            for (int i = 0; i < nodesCount; i++)
            {
                NodeLookup[i] = new Node(i);
            }
        }
        public Node[] NodeLookup { get; }

        public void AddEdge(int sourceId, int destId)
        {
            NodeLookup[sourceId - 1].Adjacents.Add(NodeLookup[destId - 1]);
            NodeLookup[destId - 1].Adjacents.Add(NodeLookup[sourceId - 1]);
        }

        public void PrintDistance(int sourceId, int level = 0)
        {
            var sourceNode = NodeLookup[sourceId - 1];

            foreach (var adjacent in NodeLookup)
            {
                if (adjacent != sourceNode)
                //if (!adjacent.Equals(sourceNode))
                    ProcessAdjacent(sourceNode, adjacent);
            }
        }

        private static void ProcessAdjacent(Node sourceNode, Node adjacentToFind)
        {
            var visited = new HashSet<Node>();
            var queue = new Queue<PriorityNode>();
            queue.Enqueue(new PriorityNode(sourceNode, 0));
            while (queue.Any())
            {
                var node = queue.Dequeue();
                if (visited.Contains(node)) continue;
                visited.Add(node);
                    
                if (node.Equals(adjacentToFind))
                {
                    Console.Write("{0} ", node.Level * DistanceLength);
                    return;
                }
                foreach (var nestedAdjacent in node.Adjacents)
                {
                    queue.Enqueue(new PriorityNode(nestedAdjacent, node.Level+1));
                }
            }
            Console.Write("-1 ");
        }
    }
}