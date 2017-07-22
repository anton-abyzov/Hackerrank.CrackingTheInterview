using System;
using System.Collections.Generic;

namespace DetectCycle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var linkedList = new Node(1, new Node(2, null));
            PrepareResult(linkedList);
            var linkedList2 = new Node(1, null);
            PrepareResult(linkedList2);

            var node3 = new Node()
            {
                data = 3,
            };
            var node2 = new Node()
            {
                data = 2,
                next = node3
            };
            node3.next = node2;

            var linkedList3 = new Node(1, node2);
            PrepareResult(linkedList3);
        }

        private static void PrepareResult(Node linkedList)
        {
            var result = DetectACycle(linkedList);
            Console.WriteLine(Convert.ToInt16(result));
        }

        private static bool DetectACycle(Node linkedList)
        {
            var hashSet = new HashSet<Node>();
            while (linkedList != null)
            {
                var item = linkedList.next;
                if (hashSet.Contains(item))
                    return true;
                hashSet.Add(item);
                linkedList = item;
            }
            return false;
        }
    }

    class Node
    {
        public Node()
        {
            
        }

        public Node(int data, Node node)
        {
            this.data = data;
            this.next = node;
        }
        public int data;
        public Node next;
    }
}