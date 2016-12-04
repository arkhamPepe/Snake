using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Snake
{
    /// <summary>
    /// Holds properties of gameboard and refreshes the state of the gameboard
    /// </summary>
    public class Pixel
    {
        public int apple = -1;
        public int box_width; // Width of a box
        public int amount; // Amount of boxes per row.
        public int[,] grid;
        public int grid_length;
        int screen_height = Screen.PrimaryScreen.WorkingArea.Height; // Assuming the height is less than width of computer display.

        
        public Pixel(int w, int a)
        {
            box_width = w;
            amount = a;
            grid_length = GetGridWidth();
            grid = new int[grid_length, grid_length];

            ZeroGameboard();
        }

        private int GetGridWidth()
        {
            int width = screen_height / box_width;

            return width;
        }

        /// <summary>
        /// Sets value of all elements in array grid to 0.
        /// </summary>
        public void ZeroGameboard()
        {
            for (int i = 0; i < amount; i++)
                for (int j = 0; j < amount; j++)
                    grid[j, i] = 0;
        }

        /// <summary>
        /// Assigns default values to amount and box_width and sets gameboard grid.
        /// </summary>
        public Pixel()
        {
            amount = 10;
            box_width = 32;
            grid = new int[amount, amount];

            ZeroGameboard();
        }

        /// <summary>
        /// Updates the elements in grid[] representing the snake.
        /// </summary>
        /// <param name="q">The decay of the snake's tail.</param>
        public void Refresh(int q)
        {
            for (int i = 0; i < amount; i++)
                for (int j = 0; j < amount; j++)
                {
                    // If this element is a snake, then...
                    if (grid[j,i] > 0)
                        grid[j, i] -= q;

                }
        }

        /// <summary>
        /// Creates a snake based on properties of snake, vertically.
        /// </summary>
        /// <param name="length">Length of this snake.</param>
        /// <param name="x">Place in x-axis for head of snake.</param>
        /// <param name="y">Place in y-axis for head of snake.</param>
        public void CreateSnake(int length, int x, int y)
        {
            for (int i = 0; i < length; i++)
                grid[x, y - i] = length - i; // Check paint illustration for code explanation
        }

        /// <summary>
        /// Generates an apple element at a random place where a snake is not.
        /// </summary>
        public void GenerateApple()
        {
            /*
            1. Iterate over the array and save all available coordinates for apple in list.
            2. Pick a random pair of coordinates for apple.
            3. Put apple at those coordinates.
            */

            int space = 2; // An off-shoot from the gameboard border by 2 for an easier playing experience.
            Random r = new Random();
            List<int> xCoords = new List<int>(); // All available x-coordinates in grid for apple.
            List<int> yCoords = new List<int>(); // ... y-coordinates...

            // Iterate over the array.
            for (int i = space; i < amount - space; i++)
            {
                for (int j = space; j < amount - space; j++)
                {
                    if (grid[j, i] == 0)
                    {
                        xCoords.Add(j);
                        yCoords.Add(i);
                    }
                }
            }

            // Pick random pair of coordinates.
            int rand = r.Next(space, xCoords.Count - space); // == yCoords.Count
            int xRand = xCoords[rand];
            int yRand = yCoords[rand];

            // Put apple at random coordinates.
            grid[xRand, yRand] = apple;
        }
    }
}
