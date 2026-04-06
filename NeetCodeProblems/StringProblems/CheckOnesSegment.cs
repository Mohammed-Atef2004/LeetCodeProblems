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
        /// Note: Checks if a binary string has at most one segment of '1's.
        /// Determines if the string contains the substring ""01"", which would indicate multiple segments of '1's.
        /// </summary>
        public bool CheckOnesSegment(string s)
        {
            return !s.Contains(""01"");
        }
    }
}
