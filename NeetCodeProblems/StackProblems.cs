using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeProblems
{
    /// <summary>
    /// Note: A custom stack implementation that supports getting the minimum element.
    /// The current GetMin() method relies on LINQ (.Min()), resulting in an O(N) operation instead of O(1).
    /// </summary>
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
            // Note: For optimal MinStack design, an auxiliary stack or paired tuple holding minimums should be utilized.
            return stack.Min();
        }
    }

    public class StackProblems
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

        /// <summary>
        /// Note: Simulates asteroid collisions based on sizes and directions.
        /// Uses a Stack to keep track of right-moving asteroids and resolve collisions when a left-moving one appears.
        /// </summary>
        public int[] AsteroidCollision(int[] asteroids)
        {
            Stack<int> stack = new Stack<int>();
            foreach (int asteroid in asteroids)
            {
                // Resolve collisions while top of stack is positive (moving right) and current is negative (moving left)
                while (stack.Count > 0 && asteroid < 0 && stack.Peek() > 0)
                {
                    int top = stack.Peek();
                    if (top < -asteroid)
                    {
                        stack.Pop(); // Top asteroid explodes
                    }
                    else if (top == -asteroid)
                    {
                        stack.Pop(); // Both explode
                        break;
                    }
                    else
                    {
                        break; // Current incoming asteroid explodes
                    }
                }

                // Add the asteroid to stack if it wasn't destroyed
                if (stack.Count == 0 || asteroid > 0 || stack.Peek() < 0)
                {
                    stack.Push(asteroid);
                }
            }
            return stack.Reverse().ToArray();
        }

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
