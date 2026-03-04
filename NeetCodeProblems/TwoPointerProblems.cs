using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeProblems
{
    public class TwoPointerProblems
    {
        /// <summary>
        /// Note: Reverses only the vowels present in the string.
        /// Two pointers move inward from ends, swapping characters when both point to vowels.
        /// </summary>
        public string ReverseVowels(string s)
        {
            char[] chars = s.ToCharArray();
            int left = 0, right = s.Length - 1;
            HashSet<char> vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };

            while (left < right)
            {
                while (left < right && !vowels.Contains(chars[left]))
                    left++;
                while (left < right && !vowels.Contains(chars[right]))
                    right--;

                if (left < right)
                {
                    char temp = chars[left];
                    chars[left] = chars[right];
                    chars[right] = temp;
                    left++;
                    right--;
                }
            }
            return new string(chars);
        }

        /// <summary>
        /// Note: Compresses an array of characters in-place (or stringbuilder representation).
        /// Current implementation calculates frequency but utilizes a local string array result instead of modifying in-place.
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

        /// <summary>
        /// Note: Shifts all zeroes to the end of the array while maintaining order of non-zero elements.
        /// Effectively overrides early indices with non-zero elements, then pads the rest with zeroes.
        /// </summary>
        public void MoveZeroes(int[] nums)
        {
            int index = 0;
            // Shift non-zeroes forward
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    nums[index++] = nums[i];
                }
            }
            // Fill remaining indices with zeros
            for (int i = index; i < nums.Length; i++)
            {
                nums[i] = 0;
            }
        }

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

        /// <summary>
        /// Note: Finds maximum number of k-sum pairs.
        /// Array is sorted first, allowing standard two-pointer inward traversal to find sum matches.
        /// </summary>
        public int MaxOperations(int[] nums, int k)
        {
            int left = 0, right = nums.Length - 1;
            int count = 0;
            Array.Sort(nums);

            while (left < right)
            {
                int sum = nums[left] + nums[right];
                if (sum == k)
                {
                    count++;
                    left++;
                    right--;
                }
                else if (sum < k)
                {
                    left++; // Need a larger sum
                }
                else
                {
                    right--; // Need a smaller sum
                }
            }
            return count;
        }

        /// <summary>
        /// Note: Computes maximum container volume between array heights.
        /// Two pointer approach from ends towards middle, retaining the taller boundary to maximize potential area.
        /// </summary>
        public int MaxArea(int[] height)
        {
            int left = 0;
            int right = height.Length - 1;
            int maxArea = 0;

            while (left < right)
            {
                int h = Math.Min(height[left], height[right]);
                int width = right - left;
                maxArea = Math.Max(maxArea, h * width);

                // Greedily move the pointer restricting the height
                if (height[left] < height[right])
                    left++;
                else
                    right--;
            }

            return maxArea;
        }
    }
}
