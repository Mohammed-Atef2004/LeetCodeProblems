namespace NeetCodeProblems.StackProblems
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
}
