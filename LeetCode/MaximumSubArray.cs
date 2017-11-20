using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class MaximumSubArray
    {
        public int MaxSubArray(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;
            int maxFound = nums[0];
            int endIndxMaxFound = 0;
            int startIndxMaxFound = 0;

            for (int startIndx = 0; startIndx < nums.Length; startIndx++)
            {
                int currSum = 0;
                for (int endIndx = startIndx; endIndx < nums.Length; endIndx++)
                {
                    currSum += nums[endIndx];
                    if (currSum > maxFound)
                    {
                        maxFound = currSum;
                        endIndxMaxFound = endIndx;
                        startIndxMaxFound = startIndx;
                    }
                }
            }

            //int[] result = new int[endIndxMaxFound - startIndxMaxFound];
            //Array.Copy(nums, startIndxMaxFound, result, 0, endIndxMaxFound - startIndxMaxFound);
            return maxFound;
        }

        public int MaxSubArryDpStyle(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;
            int maxFound = nums[0];
            int[] dp = new int[nums.Length];
            dp[0] = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                int prevMax = dp[i - 1] > 0 ? dp[i - 1] : 0;
                dp[i] = prevMax + nums[i];
                
                if (dp[i] > maxFound) maxFound = dp[i];
            }

            return maxFound;
        }
    }
}
