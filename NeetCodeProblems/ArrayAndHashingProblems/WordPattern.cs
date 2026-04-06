using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeProblems
{
    public partial class ArrayAndHashingProblems
    {
        public bool WordPattern(string pattern, string s)
        {
            string[] arr = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (pattern.Length != arr.Length)
                return false;

            Dictionary<char, string> patternToWord = new Dictionary<char, string>();
            Dictionary<string, char> wordToPattern = new Dictionary<string, char>();

            for (int i = 0; i < pattern.Length; i++)
            {
                char p = pattern[i];
                string w = arr[i];

                if (!patternToWord.ContainsKey(p))
                {
                    patternToWord[p] = w;
                }
                else if (patternToWord[p] != w)
                {
                    return false;
                }

                if (!wordToPattern.ContainsKey(w))
                {
                    wordToPattern[w] = p;
                }
                else if (wordToPattern[w] != p)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
