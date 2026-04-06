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
    }
}
