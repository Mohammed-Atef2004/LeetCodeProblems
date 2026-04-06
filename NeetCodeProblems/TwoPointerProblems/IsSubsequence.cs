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
        /// Note: Validates whether string 's' is a valid subsequence of string 't'.
        /// Two pointers traverse the strings. The pointer for 's' only advances on matches.
        /// </summary>
        public bool IsSubsequence(string s, string t)
        {
            int sIndex = 0, tIndex = 0;
            while (sIndex < s.Length && tIndex < t.Length)
            {
                if (s[sIndex] == t[tIndex])
                {
                    sIndex++;
                }
                tIndex++; // Always advance through string t
            }
            // If we've traversed all of s, it is a valid subsequence
            return sIndex == s.Length;
        }
    }
}
