namespace NeetCodeProblems
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Solution sol = new Solution();
            string s= "a good   example";
            Console.WriteLine(sol.ReverseWords(s));
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
    }
}
