using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank.CrackingTheInterview
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < t; a0++)
            {
                FindIfBalanced();
            }
        }

        private static void FindIfBalanced()
        {
            string expression = Console.ReadLine();
            if (!expression.Any())
            {
                Console.WriteLine("NO");
                return;
            }
            var stack = new Stack<string>();
            var openingBrackets = new string[] {"(", "[", "{"};
            var closingBrackets = new string[] {")", "]", "}"};
            foreach (var symbol in expression)
            {
                var symbolStr = symbol.ToString();
                if (!stack.Any() && closingBrackets.Contains(symbolStr))
                {
                    Console.WriteLine("NO");
                    return;
                }
                if (openingBrackets.Contains(symbolStr))
                    stack.Push(symbolStr);
                if (!closingBrackets.Contains(symbolStr)) continue;
                var bracketBefore = stack.Pop();
                if (Match(bracketBefore, symbolStr)) continue;
                Console.WriteLine("NO");
                return;
            }
            if (stack.Any())
            {
                Console.WriteLine("NO");
                return;
            }
            Console.WriteLine("YES");
        }

        private static bool Match(string a, string b)
        {
            if (a == "{" && b == "}")
                return true;
            if (a == "[" && b == "]")
                return true;
            if (a == "(" && b == ")")
                return true;
            return false;
        }
    }
}