using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeProblems
{
    public partial class ArrayAndHashingProblems
    {
        public int LongestConsecutive(int[] nums)
        {
            int longestStreak = 0;
            HashSet<int> numSet = new HashSet<int>(nums);

            foreach (int num in numSet)
            {
                if (!numSet.Contains(num - 1))
                {
                    int current = num;
                    int currentStreak = 1;

                    while (numSet.Contains(current + 1))
                    {
                        current++;
                        currentStreak++;
                    }
                    longestStreak = Math.Max(longestStreak, currentStreak);
                }
            }
            return longestStreak;
        }
    }
}
