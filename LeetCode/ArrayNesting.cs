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
            var visited = new Dictionary<int, int>();
            for (int setIndex = 0; setIndex < length; setIndex++)
            {
                HashSet<int> setValues = new HashSet<int>();
                int current = nums[setIndex];
                while (setValues.Contains(nums[current]) == false && !alreadyVisited(visited, 0, current))
                {
                    setValues.Add(nums[current]);
                    visited[current] = setValues.Count;
                    current = nums[current];
                }

                if (setValues.Count > longestSet) longestSet = setValues.Count;
            }
            return longestSet;
        }

        private bool alreadyVisited(Dictionary<int, int> visited, int currentLength, int value)
        {
            if (visited.ContainsKey(value) == false) return false;
            int visitedLength = visited[value];
            if (visitedLength > currentLength) return true;
            return false;
        }
    }
}
