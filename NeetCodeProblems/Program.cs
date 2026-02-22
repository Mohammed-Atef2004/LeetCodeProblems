using System.Numerics;

namespace NeetCodeProblems
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Solution sol = new Solution();
            int[] nums = new int[] { 1, 7, 3, 6, 5, 6 };
            for(int i = 0; i < nums.Length; i++)
            {
                Console.WriteLine($"nums[{i}]: {nums[i]}");
            }
            Console.WriteLine(sol.PivotIndex(nums));
        }
    }
    public class Solution
    {
        public string MergeAlternately(string word1, string word2)
        {
            string sol = "";

            int minLength = Math.Min(word1.Length, word2.Length);

            for (int i = 0; i < minLength; i++)
            {
                sol += word1[i];
                sol += word2[i];
            }

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
        public string GcdOfStrings(string str1, string str2)
        {
            if (str1.Length < str2.Length)
                return GcdOfStrings(str2, str1);
            if (!str1.StartsWith(str2))
                return "";
            if (str2 == "")
                return str1;
            return GcdOfStrings(str1.Substring(str2.Length), str2);

        }
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
        public bool CanPlaceFlowers(int[] flowerbed, int n)
        {
            int count = 0;
            for (int i = 0; i < flowerbed.Length; i++)
            {
                if (flowerbed[i] == 0 && (i == 0 || flowerbed[i - 1] == 0) && (i == flowerbed.Length - 1 || flowerbed[i + 1] == 0))
                {
                    flowerbed[i] = 1;
                    count++;
                }
            }
            return count >= n;

        }
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
        public string ReverseWords(string s)
        {
            var words = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Array.Reverse(words);
            return string.Join(" ", words);
        }
        public int[] ProductExceptSelf(int[] nums)
        {

            int n = nums.Length;
            int[] result = new int[n];
            int leftProduct = 1;
            for (int i = 0; i < n; i++)
            {
                result[i] = leftProduct;
                leftProduct *= nums[i];
            }
            int rightProduct = 1;
            for (int i = n - 1; i >= 0; i--)
            {
                result[i] *= rightProduct;
                rightProduct *= nums[i];
            }
            return result;
        }
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
                    return true; // found third number
            }

            return false;
        }
        public int Compress(char[] chars)
        {
            int []n = new int[chars.Length];
            for(int i = 0; i < chars.Length; i++)
            {
                n[chars[i] - 'a']++;
            }
            string[]result = new string[chars.Length];
            for(int i = 0; i < chars.Length; i++)
            {
                if (n[chars[i] - 'a'] == 1)
                {
                    result.Append(chars[i].ToString());

                }
                else if (n[chars[i] - 'a'] > 1)
                {
                    result.Append(chars[i].ToString());
                    result.Append(n[chars[i]-'a'].ToString());
                    n[chars[i] - 'a'] = 0;
                }
                else continue;
            }

            return result.Length;
        }
        public int LargestAltitude(int[] gain)
        {
            int[] altitudes = new int[gain.Length + 1];
            altitudes[0] = 0;
            int maxAltitude = 0;
            for(int i = 0; i < gain.Length; i++)
            {
                altitudes[i + 1] = altitudes[i]+gain[i];
                maxAltitude = Math.Max(maxAltitude, altitudes[i + 1]);
            }
            return maxAltitude;
        }
        public int PivotIndex(int[] nums)
        {
            int totalSum = nums.Sum();
            int leftSum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (leftSum == totalSum - leftSum - nums[i])
                    return i;
                leftSum += nums[i];
            }
            return -1;
        }
        public string RemoveStars(string s)
        {
            Stack<char> stack = new Stack<char>();
            foreach (char c in s)
            {
              if(c!='*')
                {
                    stack.Push(c);
                }
                else if(stack.Count > 0)
                {
                    stack.Pop();
                }
            }
            return new string(stack.Reverse().ToArray());

        }
        public int[] AsteroidCollision(int[] asteroids)
        {
            Stack<int> stack = new Stack<int>();
            foreach (int asteroid in asteroids)
            {
                while (stack.Count > 0 && asteroid < 0 && stack.Peek() > 0)
                {
                    int top = stack.Peek();
                    if (top < -asteroid)
                    {
                        stack.Pop();
                    }
                    else if (top == -asteroid)
                    {
                        stack.Pop();
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                if (stack.Count == 0 || asteroid > 0 || stack.Peek() < 0)
                {
                    stack.Push(asteroid);
                }
            }
            return stack.Reverse().ToArray();

        }
        public int[] PlusOne(int[] digits)
        {
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                if (digits[i] < 9)
                {
                    digits[i]++;
                    return digits;
                }
                digits[i] = 0;
            }
            int[] newDigits = new int[digits.Length + 1];
            newDigits[0] = 1;
            return newDigits;
        }
        public void MoveZeroes(int[] nums)
        {
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    count++;
                }
            }
            int index = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    nums[index++] = nums[i];
                }
            }
            for (int i = index; i < nums.Length; i++)
            {
                nums[i] = 0;

            }
        }
        public bool IsSubsequence(string s, string t)
        {
            int sIndex = 0, tIndex = 0;
            while (sIndex < s.Length && tIndex < t.Length)
            {
                if (s[sIndex] == t[tIndex])
                {
                    sIndex++;
                }
                tIndex++;
            }
            return sIndex == s.Length;

        }
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
                    left++;
                }
                else
                {
                    right--;
                }
            }
            return count;

        }
        public bool ValidParenthes(string s)
        {
            Stack<char> stack = new Stack<char>();
            Dictionary<char, char> pairs = new Dictionary<char, char>
            {
                { '(', ')' },
                { '{', '}' },
                { '[', ']' }
            };
            foreach (char c in s)
            {
                if (pairs.ContainsKey(c))
                {
                    stack.Push(c);
                }
                else if (pairs.ContainsValue(c))
                {
                    if (stack.Count == 0 || pairs[stack.Pop()] != c)
                    {
                        return false;
                    }
                }
            }
            return stack.Count == 0;

        }
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
        public ListNode ReverseList(ListNode head)
        {
            ListNode prev = null;
            ListNode current = head;
            while (current != null)
            {
                ListNode nextTemp = current.next;
                current.next = prev;
                prev = current;
                current = nextTemp;
            }
            return prev;

        }
    }
    public class MinStack
    {
        public Stack<int> stack;
        public MinStack()
        {
          stack = new Stack<int>();
        }

        public void Push(int val)
        {
            stack.Push(val);
        }

        public void Pop()
        {
            stack.Pop();
        }

        public int Top()
        {
            return stack.Peek();
        }

        public int GetMin()
        {
            return stack.Min();
        }
    }
    
    }
