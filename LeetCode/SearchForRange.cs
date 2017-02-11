using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class SearchForRange
    {
        public static int[] SearchRange(int[] nums, int target)
        {

            if (nums.Length == 0) return new int[] { -1, -1 };
            return new int[] {FindFirstOccurenceFromLeft(nums, 0, nums.Length - 1, target),
                                FindFirstOccurenceFromRight(nums, 0, nums.Length - 1,target)
            };

            //return FindPositions(nums, 0, nums.Length - 1, target);

        }

        private static int FindFirstOccurenceFromRight(int[] nums, int startIndex, int endIndex, int target)
        {
            if (startIndex < 0 || endIndex > nums.Length - 1 || startIndex > nums.Length - 1 || endIndex < 0 || endIndex < startIndex) return -1;
            int midPoint = (startIndex + endIndex) / 2;
            //if (midPoint == nums.Length - 1)
            //{
            //    return nums[midPoint] != target ? -1 : nums.Length - 1;
            //}
            if (nums[midPoint] == target)
            {
                if (midPoint < nums.Length - 1 && nums[midPoint + 1] == target)
                {
                    return FindFirstOccurenceFromRight(nums, midPoint + 1, endIndex, target);
                }
                else return midPoint;
            }
            if (nums[midPoint] < target && midPoint >= 0)
            {
                //Console.WriteLine(nums[startIndex]);
                return FindFirstOccurenceFromRight(nums, midPoint + 1, endIndex, target);
            }
            else
            {
                return FindFirstOccurenceFromRight(nums, startIndex, midPoint-1, target);
            }
        }

        private static int FindFirstOccurenceFromLeft(int[] nums, int startIndex, int endIndex, int target)
        {
            if (startIndex < 0 || endIndex > nums.Length - 1 || startIndex > nums.Length - 1 || endIndex < 0 || endIndex < startIndex) return -1;
            int midPoint = (startIndex + endIndex) / 2;
            //if (midPoint == 0)
            //{
            //    return nums[midPoint] != target ? -1 : 0;
            //}
            if (nums[midPoint] == target)
            {
                if (midPoint >= 1 && nums[midPoint - 1] == target)
                {
                    return FindFirstOccurenceFromLeft(nums, startIndex, midPoint - 1, target);
                }
                else return midPoint;
            }
            if (nums[midPoint] < target && midPoint >= 0)
            {
                //Console.WriteLine(nums[startIndex]);
                return FindFirstOccurenceFromLeft(nums, midPoint + 1, endIndex, target);
            }
            else
            {
                return FindFirstOccurenceFromLeft(nums, startIndex, midPoint-1, target);
            }
        }

        private int FindFirstOccurence(int[] nums, int startIndex, int endIndex, int target)
        {
            if (nums[startIndex] == target)
            {
                if (nums[startIndex + 1] == target)
                {
                    return FindFirstOccurence(nums, startIndex + 1, endIndex, target);
                }
                else return startIndex;
            }
            if (nums[startIndex] < target)
            {
                return FindFirstOccurence(nums, startIndex + nums.Length / 2, endIndex, target);
            }

            return -1;
        }

        private static int[] FindPositions(int[] nums, int startIndex, int endIndex, int target)
        {
            //Console.WriteLine("{0} {1} {2}", startIndex, endIndex, target);
            if (nums[startIndex] == target && nums[endIndex] == target)
            {
                return new int[] { startIndex, endIndex };
            }
            else if (endIndex == 0 && startIndex == nums.Length - 1)
            {
                return new int[] { -1, -1 };
            }

            else if (nums[startIndex] == target || startIndex == nums.Length - 1)
            {
                int check = endIndex - 1;
                return (FindPositions(nums, startIndex, check, target));
            }
            else if (nums[endIndex] == target || endIndex == 0)
            {
                int check = startIndex + 1;
                return (FindPositions(nums, check, endIndex, target));
            }

            else
            {
                int checkStart = startIndex + 1;
                int checkEnd = endIndex - 1;
                return FindPositions(nums, checkStart, checkEnd, target);
            }

        }
    }
}
