using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;
using System.IO;

namespace RansomNote
{
    public class RansomNoteTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public RansomNoteTests(ITestOutputHelper output)
        {
            _testOutputHelper = output;
        }

        [Fact]
        public void ReadSeedData()
        {
            var book = File.ReadAllLines(@"F:\Projects\Testlab\HackerRank.CrackingTheInterview\RansomNote\seed_data.txt").ToList();

            var result = GetResult(book[0].Split(' '), book[1].Split(' '));
            Assert.True(result);
            Console.WriteLine(result ? "YES" : "NO");
        }

        [Theory]
        [InlineData("two times three is not four four", "two times two is four", false)]
        [InlineData("give me one grand today night", "give one grand today", true)]
        public void Test1(string magazineSrc, string ransomSrc, bool expectedResult)
        {
            string[] magazine = magazineSrc.Split(' ');
            string[] ransom = ransomSrc.Split(' ');

            if (magazine.Any(x => x.ToCharArray().Length > 5) || ransom.Any(x => x.ToCharArray().Length > 5))
                throw new InvalidOperationException("word less 5");

            var result = GetResult(magazine, ransom);
            //var result = HashSetNotProperMethod(magazine, ransom);

            Assert.Equal(result, expectedResult);

            Print(result);
        }

        private void Print(bool result)
        {
            if (result)
                _testOutputHelper.WriteLine("Yes");
            else
                _testOutputHelper.WriteLine("No");
        }

        private static bool GetResult(string[] magazine, string[] ransom)
        {
            var hashTable = new Hashtable();
            foreach (var word in magazine)
            {
                if (hashTable.Contains(word))
                { 
                    var currentCount = (int) hashTable[word];
                    hashTable[word] = ++currentCount;
                }
                else
                    hashTable.Add(word, 1);
            }
            foreach (var word in ransom)
            {
                if (!hashTable.Contains(word))
                    return false;
                if ((int) hashTable[word] > 1)
                {
                    var currentCount = (int)hashTable[word];
                    hashTable[word] = --currentCount;
                }
                else
                    hashTable.Remove(word);
            }
            return true;
        }

        private static bool HashSetNotProperMethod(string[] magazine, string[] ransom)
        {
            var magazineHash = new HashSet<string>(magazine, StringComparer.Ordinal);
            var ransomHash = new HashSet<string>(ransom, StringComparer.Ordinal);
            var result = ransomHash.IsSubsetOf(magazine) || magazineHash.IsProperSupersetOf(ransomHash);
            return result;
        }
    }

    
}
