using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form
    {
        SolidBrush b = new SolidBrush(Color.Blue);
        //SolidBrush green = new SolidBrush(Color.Green);
        //SolidBrush red = new SolidBrush(Color.Green);

        Graphics g = null;

        static int score = 0;
        static int wait = 200;
        static int a = 32; // amount of boxes in gameboard
        static int w = 20; // width of each box
        static int x_offshoot = 0; // Off-shoot from left border
        static int y_offshoot = 0; // Off shoot from top border

        public Pixel p = new Pixel(w, a); // Object that stores all properties of gameboard elements, like pixels
        Snake s = new Snake(w / 2); // Ormen
        
        public Form1()
        {
            InitializeComponent();

            
            /**
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
            */
        }
        
        Thread th;

        public void thread()
        {
            while (s.Alive(s.x, s.y, p.amount, p.grid[s.x, s.y])) // While snake is inside playground
            {
                // Move one step in the current direction
                switch (s.direction)
                {
                    case 1: // Right
                        s.x++;
                        break;

                    case 2: // Up
                        s.y--; // Minus as coordinate system reverse the y-axis
                        break;

                    case 3: // Left
                        s.x--;
                        break;

                    case 4: // Down
                        s.y++;
                        break;
                }

                // Snake is dead.
                if (!s.Alive(s.x, s.y, p.amount, p.grid[s.x, s.y]))
                    break;

                // Wait some...
                Thread.Sleep(wait);

                // If on top of apple, grow in size (actually just stop the decrements of Snake body elements)
                if (p.grid[s.x, s.y] == p.apple)
                {
                    /*
                    1. Increase size.
                    2. Turn box into snake. (Actually make it not be grass)
                    3. Generate apple somewhere snake is not.
                    4. Refresh but don't change snake.
                    5. Paint the refreshed gameboard state.
                    6. Increase score and maybe speed
                    */
                    
                    //this.points.Text = Convert.ToString(s.length * 10 - s.start_length * 10);
                    s.length++;
                    p.grid[s.x, s.y] = s.length;
                    p.GenerateApple();
                    p.Refresh(0);
                    UpdateScore();
                }
                else
                {
                    /*
                    1. Turn box into snake.
                    2. Update snake.
                    */
                    p.grid[s.x, s.y] = s.length;
                    p.Refresh(1);
                }


                PaintBoard();
            }

            MessageBox.Show("Game Over!");
        }

        private void UpdateScore()
        {
            score += 10;

            if ((score / 10) % 5 == 0)
                wait = (wait * 4) / 5;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Skapar det önskvärda rutnätet för spelet
            this.Width = p.amount * p.width;
            this.Height = p.amount * p.width;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Left && s.direction != 1)
            {
                s.direction = 3;
                return true;
            }
            else if (keyData == Keys.Right && s.direction != 3)
            {
                s.direction = 1;
                return true;
            }
            else if (keyData == Keys.Up && s.direction != 4)
            {
                s.direction = 2;
                return true;
            }
            else if (keyData == Keys.Down && s.direction != 2)
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

            p.GenerateApple();
            p.CreateSnake(s.length, s.x, s.y);
            PaintBoard();

            th = new Thread(thread);
            th.Start();
        }

        // Happened to create this function and now it is mandatory in order for "Snake.game" to work
        private void gameboard_Paint(object sender, PaintEventArgs e)
        {
        //    g = gameboard.CreateGraphics();

        //    for (int i = 0; i < p.amount; i++)
        //        for (int j = 0; j < p.amount; j++)
        //        {
        //            drawRectangle(j, i);
        //        }
        }

        public void PaintBoard()
        {
            g = gameboard.CreateGraphics();

            for (int i = 0; i < p.amount; i++)
                for (int j = 0; j < p.amount; j++)
                {
                    drawRectangle(j, i);
                }
        }

        private void drawRectangle(int j, int i)
        {
            //Point[] points =
            //{
            //    new Point(start_x, start_y),
            //    new Point(start_x + w * a, start_y + w * a)
            //};
            //Size sz = new Size(points[1]); 

            if (p.grid[j, i] > 0)
                b.Color = Color.Blue;
            else if (p.grid[j, i] == 0)
                b.Color = Color.LawnGreen;
            else if (p.grid[j, i] == -1)
                b.Color = Color.Red;

            
            Rectangle rect = new Rectangle(x_offshoot + j * w, y_offshoot + i * w, w, w);
            g.FillRectangle(b, rect);
        }
    }
}
