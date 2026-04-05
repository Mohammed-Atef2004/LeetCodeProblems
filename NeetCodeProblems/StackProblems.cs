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
        /// <summary>
        /// Note: Evaluates the value of an arithmetic expression in Reverse Polish Notation (RPN).
        /// Uses a Stack to store operands and applies operators as they are encountered, ensuring correct order of operations.
        /// </summary>
        /// <param name="tokens"></param>
        /// <returns></returns>
        public int EvalRPN(string[] tokens)
        {
            //edge case: if tokens has only one element, return that element as an integer
            if (tokens.Length == 1)
            {
                return int.Parse(tokens[0]);
            }
            int result = 0;
            Stack<int> stack = new Stack<int>();
            foreach (string token in tokens)
            {
                if (int.TryParse(token, out int num))
                {
                    stack.Push(num);
                }
                else
                {
                    int b = stack.Pop();
                    int a = stack.Pop();
                    switch (token)
                    {
                        case "+":
                            result = a + b;
                            break;
                        case "-":
                            result = a - b;
                            break;
                        case "*":
                            result = a * b;
                            break;
                        case "/":
                            result = a / b; // Note: Integer division truncates towards zero
                            break;
                    }
                    stack.Push(result);
                }
            }
            return result;
        }
        /// <summary>
        /// Note: Determines the number of days until a warmer temperature for each day in the input array.
        /// Uses a Stack to keep track of indices of temperatures, allowing for efficient calculation of days until a warmer temperature is found.
        /// </summary>
        /// <param name="temperatures"></param>
        /// <returns></returns>
        public int[] DailyTemperatures(int[] temperatures)
        {
            int[] result = new int[temperatures.Length];
            Stack<int> stack = new Stack<int>(); // Stack to hold indices of temperatures
            for (int i = 0; i < temperatures.Length; i++)
            {
                while (stack.Count > 0 && temperatures[i] > temperatures[stack.Peek()])
                {
                    int index = stack.Pop();
                    result[index] = i - index; // Calculate days until a warmer temperature
                }
                stack.Push(i); // Push current index onto the stack
            }
            return result;
        }

        /// <summary>
        /// Note: Simplifies a given Unix-style file path by resolving "." and ".." components.
        /// Uses a Stack to manage directory names, allowing for efficient handling of path components and construction of the simplified path.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string SimplifyPath(string path)
        {
            Stack<string> stack = new Stack<string>();
            string[] parts = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
            foreach (string part in parts)
            {
                if (part == ".")
                {
                    continue; // Current directory, skip
                }
                else if (part == "..")
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop(); // Move up to parent directory
                    }
                }
                else if (part == "/" || part == "//")
                {
                    continue; // Skip empty parts resulting from multiple slashes
                }
                else
                {
                    stack.Push(part); // Valid directory name, push onto stack
                }
            }
            path = "";
            for (int i = stack.Count - 1; i >= 0; i--)
            {
                string dir = stack.ElementAt(i);
                path += "/" + dir; // Build the simplified path
            }
            return path == "" ? "/" : path; // Return root if path is empty
        }
    }
    /// <summary>
    /// Note: Implementation for the stack using two queues 
    /// </summary>
    public class MyStack
    {
        Queue<int> Main;
        Queue<int> Temp;
        public MyStack()
        {
            Main = new Queue<int>();
            Temp = new Queue<int>();
        }

        public void Push(int x)
        {
            if (Main.Count == 0) Main.Enqueue(x);
            else
            {
                Temp.Enqueue(x);
                while (Main.Count > 0)
                {
                    Temp.Enqueue(Main.Dequeue());
                }
                Main.Clear();
                while (Temp.Count > 0)
                {
                    Main.Enqueue(Temp.Dequeue());
                }
            }
        }

        public int Pop()
        {
            return Main.Dequeue();
        }

        public int Top()
        {
            int x = Main.Dequeue();
            Push(x);
            return x;
        }

        public bool Empty()
        {
            return Main.Count == 0;
        }
    }
    public class MyQueue
    {
        Stack<int> Main;
        Stack<int> Temp;

        public MyQueue()
        {
            Main = new Stack<int>();
            Temp = new Stack<int>();
        }

        public void Push(int x)
        {
            while (Main.Count > 0)
            {
                Temp.Push(Main.Pop());
            }

            Main.Push(x);

            while (Temp.Count > 0)
            {
                Main.Push(Temp.Pop());
            }
        }

        public int Pop()
        {
            return Main.Pop();
        }

        public int Peek()
        {
            return Main.Peek();
        }

        public bool Empty()
        {
            return Main.Count == 0;
        }
    }
}
