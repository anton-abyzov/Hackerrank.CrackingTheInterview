using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BitManipulation
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    int n = Convert.ToInt32(Console.ReadLine());
        //    string[] a_temp = Console.ReadLine().Split(' ');
        //    int[] a = Array.ConvertAll(a_temp, int.Parse);
        //    var unique = a.ToList().GroupBy(x => x, (x) => x).FirstOrDefault(x => x.Count() == 1);
        //    Console.WriteLine(unique.Key);
        //}

        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] a_temp = Console.ReadLine().Split(' ');
            int[] a = Array.ConvertAll(a_temp, int.Parse);
            var result = 0;
            for (var i = 0; i < a.Length; i++)
            {
                result = a[i] ^ result;
            }
            Console.WriteLine(result);
        }
    }
}