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
        public bool eaten = false;
        public int width; // Width of a box
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

        public void Refresh(int q)
        {
            for (int i = 0; i < amount; i++)
                for (int j = 0; j < amount; j++)
                {
                    // This element is not grass.
                    if (grid[j, i] != 0)
                        grid[j, i] -= q;

                    // This element is an apple.
                    if (grid[j, i] == apple)

                }
        }

        public void GenerateApple()
        {
            //Random r = new Random();
            //bool available = false;
            //int xx;
            //int yy;

            //while (!available)
            //{
            //    if (grid[xx, yy] != 0)
            //    {
            //        int xx = r.Next(2, width - 2); // An off-shoot from the gameboard border by 2
            //                                       // for an easier playing experience.
            //        int yy = r.Next(2, width - 2);
            //    }
            //    else grid[xx, yy] = apple;

            //}
            
        }
    }
}
