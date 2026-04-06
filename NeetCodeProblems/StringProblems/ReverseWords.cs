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
        /// Note: Reverses the words in a given string.
        /// Uses built-in string splitting, array reversal, and joining.
        /// </summary>
        public string ReverseWords(string s)
        {
            // Split by space and remove any empty entries resulting from multiple spaces
            var words = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Array.Reverse(words);
            return string.Join("" "", words);
        }
    }
}
