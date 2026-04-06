using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeProblems
{
    public partial class ArrayAndHashingProblems
    {
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
                return false;

            string sortedS = String.Concat(s.OrderBy(c => c));
            string sortedT = String.Concat(t.OrderBy(c => c));

            for (int i = 0; i < sortedS.Length; i++)
            {
                if (sortedS[i] != sortedT[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
