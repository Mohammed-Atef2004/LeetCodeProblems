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
}
