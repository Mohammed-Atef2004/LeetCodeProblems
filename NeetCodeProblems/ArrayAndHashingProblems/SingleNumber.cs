using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeProblems
{
    public partial class ArrayAndHashingProblems
    {
        public int SingleNumber(int[] nums)
        {
            int xor = 0;
            foreach (int n in nums)
            {
                xor ^= n;
            }
            return xor;
        }
    }
}
