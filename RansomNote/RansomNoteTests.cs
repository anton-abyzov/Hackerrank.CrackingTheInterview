using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

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
        public void Test1()
        {
           
            string[] magazine = "give Me".Split(' ');
            string[] ransom = "give me".Split(' ');
            //string[] magazine = "give me one Grand today Night".Split(' ');
            //string[] ransom = "give one grand today".Split(' ');

            if (magazine.Any(x => x.ToCharArray().Length > 5) || ransom.Any(x => x.ToCharArray().Length > 5))
                throw new InvalidOperationException("word less 5");

            var magazineHash = new HashSet<string>(magazine, StringComparer.Ordinal);
            var ransomHash = new HashSet<string>(ransom, StringComparer.Ordinal);

            foreach (var mag in magazineHash)
            {
                _testOutputHelper.WriteLine(mag);
            }

            //magazineHash.IsProperSupersetOf(ransomHash) 
            //var result = ransomHash.IsSubsetOf(magazine) && magazineHash.IsProperSupersetOf(ransomHash);
            //var result = magazineHash.Overlaps(ransomHash);
            //_testOutputHelper.WriteLine(result.ToString());
            //Assert.True(result);


        }

        
    }

    
}
