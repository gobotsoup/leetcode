using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class ContainerWithMostWater
    {
        public int MaxArea(int[] height)
        {
            int maxArea = 0;
            int left = 0;
            int right = height.Length - 1;

            while (right > left)
            {
                int area = GetAreaForPoints(height[left], height[right], left, right);
                if (area > maxArea) maxArea = area;
                if (height[right] > height[left]) left++;
                else right--;
            }

            return maxArea;
        }

        private int GetAreaForPoints(int x, int y, int indexX, int indexY)
        {
            int height = Math.Min(x, y);
            int width = Math.Abs(indexX - indexY);

            return height * width;
        }
    }
}
