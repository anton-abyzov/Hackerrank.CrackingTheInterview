using System;
using System.Collections.Generic;
using System.Linq;
class Solution
{
    private static Stack<int> inbox = new Stack<int>();
    private static Stack<int> outbox = new Stack<int>();

    static void Main(String[] args)
    {
        var q = int.Parse(Console.ReadLine());
        for (var i = 0; i < q; i++)
        {
            var line = Console.ReadLine();
            var splitted = line.Split(' ');
            var type = int.Parse(splitted[0]);
            switch (type)
            {
                case 1:
                    var enqueue = splitted.Select(int.Parse).ToList();
                    enqueue.RemoveAt(0);
                    foreach (var elem in enqueue)
                    {
                        inbox.Push(elem);
                    }

                    break;
                case 2:
                    PrepareQueue();
                    outbox.Pop();
                    break;
                case 3:
                    PrepareQueue();
                    Console.WriteLine(outbox.Peek());
                    break;
            }
        }
    }

    private static void PrepareQueue()
    {
        if (!outbox.Any())
        {
            while (inbox.Any())
            {
                var inboxElem = inbox.Pop();
                outbox.Push(inboxElem);
            }
        }
    }
}