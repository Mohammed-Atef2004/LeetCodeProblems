using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeProblems
{
    public partial class ArrayAndHashingProblems
    {
        public bool ContainsDuplicate(int[] nums)
        {
            HashSet<int> seen = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (seen.Contains(nums[i]))
                {
                    return true;
                }
                seen.Add(nums[i]);
            }
            return false;
        }
    }
}
