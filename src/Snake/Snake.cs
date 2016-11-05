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
        public int length = 3;
        public int direction = 4; // 1 = right, 2 = up, 3 = left, 4 = down
        public int x;
        public int y;

        public Snake(int c) // 'c' for "center"
        {
            x = c;
            y = c;
        }

        public bool Alive(int x, int y, int a) //Determines if snake is alive, ie. inside the playground
        {
            if (x == a || x < 0)
                return false;
            if (y == a || x < 0)
                return false;

            return true;
        }

        public SolidBrush red = new SolidBrush(Color.Red);


        private void Form1_Paint(object sender, PaintEventArgs pe)
        {
            Graphics g = pe.Graphics;
        }

        public void InitPaint()
    }
}
