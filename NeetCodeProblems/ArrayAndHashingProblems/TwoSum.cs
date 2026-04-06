using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeProblems
{
    public partial class ArrayAndHashingProblems
    {
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> numToIndex = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                numToIndex[nums[i]] = i;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (numToIndex.ContainsKey(complement) && numToIndex[complement] != i)
                {
                    return new int[] { i, numToIndex[complement] };
                }
            }
            return new int[] { -1, -1 };
        }
    }
}
