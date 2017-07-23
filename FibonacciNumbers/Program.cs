using System;

namespace FibonacciNumbers
{
    class Solution
    {

        //public static int Fibonacci(int n)
        //{
        //    if (n == 0)
        //        return 0;
        //    var i = 2;
        //    var sum1 = 0;
        //    var sum2 = 1;
            
        //    while (i <= n)
        //    {
        //        var temp = sum1 + sum2;
        //        sum1 = sum2;
        //        sum2 = temp;
        //        i++;
        //    }
        //    return sum2;
        //}

        public static int Fibonacci(int n)
        {
            if (n == 0)
                return 0;
            if (n == 1)
                return 1;
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        static void Main(String[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(Fibonacci(n));
        }
    }
}