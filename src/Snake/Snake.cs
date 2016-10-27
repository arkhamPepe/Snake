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
        public int length;
        public int direction = 3;
        public int posx;
        public int posy;
        public int id = 1; // ID signifies the color the element gets in-game

        public Snake(int c)
        {
            posx = c;
            posy = c;
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

    }
}
