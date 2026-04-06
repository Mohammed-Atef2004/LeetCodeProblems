using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeProblems
{
    public partial class TwoPointerProblems
    {
        /// <summary>
        /// Note: Computes maximum container volume between array heights.
        /// Two pointer approach from ends towards middle, retaining the taller boundary to maximize potential area.
        /// </summary>
        public int MaxArea(int[] height)
        {
            int left = 0;
            int right = height.Length - 1;
            int maxArea = 0;

            while (left < right)
            {
                int h = Math.Min(height[left], height[right]);
                int width = right - left;
                maxArea = Math.Max(maxArea, h * width);

                // Greedily move the pointer restricting the height
                if (height[left] < height[right])
                    left++;
                else
                    right--;
            }

            return maxArea;
        }
    }
}
