using System;
using System.Collections.Generic;

namespace FindRunningMedian
{
    class Program
    {
        static void Main(String[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] a = new int[n];
            for (int a_i = 0; a_i < n; a_i++)
            {
                var valueToInsert = Convert.ToInt32(Console.ReadLine());
                InsertIntoArraySorted(a, valueToInsert, a_i + 1);
                PrintMedian(a, a_i + 1);
            }
        }

        private static void InsertIntoArraySorted(int[] array, int valueToInsert, int length)
        {
            if (length == 1)
            {
                array[length - 1] = valueToInsert;
                return;
            }
            for (var i = length - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    array[0] = valueToInsert;
                    return;
                }
                if (valueToInsert < array[i-1])
                {
                    array[i] = array[i - 1];
                }
                else
                {
                    array[i] = valueToInsert;
                    return;
                }
            }
        }

        private static void PrintMedian(int[] array, int length)
        {
            int i = 0;
            var avg = 0.0;
            if (length % 2 == 0)
            {
                avg = (array[length / 2 - 1] + array[length / 2]) / 2.0;
            }
            else
            {
                avg = array[length / 2];
            }
            Console.WriteLine("{0:0.0}", avg);

        }
    }
}