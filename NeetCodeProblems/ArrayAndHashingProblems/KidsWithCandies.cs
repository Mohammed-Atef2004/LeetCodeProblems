using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeProblems
{
    public partial class ArrayAndHashingProblems
    {
        public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
        {
            int maxCandies = candies.Max();
            List<bool> result = new List<bool>();
            foreach (int candy in candies)
            {
                result.Add(candy + extraCandies >= maxCandies);
            }
            return result;
        }
    }
}
