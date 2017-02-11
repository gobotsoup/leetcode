using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class Permutation
    {
        private List<string> _permutations;
        public static void Swap(ref char a, ref char b)
        {
            // Use bitwise XOR
            // https://www.cs.umd.edu/class/sum2003/cmsc311/Notes/BitOp/xor.html

            if (a == b) return;
            a ^= b;
            b ^= a;
            a ^= b;
        }

        public List<string> GetPermutations(string input)
        {
            _permutations = new List<string>();
            char[] inputChars = input.ToCharArray();
            Permute(inputChars, 0, inputChars.Length - 1);

            return _permutations;
        }

        private void Permute(char[] chars, int start, int end)
        {
            if (start == end)
            {
                _permutations.Add(new string(chars));
            }
            else
            {
                for (int i = start; i <= end; i++)
                {
                    Swap(ref chars[start], ref chars[i]);
                    Permute(chars, start + 1, end);
                    // need to swap the chars back to make subsequent permutations
                    Swap(ref chars[start], ref chars[i]);
                }
            }
        }
    }
}
