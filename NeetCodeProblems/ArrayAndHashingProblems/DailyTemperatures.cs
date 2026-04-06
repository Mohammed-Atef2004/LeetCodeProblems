using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeProblems
{
    public partial class ArrayAndHashingProblems
    {
        public int[] DailyTemperatures(int[] temperatures)
        {
            int n = temperatures.Length;
            int[] result = new int[n];
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                while (stack.Count > 0 && temperatures[i] > temperatures[stack.Peek()])
                {
                    int prev = stack.Pop();
                    result[prev] = i - prev;
                }
                stack.Push(i);
            }

            return result;
        }
    }
}
