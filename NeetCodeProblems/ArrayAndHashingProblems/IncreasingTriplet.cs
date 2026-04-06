using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeProblems
{
    public partial class ArrayAndHashingProblems
    {
        public bool IncreasingTriplet(int[] nums)
        {
            int first = int.MaxValue;
            int second = int.MaxValue;

            foreach (int n in nums)
            {
                if (n <= first)
                    first = n;
                else if (n <= second)
                    second = n;
                else
                    return true;
            }
            return false;
        }
    }
}
