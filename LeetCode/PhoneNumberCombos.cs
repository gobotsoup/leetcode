using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class PhoneNumberCombos
    {
        public static List<string> GetLetterCombos(string inputDigits)
        {
            var results = new List<string>();
            var charmap = new string[] { "0", "1", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };
            results.Add("");
            for (int i = 0; i < inputDigits.Length; i++)
            {
                var tempResults = new List<string>();
                string chars = charmap[inputDigits[i] - '0'];  
                for (int c = 0; c < chars.Length; c++)
                {
                    for (int j = 0; j< results.Count; j++)
                    {
                        tempResults.Add(results[j] + chars[c]);
                    }
                }
                results = tempResults;
            }

            return results;
        }
    }
}
