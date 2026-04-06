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
        /// Note: Shifts all zeroes to the end of the array while maintaining order of non-zero elements.
        /// Effectively overrides early indices with non-zero elements, then pads the rest with zeroes.
        /// </summary>
        public void MoveZeroes(int[] nums)
        {
            int index = 0;
            // Shift non-zeroes forward
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    nums[index++] = nums[i];
                }
            }
            // Fill remaining indices with zeros
            for (int i = index; i < nums.Length; i++)
            {
                nums[i] = 0;
            }
        }
    }
}
