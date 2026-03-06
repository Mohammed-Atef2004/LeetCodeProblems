using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeProblems
{
    /// <summary>
    /// Shared definition for Linked List nodes used across multiple problems.
    /// </summary>
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    // ==========================================
    // Category 1: String Problems
    // ==========================================
    public class StringProblems
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

        /// <summary>
        /// Note: Reverses the words in a given string.
        /// Uses built-in string splitting, array reversal, and joining.
        /// </summary>
        public string ReverseWords(string s)
        {
            // Split by space and remove any empty entries resulting from multiple spaces
            var words = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Array.Reverse(words);
            return string.Join(" ", words);
        }

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
        /// <summary>
        ///Note: Checks if a binary string has at most one segment of '1's.
        ///to determine if the string contains the substring "01", which would indicate multiple segments of '1's.
        /// </summary>
        public bool CheckOnesSegment(string s)
        {
            return !s.Contains("01");
        }
    }
}
