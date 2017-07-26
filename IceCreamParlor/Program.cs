using System;
using System.Collections;
using System.Collections.Generic;

public partial class Solution
{

    static void Main(String[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine());
        for (int a0 = 0; a0 < t; a0++)
        {
            int m = Convert.ToInt32(Console.ReadLine());
            int n = Convert.ToInt32(Console.ReadLine());
            string[] a_temp = Console.ReadLine().Split(' ');
            int[] costs = Array.ConvertAll(a_temp, Int32.Parse);
            Tuple<int, int>[] costsTuple = new Tuple<int, int>[n];
            for (int i = 0; i < costs.Length; i++)
            {
                costsTuple[i] = new Tuple<int, int>(i + 1, costs[i]);
            }
            Array.Sort(costsTuple, new TupleComparer());
            var upperBound = costsTuple.Length;
            if (costsTuple[costsTuple.Length - 1].Item2 > m)
            {
                var binarySearch = Array.BinarySearch(costsTuple, new Tuple<int, int>(0, m), new TupleComparer());
                upperBound = Math.Abs(binarySearch);
            }
            Tuple<int, int>[] resultedTuple = new Tuple<int, int>[upperBound];

            Array.Copy(costsTuple, 0, resultedTuple, 0, upperBound);
            PrintSum(resultedTuple, m);
        }
    }

    private static void PrintSum(Tuple<int, int>[] resultedTuple, int money)
    {
        for (int i = 0; i < resultedTuple.Length; i++)
        {
            for (var j = resultedTuple.Length - 1; j > i; j--)
                if (resultedTuple[i].Item2 + resultedTuple[j].Item2 == money)
                {
                    var minId = Math.Min(resultedTuple[i].Item1, resultedTuple[j].Item1);
                    var maxId = Math.Max(resultedTuple[i].Item1, resultedTuple[j].Item1);
                    Console.WriteLine("{0} {1}", minId, maxId);
                    return;
                }
        }
    }
}

public class TupleComparer : IComparer<Tuple<int, int>>, IComparer
{
    public int Compare(Tuple<int, int> x, Tuple<int, int> y)
    {
        return x?.Item2.CompareTo(y?.Item2) ?? 0;
    }

    public int Compare(object x, object y)
    {
        return Compare(x as Tuple<int, int>, y as Tuple<int, int>);
    }
}