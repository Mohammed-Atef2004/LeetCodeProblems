using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeProblems
{
    public partial class TwoPointerProblems
    {
        /// <summary>
        /// Note: Compresses an array of characters in-place (or stringbuilder representation).
        /// Current implementation calculates frequency but utilizes a local StringBuilder result instead of modifying in-place.
        /// </summary>
        public int Compress(char[] chars)
        {
            int[] n = new int[256]; // Assuming expanded character set for safety, though only 'a'-'z' might be tested.
            for (int i = 0; i < chars.Length; i++)
            {
                n[chars[i]]++;
            }

            StringBuilder result = new StringBuilder(); // Recommended replacement for string[] logic.
            for (int i = 0; i < chars.Length; i++)
            {
                if (n[chars[i]] == 1)
                {
                    result.Append(chars[i]);
                    n[chars[i]] = 0; // Reset to avoid double-counting
                }
                else if (n[chars[i]] > 1)
                {
                    result.Append(chars[i]);
                    result.Append(n[chars[i]].ToString());
                    n[chars[i]] = 0;
                }
            }
            return result.Length;
        }
    }
}
