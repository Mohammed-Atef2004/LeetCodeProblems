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
        /// Note: Merges two strings by alternating characters.
        /// It iterates up to the minimum length, then appends the remainder of the longer string.
        /// </summary>
        public string MergeAlternately(string word1, string word2)
        {
            string sol = "";
            int minLength = Math.Min(word1.Length, word2.Length);

            // Append characters alternately from both strings
            for (int i = 0; i < minLength; i++)
            {
                sol += word1[i];
                sol += word2[i];
            }

            // Append the remaining characters of the longer string
            if (word1.Length > word2.Length)
            {
                sol += word1.Substring(minLength);
            }
            else
            {
                sol += word2.Substring(minLength);
            }

            return sol;
        }
    }
}
