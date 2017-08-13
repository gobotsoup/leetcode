using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//http://codercorner.com/RadixSortRevisited.htm
namespace LeetCode
{
    public class RadixSort
    {
        public int[] SortNumbers(int[] nums)
        {
            int[] counters = new int[256];
            int[] results = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                char c = (char)nums[i];
                counters[c] += 1;
            }

            int[] offsetTable = new int[256];            
            for (int i = 1; i < 256; i++)
            {
                offsetTable[i] = offsetTable[i - 1] + counters[i - 1];
            }

            for (int i = 0; i < nums.Length; i++)
            {
                char c = (char)nums[i];
                results[offsetTable[c]++] = c;
            }

            return results;
        }
    }
}
