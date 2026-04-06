using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeProblems
{
    public partial class ArrayAndHashingProblems
    {
        public int MajorityElement(int[] nums)
        {
            var x = nums.GroupBy(n => n).OrderByDescending(g => g.Count()).FirstOrDefault().ToArray();
            return x[0];
        }
    }
}
