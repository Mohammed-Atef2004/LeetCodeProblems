using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeProblems
{
    public partial class ArrayAndHashingProblems
    {
        public int PivotIndex(int[] nums)
        {
            int totalSum = nums.Sum();
            int leftSum = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (leftSum == totalSum - leftSum - nums[i])
                    return i;
                leftSum += nums[i];
            }
            return -1;
        }
    }
}
