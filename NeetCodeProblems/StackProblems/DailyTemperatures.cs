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
    }

}
