using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeProblems.StackProblems
{

    public  partial class StackProblems 
    {

        /// <summary>
        /// Note: Calculates the total points from a series of operations in a baseball game.
        /// Uses a Stack to keep track of valid points, allowing for efficient handling of operations such as adding points, doubling the last points, and removing the last points.
        /// </summary>
        /// <param name="operations"></param>
        /// <returns></returns>
        public int CalPoints(string[] operations)
        {
            int record = 0;
            Stack<int> stack = new Stack<int>();
            foreach (string operation in operations)
            {
                if(int.TryParse(operation,out int point))
                {
                    stack.Push(point);
                }
                if(operation == "C")
                {
                    stack.Pop();
                }
                if(operation == "D")
                {
                    stack.Push(stack.Peek() * 2);
                }
                if(operation == "+")
                {
                    int top = stack.Pop();
                    int newTop = top + stack.Peek();
                    stack.Push(top); // Push the original top back
                    stack.Push(newTop); // Push the new top (sum of last two)
                }
            }
            while(stack.Count>0)
            {
                record+= stack.Pop();   
            }

            return record;
        }
    }
}
