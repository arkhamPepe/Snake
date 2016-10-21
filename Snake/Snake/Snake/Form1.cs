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
                MessageBox.Show("You pressed Left arrow key");
                return true;
            }
            else if (keyData == Keys.Right)
            {
                MessageBox.Show("You pressed Right arrow key");
                return true;
            }
            else if (keyData == Keys.Up)
            {
                MessageBox.Show("You pressed Up arrow key");
                return true;
            }
            else if (keyData == Keys.Down)
            {
                MessageBox.Show("You pressed Down arrow key");
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
        public int amount;

        public Pixel(int w, int a)
        {
            width = w;
            amount = a;
        }
    }
}
