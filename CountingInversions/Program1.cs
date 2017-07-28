using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
partial class Solution
{
    //static void Main(String[] args)
    //{
    //    var fileStream = new StreamReader("custom_input.txt");
    //    int t = Convert.ToInt32(fileStream.ReadLine());
    //    for (int a0 = 0; a0 < t; a0++)
    //    {
    //        int n = Convert.ToInt32(fileStream.ReadLine());
    //        string[] arr_temp = fileStream.ReadLine().Split(' ');
    //        _temp = new int[n];
    //        int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);
    //        CountInversions(arr, 0, arr.Length - 1);
    //        Console.WriteLine(_count);
    //        _count = 0;
    //    }
    //}


    //static void Main(String[] args)
    //{
    //    var fileStream = new StreamReader("custom_input.txt");
    //    int t = Convert.ToInt32(fileStream.ReadLine());
    //    for (int a0 = 0; a0 < t; a0++)
    //    {
    //        int n = Convert.ToInt32(fileStream.ReadLine());
    //        string[] arr_temp = fileStream.ReadLine().Split(' ');
    //        int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);
    //        //do merge sort, at each merge step...
    //        //...accumulate amount from previous sort steps plus...
    //        //...in merge step every time we take right over left, each item remaining in left represents +1 to count
    //        int[] temp = new int[arr.Length];
    //        long numInversions = MergeSortWithInvCount(arr, 0, arr.Length - 1, temp);
    //        Console.WriteLine(numInversions);
    //    }
    //}

    //static void Main(String[] args)
    //{
    //    int t = Convert.ToInt32(Console.ReadLine());
    //    for (int a0 = 0; a0 < t; a0++)
    //    {
    //        int n = Convert.ToInt32(Console.ReadLine());
    //        string[] arr_temp = Console.ReadLine().Split(' ');
    //        int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);
    //        //do merge sort, at each merge step...
    //        //...accumulate amount from previous sort steps plus...
    //        //...in merge step every time we take right over left, each item remaining in left represents +1 to count
    //        int[] temp = new int[arr.Length];
    //        long numInversions = MergeSortWithInvCount(arr, 0, arr.Length - 1, temp);
    //        Console.WriteLine(numInversions);
    //    }
    //}

    static private long MergeSortWithInvCount(int[] a, int startLeft, int endRight, int[] temp)
    {
        long resultCount = 0;
        if (startLeft >= endRight)
        {
            return 0;
        }
        int middle = (startLeft + endRight) / 2;
        resultCount = MergeSortWithInvCount(a, startLeft, middle, temp);
        resultCount += MergeSortWithInvCount(a, middle + 1, endRight, temp);
        resultCount += MergeResultsWithInvCount(a, startLeft, endRight, temp);

        return resultCount;
    }

    static private long MergeResultsWithInvCount(int[] a, int startLeft, int endRight, int[] temp)
    {
        long resultCount = 0;
        int middle = (startLeft + endRight) / 2;
        int leftIndex = startLeft;
        int rightIndex = middle + 1;
        int destIndex = leftIndex;
        while (destIndex <= endRight)
        {
            if (rightIndex > endRight || (leftIndex <= middle && a[leftIndex] <= a[rightIndex]))
            {
                //in-order, no inversions
                temp[destIndex] = a[leftIndex];
                leftIndex++;
            }
            else
            {
                temp[destIndex] = a[rightIndex];
                rightIndex++;
                //add one per remaining item in left
                resultCount += (middle + 1 - leftIndex);
                //Console.WriteLine("incrementing: " + resultCount);
            }
            destIndex++;
        }
        Array.Copy(temp, startLeft, a, startLeft, (endRight - startLeft + 1));
        //Console.WriteLine(String.Join("", a));
        return resultCount;
    }
}