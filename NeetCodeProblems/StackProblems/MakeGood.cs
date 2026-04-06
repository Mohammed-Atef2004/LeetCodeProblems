using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeProblems.StackProblems
{
    public partial class StackProblems
    {
        /// <summary>
        /// Note: Compares two strings to determine if they are equal when both are typed into empty text editors, where '#' represents a backspace character.
        /// Uses a Stack to simulate the typing process for each string, allowing for efficient handling of backspace operations and comparison of the final results.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public string MakeGood(string s)
        {
            Stack<char> stack = new Stack<char>();
            foreach (char x in s)
            {
                if (stack.Count > 0 && char.ToLower(stack.Peek()) == char.ToLower(x) && stack.Peek() != x)
                {
                    stack.Pop(); // Remove the last character if it forms a bad pair with the current character
                }
                else
                {
                    stack.Push(x); // Otherwise, push the current character onto the stack
                }
            }
            return new string(stack.Reverse().ToArray()); // Construct the resulting string from the stack

        }
    }
}
