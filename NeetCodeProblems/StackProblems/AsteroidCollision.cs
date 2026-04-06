namespace NeetCodeProblems.StackProblems
{
    public partial class StackProblems
    {

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
    }
}