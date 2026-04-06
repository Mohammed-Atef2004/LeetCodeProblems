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
        /// Note: Finds the greatest common divisor of strings recursively.
        /// It ensures str1 is the longer string, checks for a common prefix, and reduces the problem size.
        /// </summary>
        public string GcdOfStrings(string str1, string str2)
        {
            // Ensure str1 is strictly longer or equal to str2
            if (str1.Length < str2.Length)
                return GcdOfStrings(str2, str1);

            // If str1 does not start with str2, they don't share a common divisor string
            if (!str1.StartsWith(str2))
                return "";

            // If str2 is empty, the GCD string is found
            if (str2 == "")
                return str1;

            // Recursively process the remainder of str1
            return GcdOfStrings(str1.Substring(str2.Length), str2);
        }
    }
}
