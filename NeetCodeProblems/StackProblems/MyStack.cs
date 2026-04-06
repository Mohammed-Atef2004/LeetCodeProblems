namespace NeetCodeProblems.StackProblems
{
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
}
