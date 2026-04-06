using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeProblems
{
    public partial class ArrayAndHashingProblems
    {
        public bool IsIsomorphic(string s, string t)
        {
            if (s.Length != t.Length)
                return false;

            Dictionary<char, char> mappingST = new Dictionary<char, char>();
            Dictionary<char, char> mappingTS = new Dictionary<char, char>();

            for (int i = 0; i < s.Length; i++)
            {
                char c1 = s[i];
                char c2 = t[i];

                if (!mappingST.ContainsKey(c1))
                {
                    mappingST[c1] = c2;
                }
                else if (mappingST[c1] != c2)
                {
                    return false;
                }

                if (!mappingTS.ContainsKey(c2))
                {
                    mappingTS[c2] = c1;
                }
                else if (mappingTS[c2] != c1)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
