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
    public partial class Form1 : Form
    {
        static int w = 32; // width
        public Pixel p = new Pixel(10, w); // Object that stores all properties of gameboard elements, like pixels
        Snake s = new Snake(w / 2); // Ormen
        SolidBrush b = new SolidBrush(Color.Red);
        public Form1()
        {
            InitializeComponent();

            ////Moved to btnPlay_Click() to fix problem where the form window won't open until all code in Form1() has run.

            //while (s.Alive(s.x, s.y, p.amount)) // While snake is inside playground
            //{
            //    // Move one step in the current direction
            //    switch (s.direction)
            //    {
            //        case 1:
            //            s.x++;
            //            break;

            //        case 2:
            //            s.y++;
            //            break;

            //        case 3:
            //            s.x--;
            //            break;

            //        case 4:
            //            s.y--;
            //            break;
            //    }

            //    if (s.Alive(s.x, s.y, p.amount))
            //        break;

            //    System.Threading.Thread.Sleep(500);
            //    // If on top of apple, grow in size (actually just stop the decrements of Snake body elements)
            //    if (p.grid[s.x, s.y] == p.apple)
            //    {
            //        s.length++; // Grow +1
            //        p.grid[s.x, s.y] = s.length; // Change color of gameboard
            //    }
            //    else
            //    {
            //        p.Refresh();
            //    }
            //}

            //MessageBox.Show("Game Over!");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Skapar det önskvärda rutnätet för spelet
            this.Width = p.amount * p.width;
            this.Height = p.amount * p.width;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Left)
            {
                s.direction = 1;
                return true;
            }
            else if (keyData == Keys.Right)
            {
                s.direction = 2;
                return true;
            }
            else if (keyData == Keys.Up)
            {
                s.direction = 3;
                return true;
            }
            else if (keyData == Keys.Down)
            {
                s.direction = 4;
                return true;
            }
                return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            lblSnake.Visible = false;
            btnPlay.Visible = false;

            while (s.Alive(s.x, s.y, p.amount)) // While snake is inside playground
            {
                // Move one step in the current direction
                switch (s.direction)
                {
                    case 1:
                        s.x++;
                        break;

                    case 2:
                        s.y++;
                        break;

                    case 3:
                        s.x--;
                        break;

                    case 4:
                        s.y--;
                        break;
                }

                if (!s.Alive(s.x, s.y, p.amount))
                    break;

                //System.Threading.Thread.Sleep(500);

                // If on top of apple, grow in size (actually just stop the decrements of Snake body elements)
                if (p.grid[s.x, s.y] == p.apple)
                {
                    p.eaten = true;
                    s.length++; // Grow +1
                    p.grid[s.x, s.y] = s.length; // Change color of gameboard
                }
                else
                {
                    p.Refresh();
                }
            }

            MessageBox.Show("Game Over!");
        }
    }
}
