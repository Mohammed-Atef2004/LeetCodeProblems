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
        public bool BackspaceCompare(string s, string t)
        {
            Stack<char> stackS = new Stack<char>();
            Stack<char> stackT = new Stack<char>();
            foreach (char c in s)
            {
                if (c == '#')
                {
                    if (stackS.Count > 0)
                    {
                        stackS.Pop(); // Simulate backspace for string s
                    }
                }
                else
                {
                    stackS.Push(c); // Push character onto stack for string s
                }
            }
            foreach (char c in t)
            {
                if (c == '#')
                {
                    if (stackT.Count > 0)
                    {
                        stackT.Pop(); // Simulate backspace for string t
                    }
                }
                else
                {
                    stackT.Push(c); // Push character onto stack for string t
                }
            }
            // Compare the final contents of both stacks
            return stackS.SequenceEqual(stackT);
        }
    }
}
