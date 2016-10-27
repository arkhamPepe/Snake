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
        public Pixel p = new Pixel(10, w); // Ett objekt som lagrar alla egenskaper av spelets pixlar
        Snake s = new Snake(w / 2); // Ormen
        SolidBrush b = new SolidBrush(Color.Red);
        public Form1()
        {
            InitializeComponent();

            while (s.Alive(s.posx, s.posy, p.amount)) // While snake is inside playground
            {
                // Move one step in the current direction
                switch (s.direction)
                {
                    case 1:
                        s.posx++;
                        break;

                    case 2:
                        s.posy++;
                        break;

                    case 3:
                        s.posx--;
                        break;

                    case 4:
                        s.posy--;
                        break;
                }
                // If on top of apple, grow in size
                if (p.grid[s.posx, s.posy] == p.apple)
                {
                    s.length++; // Grow +1
                    p.grid[s.posx, s.posy] = s.id; // Change color of gameboard

                }
            }
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
                s.direction = 0;
                return true;
            }
            else if (keyData == Keys.Right)
            {
                s.direction = 1;
                return true;
            }
            else if (keyData == Keys.Up)
            {
                s.direction = 2;
                return true;
            }
            else if (keyData == Keys.Down)
            {
                s.direction = 3;
                return true;
            }
                return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
