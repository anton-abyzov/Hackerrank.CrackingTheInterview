using System;
using System.Collections.Generic;
using System.Linq;

namespace CoinChange
{
    class Program
    {
        private static int[] _coins;

        static void Main(String[] args)
        {
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int m = Convert.ToInt32(tokens_n[1]);
            string[] coins_temp = Console.ReadLine().Split(' ');
            _coins = Array.ConvertAll(coins_temp, Int32.Parse);

            _memo = new int[n + 1];
            var result = CalcUsingArray(n);
            //var result = CalcWaysToChangeCoinsRecursively(n, new List<int>());
            Console.WriteLine(result);
            foreach (var chain in _chains)
            {
                Console.WriteLine(String.Join("-", chain));
            }

        }

        private static double CalcUsingArray(int banknote)
        {
            var combinationsArray = new double[banknote + 1];
            combinationsArray[0] = 1;
            Array.Sort(_coins);
            foreach (var coin in _coins)
            {
                for (var amount = coin; amount < combinationsArray.Length; amount++)
                {
                    combinationsArray[amount] += combinationsArray[amount - coin];
                }
            }
            return combinationsArray[banknote];
        }

        private static int[] _memo;
        private static List<List<int>> _chains = new List<List<int>>();

        private static int CalcWaysToChangeCoinsRecursively(int banknote, List<int> chain)
        {
            if (banknote < 0)
            {
                chain.RemoveAt(chain.Count - 1);
                return 0;
            }

            if (banknote == 0)
            {
                chain.Sort();
                if (!_chains.Any(chain.SequenceEqual))
                {
                    _chains.Add(chain);
                    return 1;
                }
            }
            if (_memo[banknote] == 0)
            {
                var count = 0;
                foreach (var coin in _coins)
                {
                    chain = new List<int>(chain) { coin };
                    count += CalcWaysToChangeCoinsRecursively(banknote - coin, chain);
                }
                _memo[banknote] = count;

            }
            return _memo[banknote];
        }


        //private static int CalcWaysToChangeCoinsRecursively(int banknote, string path = "")
        //{
        //    if (banknote < 0)
        //    {
        //        return 0;
        //    }

        //    if (banknote == 0)
        //    {
        //        Console.WriteLine(path);
        //        return 1;
        //    }
        //    if (_memo[banknote] == 0)
        //    {
        //        var count = 0;
        //        foreach (var coin in _coins)
        //        {
        //            count += CalcWaysToChangeCoinsRecursively(banknote - coin, path + (path != "" ? "-" : "") + coin);
        //        }
        //        _memo[banknote] = count;

        //    }
        //    return _memo[banknote];
        //}
    }
}