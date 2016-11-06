using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public class Snake
    {
        public int start_length, length = 3;
        public int direction = 4; // 1 = right, 2 = up, 3 = left, 4 = down
        public int x, y;

        public Snake(int c) // 'c' for "center"
        {
            x = c;
            y = c;
        }

        public bool Alive(int x, int y, int a) //Determines if snake is alive, ie. inside the playground
        {
            if (x >= a || x < 0)
                return false;
            else if (y >= a || y < 0)
                return false;
            //else if (grid > 0 && grid < length)
            //    return false;
            //int grid

            return true;
        }
    }
}
