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
            for (int i = 0; i < height.Length; i++)
            {
                for (int j = i + 1; j < height.Length; j++)
                {
                    int area = GetAreaForPoints(height[i], height[j], i, j);
                    if (area > maxArea) maxArea = area;
                }
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
