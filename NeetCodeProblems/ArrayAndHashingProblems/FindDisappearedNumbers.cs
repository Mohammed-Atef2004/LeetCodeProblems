using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeProblems
{
    public partial class ArrayAndHashingProblems
    {
        public IList<int> FindDisappearedNumbers(int[] nums)
        {
            Dictionary<int, bool> seen = new Dictionary<int, bool>();
            for (int i = 0; i < nums.Length; i++)
            {
                seen[nums[i]] = true;
            }

            List<int> result = new List<int>();
            for (int i = 1; i <= nums.Length; i++)
            {
                if (!seen.ContainsKey(i))
                {
                    result.Add(i);
                }
            }
            return result;
        }
    }
}
