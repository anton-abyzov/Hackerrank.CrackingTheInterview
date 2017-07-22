using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Ploeh.AutoFixture;

namespace Tries.Contacts
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            if (n > 100000)
                throw new InvalidOperationException();
            var contacts = new List<string>();
            var toFind = new List<string>();
            var fixture = new Fixture();
            for (int a0 = 0; a0 < n; a0++)
            {
                string[] tokens_op = Console.ReadLine().Split(' ');
                string op = tokens_op[0];
                string contact = tokens_op[1];
                if (op == "add")
                {
                    if (!contacts.Contains(contact, StringComparer.OrdinalIgnoreCase))
                        contacts.Add(contact);
                }
                    
                if (op == "find")
                    toFind.Add(contact);
            }

            contacts = File.ReadAllLines(@"F:\Projects\Testlab\HackerRank\Tries.Contacts\Tries.Contacts\seed_data.txt").Select(x => x.Split(' ')[1]).ToList();
            //contacts = fixture.CreateMany<string>(8000).Select(x => x.Split(' ')[1]).ToList();

            //toFind.Add("nrmtmci");
            //toFind.Add("ue");
            
            var tries = new Trie(contacts.ToArray());
            foreach (var itemToFind in toFind)
            {
                var result = tries.FindPartialCount(itemToFind);
                Console.WriteLine(result);
            }
        }
    }

    class Node
    {
        public Node()
        {
            Children = new Dictionary<char, Node>();
        }
        public Dictionary<char, Node> Children {get; set; }
        public bool IsCompleteWord { get; set; }
    }

    class Trie
    {
        private Dictionary<char, Node> Tree { get; set; }
        //private KeyValuePair<char, Node> CurrentNode { get; set; }

        public Trie(string[] contacts)
        {
            Tree = new Dictionary<char, Node>();
            var tasks = new List<Task>();
            for (var contactIndex = 0; contactIndex < contacts.Length; contactIndex++)
            {
                var contact = contacts[contactIndex];
                var index = contactIndex;
                var task = Task.Factory.StartNew(() => ProcessContact(contact, index));
                tasks.Add(task);
            }
            Task.WaitAll(tasks.ToArray());
        }

        private void ProcessContact(string contact, int contactIndex)
        {
            if (contact.Length > 21 || contact.Length < 0)
                throw new InvalidOperationException();
            var charArray = contact.ToCharArray();
            var firstChar = charArray[0];
            var upperNode = Tree.ContainsKey(firstChar) ? Tree[firstChar] : new Node() {};
            if (charArray.Length - 1 == contactIndex)
                upperNode.IsCompleteWord = true;
            Tree[firstChar] = upperNode;
            for (var charIndex = 1; charIndex < charArray.Length; charIndex++)
            {
                var ch = charArray[charIndex];
                var nestedNode = upperNode.Children.ContainsKey(ch) ? upperNode.Children[ch] : new Node();
                if (charIndex == charArray.Length - 1)
                    nestedNode.IsCompleteWord = true;
                upperNode.Children[ch] = nestedNode;
                upperNode = nestedNode; //remembering current position
            }
        }

        //public Trie(string[] contacts)
        //{
        //    Tree = new Dictionary<char, Node>();
        //    for (var contactIndex = 0; contactIndex < contacts.Length; contactIndex++)
        //    {
        //        var contact = contacts[contactIndex];
        //        var charArray = contact.ToCharArray();
        //        var firstChar = charArray[0];
        //        var upperNode = Tree.ContainsKey(firstChar) ? Tree[firstChar] : new Node() { };
        //        if (charArray.Length - 1 == contactIndex)
        //            upperNode.IsCompleteWord = true;
        //        Tree[firstChar] = upperNode;
        //        for (var charIndex = 1; charIndex < charArray.Length; charIndex++)
        //        {
        //            var ch = charArray[charIndex];
        //            var nestedNode = upperNode.Children.ContainsKey(ch) ? upperNode.Children[ch] : new Node();
        //            if (charIndex == charArray.Length - 1)
        //                nestedNode.IsCompleteWord = true;
        //            upperNode.Children[ch] = nestedNode;
        //            upperNode = nestedNode; //remembering current position
        //        }
        //    }
        //}

        public Node GetCurrentNode(string input)
        {
            if (!Tree.ContainsKey(input[0]))
                return null;
            Node result = Tree[input[0]];
            for (var i = 1; i < input.Length; i++)
            {
                if (!result.Children.ContainsKey(input[i]))
                    return null;
                result = result.Children[input[i]];
            }
            //CurrentNode = result;
            return result;
        }
       
        public int FindPartialCount(string substring)
        {
            var currentNode = GetCurrentNode(substring);

            if (currentNode == null)
                return 0;

            var result = 0;
            FindAllWords(currentNode, ref result);

            return result;
        }

        private void FindAllWords(Node node, ref int globalCounter)
        {
            if (node.IsCompleteWord)
                globalCounter++;
            if (node.Children == null || !node.Children.Any())
                return;
            foreach (var nodeChildKey in node.Children.Keys)
            {
                FindAllWords(node.Children[nodeChildKey], ref globalCounter);
            }
        }

    }
}