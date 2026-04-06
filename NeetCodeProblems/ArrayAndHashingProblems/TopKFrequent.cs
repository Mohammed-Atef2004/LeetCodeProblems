using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeProblems
{
    public partial class ArrayAndHashingProblems
    {
        public int[] TopKFrequent(int[] nums, int k)
        {
            Dictionary<int, int> frequencyMap = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (!frequencyMap.ContainsKey(nums[i]))
                {
                    frequencyMap[nums[i]] = 0;
                }
                frequencyMap[nums[i]]++;
            }

            var sortedByFrequency = frequencyMap.OrderByDescending(x => x.Value).Take(k);
            return sortedByFrequency.Select(x => x.Key).ToArray();
        }
    }
}
