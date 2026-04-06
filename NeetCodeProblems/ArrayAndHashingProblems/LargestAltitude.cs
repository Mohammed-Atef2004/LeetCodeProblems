using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeProblems
{
    public partial class ArrayAndHashingProblems
    {
        public int LargestAltitude(int[] gain)
        {
            int[] altitudes = new int[gain.Length + 1];
            altitudes[0] = 0;
            int maxAltitude = 0;

            for (int i = 0; i < gain.Length; i++)
            {
                altitudes[i + 1] = altitudes[i] + gain[i];
                maxAltitude = Math.Max(maxAltitude, altitudes[i + 1]);
            }
            return maxAltitude;
        }
    }
}
