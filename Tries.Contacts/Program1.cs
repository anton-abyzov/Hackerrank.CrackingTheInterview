using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Ploeh.AutoFixture;

namespace Tries.Contacts
{
    class Program
    {
        static void Main(String[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            var startTime = DateTime.Now;
            var root = new Node();

            var file =
                File.ReadAllLines(@"seed_data3.txt");

            for (int a0 = 0; a0 < n; a0++)
            {
                string[] tokens_op = file[a0].Split(' ');
                string op = tokens_op[0];
                string contact = tokens_op[1];

                switch (op)
                {
                    case "add":
                        root.Populate(contact);
                        break;
                    case "find":
                        Console.WriteLine(root.CountWords(contact));
                        break;
                }
            }
            Console.WriteLine(DateTime.Now - startTime);
        }

        //static void Main(String[] args)
        //{
        //    int n = Convert.ToInt32(Console.ReadLine());
        //    var root = new Node();

        //    for (int a0 = 0; a0 < n; a0++)
        //    {
        //        string[] tokens_op = Console.ReadLine().Split(' ');
        //        string op = tokens_op[0];
        //        string contact = tokens_op[1];

        //        switch (op)
        //        {
        //            case "add":
        //                root.Populate(contact);
        //                break;
        //            case "find":
        //                Console.WriteLine(root.CountWords(contact));
        //                break;
        //        }
        //    }
        //}
    }

    public class Node
    {
        public Node()
        {
            Children = new Dictionary<char, Node>();
        }
        public Dictionary<char, Node> Children { get; set; }
        public bool IsCompleteWord { get; set; }
        public int Size { get; set; }

        public void Populate(string word)
        {
            var rootNode = this;
            for (var i = 0; i < word.Length; i++)
            {
                var character = word[i];
                if (rootNode.Children.ContainsKey(character))
                    rootNode = rootNode.Children[character];
                else
                {
                    var childNode = new Node();
                    rootNode.Children.Add(character, childNode);
                    if (i == word.Length - 1)
                    {
                        childNode.IsCompleteWord = true;
                    }
                    rootNode = childNode;
                }
                rootNode.Size++;
            }
        }

        public int CountWords(string partial)
        {
            var rootNode = this;
            foreach (var character in partial)
            {
                if (!rootNode.Children.ContainsKey(character))
                    return 0;
                rootNode = rootNode.Children[character];
            }
            return rootNode.Size;
            //_count = 0; // should empty count for next calcs
            //CountWords(rootNode);
            //return _count;
        }

        private int _count;
        //private Dictionary<Node, int> memo = new Dictionary<Node, int>();

        private void CountWords(Node rootNode)
        {
            if (rootNode.IsCompleteWord)
                _count++;
            if (!rootNode.Children.Any())
                return;
            foreach (var nodeChild in rootNode.Children)
            {
                CountWords(nodeChild.Value);
            }
        }
    }
}