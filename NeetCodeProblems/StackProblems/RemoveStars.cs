namespace NeetCodeProblems.StackProblems
{
    public partial class StackProblems
    {
        /// <summary>
        /// Note: Removes characters before an asterisk (*).
        /// Achieved gracefully using a Stack to pop the preceding character whenever an '*' is encountered.
        /// </summary>
        public string RemoveStars(string s)
        {
            Stack<char> stack = new Stack<char>();
            foreach (char c in s)
            {
                if (c != '*')
                {
                    stack.Push(c);
                }
                else if (stack.Count > 0)
                {
                    stack.Pop();
                }
            }
            return new string(stack.Reverse().ToArray());
        }
    }
}