using System;
using System.Linq;
using System.Runtime.InteropServices;
using Xunit;
using Xunit.Abstractions;
using System.Collections.Generic;

namespace Tests
{
    public class StringTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public StringTests(ITestOutputHelper output)
        {
            _testOutputHelper = output;
        }

        [Fact]
        public void IntersectTest()
        {
            //var a = "egabbcdd";
            //var b = "cdddeefg";

            var a = "cde";
            var b = "abc";

            a = string.Join(String.Empty, a.OrderBy(x => x));
            b = string.Join(String.Empty, b.OrderBy(x => x));

            var numberToRemove = 0;
           
            while (a.Length > 0 && b.Length > 0)
            {
                if (a[0] == b[0])
                {
                    a = a.Remove(0, 1);
                    b = b.Remove(0, 1);
                    continue;
                }
                if (a[0] < b[0])
                {
                    a = a.Remove(0, 1);
                    numberToRemove++;
                    continue;
                }
                if (a[0] > b[0])
                {
                    b = b.Remove(0, 1);
                    numberToRemove++;
                }
            }

            //what's left should be removed too
            numberToRemove += a.Length + b.Length;

            _testOutputHelper.WriteLine(numberToRemove.ToString());
        }

        [Fact]
        public void SequenceEqual()
        {
            var a = new List<int>() {1, 2, 3};
            var b = new List<int>() {1, 3, 2};
            a.Sort();
            b.Sort();
            Assert.True(a.SequenceEqual(b));
        }

      
    }
}
