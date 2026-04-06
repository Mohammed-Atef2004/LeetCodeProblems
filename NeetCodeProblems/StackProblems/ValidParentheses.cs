namespace NeetCodeProblems.StackProblems
{
    public partial class StackProblems
    {

        /// <summary>
        /// Note: Validates proper opening and closing of brackets.
        /// Uses a Stack and a mapping dictionary to ensure brackets are closed in the correct order.
        /// </summary>
        public bool ValidParentheses(string s)
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
                    stack.Push(c); // Push opening brackets
                }
                else if (pairs.ContainsValue(c))
                {
                    // If stack is empty or top bracket doesn't match the closing bracket
                    if (stack.Count == 0 || pairs[stack.Pop()] != c)
                    {
                        return false;
                    }
                }
            }

            return stack.Count == 0;
        }
    }
}