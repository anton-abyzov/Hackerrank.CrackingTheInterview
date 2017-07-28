using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
partial class Solution
{
    static void Main(String[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine());
        for (int a0 = 0; a0 < t; a0++)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] arr_temp = Console.ReadLine().Split(' ');
            _temp = new int[n];
            int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);
            CountInversions(arr, 0, arr.Length - 1);
            Console.WriteLine(_count);
            _count = 0;
        }
    }

    private static int[] _temp;
    private static long _count;

    private static void CountInversions(int[] arr, int start, int end)
    {
        if (start >= end)
            return;

        var mid = (start + end) / 2;
        CountInversions(arr, start, mid);
        CountInversions(arr, mid + 1, end);
        Merge(arr, start, end);
    }

    private static void Merge(int[] arr, int start, int end)
    {
        var mid = (start + end) / 2;
        var leftIndex = start;
        var rightIndex = mid + 1;
        var tempIndex = start;
        while (leftIndex <= mid && rightIndex <= end)
        {
            if (arr[leftIndex] <= arr[rightIndex])
            {
                _temp[tempIndex++] = arr[leftIndex++];
            }
            else
            {
                _temp[tempIndex++] = arr[rightIndex++];
                _count += mid - leftIndex + 1;
            }
        }

        Array.Copy(arr, leftIndex, _temp, tempIndex, mid - leftIndex + 1); // +1 coz it's actually cound of elements
        Array.Copy(arr, rightIndex, _temp, tempIndex, end - rightIndex + 1);
        Array.Copy(_temp, start, arr, start, end - start + 1);
    }
}
