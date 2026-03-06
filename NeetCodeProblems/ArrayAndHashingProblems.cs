using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeProblems
{
    public class ArrayAndHashingProblems
    {
        /// <summary>
        /// Note: Concatenates an array to itself.
        /// Allocates a new array of double size and fills both halves simultaneously.
        /// </summary>
        public int[] GetConcatenation(int[] nums)
        {
            int n = nums.Length;
            int[] result = new int[2 * n];
            for (int i = 0; i < n; i++)
            {
                result[i] = nums[i];
                result[i + n] = nums[i];
            }
            return result;
        }

        /// <summary>
        /// Note: Evaluates if adding extra candies makes each kid have the maximum candies.
        /// First determines the current maximum, then iterates to check each condition.
        /// </summary>
        public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
        {
            int maxCandies = candies.Max();
            List<bool> result = new List<bool>();
            foreach (int candy in candies)
            {
                result.Add(candy + extraCandies >= maxCandies);
            }
            return result;
        }

        /// <summary>
        /// Note: Determines if 'n' flowers can be planted without violating the no-adjacent-flowers rule.
        /// Checks bounds and previous/next positions greedily.
        /// </summary>
        public bool CanPlaceFlowers(int[] flowerbed, int n)
        {
            int count = 0;
            for (int i = 0; i < flowerbed.Length; i++)
            {
                // Check if current spot is empty and adjacent spots are either boundaries or empty
                if (flowerbed[i] == 0 && (i == 0 || flowerbed[i - 1] == 0) && (i == flowerbed.Length - 1 || flowerbed[i + 1] == 0))
                {
                    flowerbed[i] = 1; // Plant the flower to prevent future overlaps
                    count++;
                }
            }
            return count >= n;
        }

        /// <summary>
        /// Note: Calculates the product of an array excluding the current element.
        /// Utilizes prefix (left) and postfix (right) running products to achieve O(N) time without division.
        /// </summary>
        public int[] ProductExceptSelf(int[] nums)
        {
            int n = nums.Length;
            int[] result = new int[n];

            // Calculate left products
            int leftProduct = 1;
            for (int i = 0; i < n; i++)
            {
                result[i] = leftProduct;
                leftProduct *= nums[i];
            }

            // Multiply by right products
            int rightProduct = 1;
            for (int i = n - 1; i >= 0; i--)
            {
                result[i] *= rightProduct;
                rightProduct *= nums[i];
            }
            return result;
        }

        /// <summary>
        /// Note: Determines if there exists an increasing triplet subsequence.
        /// Greedily keeps track of the smallest and second smallest values found so far.
        /// </summary>
        public bool IncreasingTriplet(int[] nums)
        {
            int first = int.MaxValue;
            int second = int.MaxValue;

            foreach (int n in nums)
            {
                if (n <= first)
                    first = n;
                else if (n <= second)
                    second = n;
                else
                    return true; // Found a number greater than both first and second
            }
            return false;
        }

        /// <summary>
        /// Note: Calculates the maximum altitude reached during a trip.
        /// Uses prefix sum to accumulate the altitude changes.
        /// </summary>
        public int LargestAltitude(int[] gain)
        {
            int[] altitudes = new int[gain.Length + 1];
            altitudes[0] = 0;
            int maxAltitude = 0;

            for (int i = 0; i < gain.Length; i++)
            {
                altitudes[i + 1] = altitudes[i] + gain[i];
                maxAltitude = Math.Max(maxAltitude, altitudes[i + 1]);
            }
            return maxAltitude;
        }

        /// <summary>
        /// Note: Finds the pivot index where the sum of elements to the left equals the sum to the right.
        /// Precalculates the total sum to perform comparison in O(1) inside the loop.
        /// </summary>
        public int PivotIndex(int[] nums)
        {
            int totalSum = nums.Sum();
            int leftSum = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                // totalSum - leftSum - nums[i] represents the right sum
                if (leftSum == totalSum - leftSum - nums[i])
                    return i;
                leftSum += nums[i];
            }
            return -1;
        }

        /// <summary>
        /// Note: Simulates adding one to an integer represented by an array of digits.
        /// Handles carry-over logic, including edge cases like 999 turning into 1000.
        /// </summary>
        public int[] PlusOne(int[] digits)
        {
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                if (digits[i] < 9)
                {
                    digits[i]++;
                    return digits;
                }
                digits[i] = 0; // Carry over
            }

            // If the loop finishes, it means all digits were 9
            int[] newDigits = new int[digits.Length + 1];
            newDigits[0] = 1;
            return newDigits;
        }

        /// <summary>
        /// Note: Finds the longest consecutive sequence in an unsorted array.
        /// Uses a HashSet for O(1) lookups. Only starts counting sequences from the lowest number of a sequence.
        /// </summary>
        public int LongestConsecutive(int[] nums)
        {
            int longestStreak = 0;
            HashSet<int> numSet = new HashSet<int>(nums);

            foreach (int num in numSet)
            {
                // Only start evaluating if 'num' is the beginning of a sequence
                if (!numSet.Contains(num - 1))
                {
                    int current = num;
                    int currentStreak = 1;

                    while (numSet.Contains(current))
                    {
                        current++;
                        currentStreak++;
                    }
                    longestStreak = Math.Max(longestStreak, currentStreak);
                }
            }
            return longestStreak;
        }

        /// <summary>
        /// Note: Finds how many days to wait for a warmer temperature.
        /// Current implementation uses sorting and Array.FindIndex which is computationally expensive (O(N^2)). 
        /// Consider using a Monotonic Stack for an optimal O(N) solution.
        /// </summary>
        public int[] DailyTemperatures(int[] temperatures)
        {
            int[] sorted = temperatures; // Note: This references the same array. Cloning is recommended to avoid mutating input.
            Array.Sort(sorted);
            int[] result = (int[])temperatures.Clone();

            for (int i = 0; i < temperatures.Length; i++)
            {
                int firstindex = Array.FindIndex(sorted, x => x == temperatures[i]);
                if (firstindex + 1 < sorted.Length)
                {
                    int value = sorted[firstindex + 1];
                    int index = Array.FindIndex(temperatures, x => x == value);
                    result[i] = index >= i ? index - i : 0;
                }
                else
                {
                    result[i] = 0;
                }
            }
            return result;
        }

        /// <summary>
        /// Note: Checks for duplicates in an array using a HashSet.
        /// Fails fast by returning true as soon as a duplicate is detected.
        /// </summary>
        public bool ContainsDuplicate(int[] nums)
        {
            HashSet<int> seen = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (seen.Contains(nums[i]))
                {
                    return true;
                }
                seen.Add(nums[i]);
            }
            return false;
        }

        /// <summary>
        /// Note: Determines if string 't' is an anagram of string 's' by sorting characters.
        /// Complexity is bounded by sorting O(N log N). Can be optimized to O(N) using a frequency map.
        /// </summary>
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

        /// <summary>
        /// Note: Solves the Two Sum problem using a Dictionary for O(1) lookups.
        /// Current implementation does two passes; it can be optimized to a single pass.
        /// </summary>
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> numToIndex = new Dictionary<int, int>();

            // First pass: populate the dictionary
            for (int i = 0; i < nums.Length; i++)
            {
                numToIndex[nums[i]] = i;
            }

            // Second pass: find the complement
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (numToIndex.ContainsKey(complement) && numToIndex[complement] != i)
                {
                    return new int[] { i, numToIndex[complement] };
                }
            }
            return new int[] { -1, -1 };
        }

        /// <summary>
        /// Note: Groups string anagrams together.
        /// Uses the sorted version of each string as a key in a Dictionary to group matching anagrams.
        /// </summary>
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

        /// <summary>
        /// Note: Returns the 'k' most frequent elements.
        /// Builds a frequency map, then uses LINQ to sort descending by frequency.
        /// </summary>
        public int[] TopKFrequent(int[] nums, int k)
        {
            Dictionary<int, int> frequencyMap = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (!frequencyMap.ContainsKey(nums[i]))
                {
                    frequencyMap[nums[i]] = 0;
                }
                frequencyMap[nums[i]]++;
            }

            var sortedByFrequency = frequencyMap.OrderByDescending(x => x.Value).Take(k);
            return sortedByFrequency.Select(x => x.Key).ToArray();
        }

        /// <summary>
        /// Note: Determines if the ransom note can be constructed from the magazine letters.
        /// Current implementation uses sorting. A frequency map approach would be more efficient (O(N)).
        /// </summary>
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
                    magazineIndex++; // Move forward in the magazine if characters don't match
                }
                else
                {
                    return false; // Character missing from the magazine
                }
            }
            return ransomIndex == sortedRansom.Length;
        }

        /// <summary>
        /// Note: Checks if two strings are isomorphic by establishing a 1-to-1 character mapping.
        /// Maintains two dictionaries to ensure bidirectional mapping validation.
        /// </summary>
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

        /// <summary>
        /// Note: Checks if a string follows a given character pattern.
        /// Similar logic to IsIsomorphic, maintaining bidirectional mapping between chars and words.
        /// </summary>
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

        /// <summary>
        /// Note: Finds the single element in an array where every other element appears twice.
        /// Implemented using a Dictionary map. Bitwise XOR approach would achieve optimal O(1) space.
        /// </summary>
        public int SingleNumber(int[] nums)
        {
            Dictionary<int, bool> frequencyMap = new Dictionary<int, bool>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!frequencyMap.ContainsKey(nums[i]))
                {
                    frequencyMap[nums[i]] = false;
                }
                else
                {
                    frequencyMap[nums[i]] = true;
                    frequencyMap.Remove(nums[i]); // Remove pairs
                }
            }
            return frequencyMap.Keys.FirstOrDefault();
        }

        /// <summary>
        /// Note: Extends the single number concept. 
        /// Current implementation is identical to SingleNumber and may fail if elements appear three times as expected by LeetCode problem SingleNumberII.
        /// </summary>
        public int[] SingleNumberII(int[] nums)
        {
            Dictionary<int, bool> frequencyMap = new Dictionary<int, bool>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!frequencyMap.ContainsKey(nums[i]))
                {
                    frequencyMap[nums[i]] = false;
                }
                else
                {
                    frequencyMap[nums[i]] = true;
                    frequencyMap.Remove(nums[i]);
                }
            }
            return frequencyMap.Keys.ToArray();
        }

        /// <summary>
        /// Note: Finds the majority element (appears more than n/2 times).
        /// Achieved using LINQ GroupBy. Boyer-Moore Voting Algorithm is an O(1) space alternative.
        /// </summary>
        public int MajorityElement(int[] nums)
        {
            var x = nums.GroupBy(n => n).OrderByDescending(g => g.Count()).FirstOrDefault().ToArray();
            return x[0];
        }

        /// <summary>
        /// Note: Finds all numbers in range [1, N] that are missing from the array.
        /// Uses a Dictionary to map present numbers, then checks range [1, N].
        /// </summary>
        public IList<int> FindDisappearedNumbers(int[] nums)
        {
            Dictionary<int, bool> seen = new Dictionary<int, bool>();
            for (int i = 0; i < nums.Length; i++)
            {
                seen[nums[i]] = true;
            }

            List<int> result = new List<int>();
            for (int i = 1; i <= nums.Length; i++)
            {
                if (!seen.ContainsKey(i))
                {
                    result.Add(i);
                }
            }
            return result;
        }

        /// <summary>
        /// Note: Finds the next greater element in nums2 for every element in nums1.
        /// Current implementation uses nested loops O(N*M). A Monotonic Stack approach optimizes this to O(N+M).
        /// </summary>
        public int[] NextGreaterElement(int[] nums1, int[] nums2)
        {
            int[] result = new int[nums1.Length];
            for (int i = 0; i < nums1.Length; i++)
            {
                int indexInNums2 = Array.IndexOf(nums2, nums1[i]);
                result[i] = -1;

                for (int j = indexInNums2 + 1; j < nums2.Length; j++)
                {
                    if (nums2[j] > nums1[i])
                    {
                        result[i] = nums2[j];
                        break;
                    }
                }
            }
            return result;
        }
        
    }
}
