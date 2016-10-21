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
        Pixel p = new Pixel(10, 32); // Ett objekt som lagrar alla egenskaper av spelets pixlar
        Snake s = new Snake();
        Brush b = new Brush();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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
    /// <summary>
    /// Holds properties of gameboard size
    /// </summary>
    public class Pixel
    {
        public int width;
        public static int amount;
        public int[,] grid = new int[amount, amount];

        public Pixel(int w, int a)
        {
            width = w;
            amount = a;
        }
    }

    public class Snake
    {
        public int length;
        public int direction;
        public int posx;
        public int posy;


    }
}
