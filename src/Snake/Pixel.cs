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
    /// <summary>
    /// Holds properties of gameboard size
    /// </summary>
    public class Pixel
    {
        public int apple = -1;
        public int width;
        public int amount;
        public int[,] grid;
        public Pixel(int w, int a)
        {
            width = w;
            amount = a;
            grid = new int[a, a];

            for (int i = 0; i < amount; i++)
                for (int j = 0; j < amount; j++)
                    grid[j, i] = 0;
        }

        public void Paint(int[,] grid)
        {

        }

        public void Refresh()
        {
            for (int i = 0; i < amount; i++)
                for (int j = 0; j < amount; j++)
                    if (grid[j,i] != 0)
                        grid[j, i] -= 1;
        }
    }
}
