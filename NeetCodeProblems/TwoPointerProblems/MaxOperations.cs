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
        /// Note: Finds maximum number of k-sum pairs.
        /// Array is sorted first, allowing standard two-pointer inward traversal to find sum matches.
        /// </summary>
        public int MaxOperations(int[] nums, int k)
        {
            int left = 0, right = nums.Length - 1;
            int count = 0;
            Array.Sort(nums);

            while (left < right)
            {
                int sum = nums[left] + nums[right];
                if (sum == k)
                {
                    count++;
                    left++;
                    right--;
                }
                else if (sum < k)
                {
                    left++; // Need a larger sum
                }
                else
                {
                    right--; // Need a smaller sum
                }
            }
            return count;
        }
    }
}
