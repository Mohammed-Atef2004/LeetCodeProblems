using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeProblems
{
    public partial class ArrayAndHashingProblems
    {
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            Dictionary<string, List<string>> anagramGroups = new Dictionary<string, List<string>>();

            foreach (string str in strs)
            {
                char[] chars = str.ToCharArray();
                Array.Sort(chars);
                string sortedStr = new string(chars);

                if (!anagramGroups.ContainsKey(sortedStr))
                {
                    anagramGroups[sortedStr] = new List<string>();
                }
                anagramGroups[sortedStr].Add(str);
            }

            IList<IList<string>> result = new List<IList<string>>();
            foreach (var group in anagramGroups)
            {
                result.Add(group.Value);
            }
            return result;
        }
    }
}
