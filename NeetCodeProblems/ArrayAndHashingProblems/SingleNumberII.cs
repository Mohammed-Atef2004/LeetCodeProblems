using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeProblems
{
    public partial class ArrayAndHashingProblems
    {
        public int[] SingleNumberII(int[] nums)
        {
            Dictionary<int, bool> frequencyMap = new Dictionary<int, bool>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!frequencyMap.ContainsKey(nums[i]))
                {
                    frequencyMap[nums[i]] = false;
                }
                else
                {
                    frequencyMap[nums[i]] = true;
                    frequencyMap.Remove(nums[i]);
                }
            }
            return frequencyMap.Keys.ToArray();
        }
    }
}
