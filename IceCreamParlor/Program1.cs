using System;
using System.IO;


public partial class Solution
{
    //static void Main(String[] args)
    //{
    //    var fileStream = new StreamReader(@"custom_input.txt");
    //    int t = Convert.ToInt32(fileStream.ReadLine());
    //    for (int a0 = 0; a0 < t; a0++)
    //    {
    //        int m = Convert.ToInt32(fileStream.ReadLine());
    //        int n = Convert.ToInt32(fileStream.ReadLine());
    //        string[] a_temp = fileStream.ReadLine().Split(' ');
    //        int[] costs = Array.ConvertAll(a_temp, Int32.Parse);
    //        Tuple<int, int>[] costsTuple = new Tuple<int, int>[n];
    //        for (int i = 0; i < costs.Length; i++)
    //        {
    //            costsTuple[i] = new Tuple<int, int>(i + 1, costs[i]);
    //        }
    //        Array.Sort(costsTuple, new TupleComparer());
    //        var upperBound = costsTuple.Length;
    //        if (costsTuple[costsTuple.Length - 1].Item2 > m)
    //        {
    //            var binarySearch = Array.BinarySearch(costsTuple, new Tuple<int, int>(0, m), new TupleComparer());
    //            upperBound = Math.Abs(binarySearch);
    //        }
    //        Tuple<int, int>[] resultedTuple = new Tuple<int, int>[upperBound];

    //        Array.Copy(costsTuple, 0, resultedTuple, 0, upperBound);
    //        PrintSum(resultedTuple, m);
    //    }
    //}
}
