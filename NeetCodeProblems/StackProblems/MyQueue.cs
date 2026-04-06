namespace NeetCodeProblems.StackProblems
{
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
