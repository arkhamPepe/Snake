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
        static int amount_cells = 32; // amount of cells in gameboard
        static int width = 20; // width of each box
        static int x_offshoot = 0; // Off-shoot from left border
        static int y_offshoot = 0; // Off shoot from top border
        public bool arrow_pressed = false;
        public Pixel p = new Pixel(width, amount_cells); // Object that stores all properties of gameboard elements, like pixels
        Snake s = new Snake(width / 2); // Ormen
        
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

        // Thread for separate process "unit" while main unit handles key events. This way the player can control the snakes movement while graphics are rendering.
        public void thread()
        {                                                         // p.grid[s.x, s.y]
            while (s.Alive(s.x, s.y, p.amount)) // While snake is inside playground
            {
                // Makes it possible to perform only one move per turn
                arrow_pressed = false;

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

                // Snake is dead.   p.grid[s.x, s.y]
                if (!s.Alive(s.x, s.y, p.amount))
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

            MessageBox.Show("Game Over!\nYour score is: " + score);

            Revert_Settings();
            Show_Menu(true);
        }

        /// <summary>
        /// Resets certain necessary variables to start value. This enables a restart of the game.
        /// </summary>
        public void Revert_Settings()
        {
            s.Position_Center();
            score = 0;
            wait = 200;

            for (int i = 0; i < width; i++)
                for (int j = 0; j < width; j++)
                    p.grid[j, i] = 0;

            PaintBoard();
        }

        /// <summary>
        /// Updates the score.
        /// </summary>
        private void UpdateScore()
        {
            score += 10;

            string score_text = Convert.ToString(score);

            if ((score / 10) % 5 == 0)
                wait = (wait * 4) / 5;

            // Updates and sets score.
            SetLabelText(points, score_text);
        }

        /// <summary>
        /// Sets the text of a label form to input value. 
        /// Performs a cross-thread safe call if necessary.
        /// </summary>
        /// <param name="label">Holds the label object</param>
        /// <param name="text">New string value of label.Text</param>
        private string SetLabelText(Label label, string text)
        {
            if (label.InvokeRequired)
            {
                return text;
            }
            else
            {
                return text;
            }
        }

        /// <summary>
        /// Runs at the beginning of the program.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            // Skapar det önskvärda rutnätet för spelet
            this.Width = p.amount * p.width;
            this.Height = p.amount * p.width;
        }

        /// <summary>
        /// Handles event when a key is pressed, specifically arrow keys. Controls the direction of snake.
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Left && s.direction != 1 && s.direction != 3 && arrow_pressed == false)
            {
                s.direction = 3;
                arrow_pressed = true;
                return true;
            }
            else if (keyData == Keys.Right && s.direction != 3 && s.direction != 1 && arrow_pressed == false)
            {
                s.direction = 1;
                arrow_pressed = true;
                return true;
            }
            else if (keyData == Keys.Up && s.direction != 4 && s.direction != 2 && arrow_pressed == false)
            {
                s.direction = 2;
                arrow_pressed = true;
                return true;
            }
            else if (keyData == Keys.Down && s.direction != 2 && s.direction != 4 && arrow_pressed == false)
            {
                s.direction = 4;
                arrow_pressed = true;
                return true;
            }
                return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// Starts the game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlay_Click(object sender, EventArgs e)
        {
            Show_Menu(false);

            score = 0;
            wait = 200;
            s.length = 3;
            amount_cells = Convert.ToInt32(tbBoxes.Text);

            p.GenerateApple();
            p.CreateSnake(s.length, s.x, s.y);
            PaintBoard();

            th = new Thread(thread);
            th.Start();
        }

        /// <summary>
        /// Either shows the menu and hides the rest or shows the rest and hides the menu.
        /// </summary>
        /// <param name="visible"></param>
        private void Show_Menu(bool visible)
        {
            lblSnake.Visible = visible;
            btnPlay.Visible = visible;
            tbBoxes.Visible = visible;

            points.Visible = !visible;
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

        /// <summary>
        /// Purpose to draw entire gameboard over the previous one.
        /// </summary>
        public void PaintBoard()
        {
            g = gameboard.CreateGraphics();

            for (int i = 0; i < p.amount; i++)
                for (int j = 0; j < p.amount; j++)
                {
                    drawRectangle(j, i);
                }
        }

        /// <summary>
        /// Draws a rectangle at given coordinate on gameboard.
        /// </summary>
        /// <param name="j">Represents the x-coordinate in gameboard</param>
        /// <param name="i">Represents the y-coordinate in gameboard</param>
        private void drawRectangle(int j, int i)
        {
            if (p.grid[j, i] > 0)
                b.Color = Color.Blue;
            else if (p.grid[j, i] == 0)
                b.Color = Color.LawnGreen;
            else if (p.grid[j, i] == -1)
                b.Color = Color.Red;

            
            Rectangle rect = new Rectangle(x_offshoot + j * width, y_offshoot + i * width, width, width);
            g.FillRectangle(b, rect);
        }
    }
}
