using System;

namespace Snake
{
    public class Snake
    {
        public int start_length = 5; // Static makes value the same for ALL snakes
        public int length = 5;
        public int direction = 4; // 1 = right, 2 = up, 3 = left, 4 = down
        public int x, y;

        public Snake(int pos) 
        {
            x = pos;
            y = pos;
        }

        // public bool Alive(int xy, int a) //Determines if snake is alive, ie. inside the playground
        public bool Alive(int[,] grid, int a)
        {
            if (x >= a || x < 0)
                return false;
            if (y >= a || y < 0)
                return false;
            if (grid[x, y] > 0 && grid[x, y] < length - 1)
                return false;

            return true;
        }
    }
}
