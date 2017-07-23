using System;
using System.Collections.Generic;

namespace Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            Player[] player = new Player[n];
            Checker checker = new Checker();

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split(' ');
                player[i] = new Player(line[0], Convert.ToInt32(line[1]));
            }
            
            Array.Sort(player, checker);
            for (int i = 0; i < player.Length; i++)
            {
                Console.WriteLine("{0} {1}\n", player[i].name, player[i].score);
            }
        }
    }

    public class Checker : Comparer<Player>
    {
        public override int Compare(Player x, Player y)
        {
            if (x == null || y == null)
                return 0;
            if (x.score != y.score)
                return y.score.CompareTo(x.score);
            return x.name.CompareTo(y.name);
        }
    }

    public class Player
    {
        public String name;
        public int score;

        public Player(String name, int score)
        {
            this.name = name;
            this.score = score;
        }
    }
}