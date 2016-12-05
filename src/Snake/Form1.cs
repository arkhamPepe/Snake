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
        static int wait, wait_default = 20;
        static int amount_cells_origin = 20; // amount of cells in gameboard if tbBoxes == null.
        static int box_width_default = 10; // width of each box
        static int x_offshoot = 0; // Off-shoot from left border
        static int y_offshoot = 0; // Off shoot from top border
        public bool arrow_pressed = false;
        public Pixel p = new Pixel(box_width_default, amount_cells_origin); // Object that stores all properties of gameboard elements, like pixels
        Snake s = new Snake(box_width_default / 2); // The snake
        public int n = 4; // Decides how many apples that needs to get eaten before the speed changes.
        private int wait_numerator = 5; // numerator and denominator adjusts the change of speed every n'th apple.
        private int wait_denominator = 6;
        public int margin = 10;

        public Form1()
        {
            InitializeComponent();
        }
        
        Thread th;

        // Thread for separate process unit while main unit handles button events. This way the player can control the snakes movement while graphics are rendering.
        public void Thread_()
        {                                                         // p.grid[s.x, s.y]
            while (s.Alive(p.amount)) // While snake is inside playground
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

                // Snake is dead.
                if (!s.Alive(p.amount))
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
                    
                    s.length++;
                    p.grid[s.x, s.y] = s.length;
                    p.GenerateApple();
                    p.Refresh(0);
                    UpdateScore();
                    points.Text = Convert.ToString(score);
                    //points.Text = Convert.ToString(s.length * 10 - s.start_length * 10);
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

            ResetGame();
            Show_Menu(true);
        }

        /// <summary>
        /// Resets certain necessary variables to start value. This enables a restart of the game.
        /// </summary>
        public void ResetGame()
        {
            // Position snake in center of gameboard.
            s.x = p.amount / 2;
            s.y = p.amount / 2; 

            score = 0; // Zero the score.
            points.Text = Convert.ToString(score);

            wait = wait_default; // Set wait interval between each move.

            // Turn all boxes into grass.
            p.ZeroGameboard();

            // Adjust size of window according to number of boxes and their width.
            SetWindowSize((p.amount+1) * p.box_width);

            PaintBoard();
        }

        private void SetWindowSize(int size)
        {
            this.Width = size;
            this.Height = size + p.box_width;
        }

        /// <summary>
        /// Updates the score.
        /// </summary>
        private void UpdateScore()
        {
            score += 10;

            string score_text = Convert.ToString(score);

            if ((score / 10) % n == 0)
                wait = (wait * wait_numerator) / wait_denominator;

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
            // Creates the wanted grid for the game
            SetWindowSize(p.amount * p.box_width);

            // Sets the width of all elements
            SetElementsSize(180);

            // Positions all elements appropriately in the middle of the program window
            CenterMenu();
            RepositionControls();
        }

        public void SetElementsSize(int cont)
        {
            // Width
            container.Width = cont;
            btnPlay.Width = container.Width - 2 * margin;
            tbContainer.Width = btnPlay.Width;

            // Elements inside tbContainer
            tbBoxes.Width = tbContainer.Width - (label1.Width + margin * 3);

            // Height
            btnPlay.Height = btnPlay.Width / 4;
            tbContainer.Height = btnPlay.Height;
            container.Height = lblSnake.Height + btnPlay.Height + tbContainer.Height + 4 * margin;
        }

        /// <summary>
        /// Positions elements within container appropriately.
        /// </summary>
        public void RepositionControls()
        { 
            int position_y = margin;

            Point button = new Point(); // Coordinate of btnPlay
            Point logo = new Point(); // -"- lblSnake
            Point _container = new Point(); // -"- tbContainer
            Point width_label = new Point(); // -"- label1
            Point text = new Point(); // -"- tbBoxes

            logo.X = (container.Width - lblSnake.Width) / 2; ;
            logo.Y = position_y;
            position_y += lblSnake.Height + margin;

            button.X = (container.Width - btnPlay.Width) / 2; ;
            button.Y = position_y;
            position_y += btnPlay.Height + margin;

            _container.X = margin;
            _container.Y = position_y;

            width_label.X = margin;
            width_label.Y = (tbContainer.Height - label1.Height) / 2;

            text.X = label1.Width + margin;
            text.Y = (tbContainer.Height - tbBoxes.Height) / 2;

            // Position elements in container.
            btnPlay.Location = button;
            lblSnake.Location = logo;
            tbContainer.Location = _container;
            label1.Location = width_label;
            tbBoxes.Location = text;
        }

        /// <summary>
        /// Positions the menu in the center of the form.
        /// </summary>
        public void CenterMenu()
        {
            decimal form_width = Convert.ToDecimal(this.Width);
            decimal form_height = Convert.ToDecimal(this.Height);

            int middle_x = (int)Math.Floor(form_width / 2); // Convert decimal to int with cast operator.
            int middle_y = (int)Math.Floor(form_height / 2);

            Point point = new Point();
            int _x = middle_x - container.Width / 2;
            int _y = middle_y - container.Width / 2;
            point.X = _x;
            point.Y = _y;

            container.Location = point;
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
            wait = wait_default;
            s.length = 3;

            if (tbBoxes.Text != "" && Convert.ToInt32(tbBoxes.Text) >= 10 && Convert.ToInt32(tbBoxes.Text) <= p.grid_length)
            {
                p.amount = Convert.ToInt32(tbBoxes.Text);
            }
            
            ResetGame();

            p.GenerateApple();
            p.CreateSnake(s.length, s.x, s.y);
            PaintBoard();

            th = new Thread(Thread_); // Distinguish parameter from class Thread.
            th.Start();

            // Position menu in middle. The size could have changed from earlier.
            CenterMenu();
        }

        /// <summary>
        /// Either shows the menu and hides the rest or shows the rest and hides the menu.
        /// </summary>
        /// <param name="visible"></param>
        private void Show_Menu(bool visible)
        {
            // Menu
            lblSnake.Visible = visible;
            btnPlay.Visible = visible;
            tbBoxes.Visible = visible;
            container.Visible = visible;

            // Points label in upper left corner
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

            
            Rectangle rect = new Rectangle(x_offshoot + j * p.box_width, y_offshoot + i * p.box_width, p.box_width, p.box_width);
            g.FillRectangle(b, rect);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tbBoxes_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
