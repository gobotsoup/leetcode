using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class ArrayNestingProblem
    {
        public int ArrayNesting(int[] nums)
        {
            int length = nums.Length;
            int longestSet = 0;
            
            for (int setIndex = 0; setIndex < length; setIndex++)
            {
                HashSet<int> setValues = new HashSet<int>();
                int current = nums[setIndex];
                while (setValues.Contains(nums[current]) == false)
                {
                    setValues.Add(nums[current]);
                    current = nums[current];
                }

                if (setValues.Count > longestSet) longestSet = setValues.Count;
            }
            return longestSet;

        }
    }
}
