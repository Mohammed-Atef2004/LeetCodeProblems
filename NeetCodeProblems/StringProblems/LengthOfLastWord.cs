using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeProblems
{
    public partial class StringProblems
    {
        /// <summary>
        /// Note: Returns the length of the last word in a string.
        /// Splits the string and accesses the final element.
        /// </summary>
        public int LengthOfLastWord(string s)
        {
            string[] words = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (words.Length == 0)
                return 0;
            return words[words.Length - 1].Length;
        }
    }
}
