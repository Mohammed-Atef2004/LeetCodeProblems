using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeProblems
{
    public partial class ArrayAndHashingProblems
    {
        public bool CanConstruct(string ransomNote, string magazine)
        {
            string sortedRansom = String.Concat(ransomNote.OrderBy(c => c));
            string sortedMagazine = String.Concat(magazine.OrderBy(c => c));
            int ransomIndex = 0, magazineIndex = 0;

            while (ransomIndex < sortedRansom.Length && magazineIndex < sortedMagazine.Length)
            {
                if (sortedRansom[ransomIndex] == sortedMagazine[magazineIndex])
                {
                    ransomIndex++;
                    magazineIndex++;
                }
                else if (sortedRansom[ransomIndex] > sortedMagazine[magazineIndex])
                {
                    magazineIndex++;
                }
                else
                {
                    return false;
                }
            }
            return ransomIndex == sortedRansom.Length;
        }
    }
}
