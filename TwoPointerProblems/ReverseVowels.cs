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
    }
}
