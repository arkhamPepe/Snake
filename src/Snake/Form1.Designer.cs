namespace Snake
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblSnake = new System.Windows.Forms.Label();
            this.btnPlay = new System.Windows.Forms.Button();
            this.gameboard = new System.Windows.Forms.Panel();
            this.container = new System.Windows.Forms.GroupBox();
            this.tbBoxes = new System.Windows.Forms.TextBox();
            this.points = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbContainer = new System.Windows.Forms.GroupBox();
            this.gameboard.SuspendLayout();
            this.container.SuspendLayout();
            this.tbContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSnake
            // 
            this.lblSnake.AutoSize = true;
            this.lblSnake.Font = new System.Drawing.Font("Showcard Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSnake.ForeColor = System.Drawing.Color.DarkRed;
            this.lblSnake.Location = new System.Drawing.Point(50, 15);
            this.lblSnake.Name = "lblSnake";
            this.lblSnake.Size = new System.Drawing.Size(86, 30);
            this.lblSnake.TabIndex = 0;
            this.lblSnake.Text = "Snake";
            // 
            // btnPlay
            // 
            this.btnPlay.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnPlay.FlatAppearance.BorderSize = 3;
            this.btnPlay.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlay.Location = new System.Drawing.Point(5, 48);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(160, 40);
            this.btnPlay.TabIndex = 1;
            this.btnPlay.Text = "PLAY";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // gameboard
            // 
            this.gameboard.Controls.Add(this.container);
            this.gameboard.Controls.Add(this.points);
            this.gameboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameboard.Location = new System.Drawing.Point(0, 0);
            this.gameboard.Name = "gameboard";
            this.gameboard.Size = new System.Drawing.Size(284, 261);
            this.gameboard.TabIndex = 2;
            this.gameboard.Paint += new System.Windows.Forms.PaintEventHandler(this.gameboard_Paint);
            // 
            // container
            // 
            this.container.Controls.Add(this.tbContainer);
            this.container.Controls.Add(this.lblSnake);
            this.container.Controls.Add(this.btnPlay);
            this.container.Location = new System.Drawing.Point(54, 51);
            this.container.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.container.Name = "container";
            this.container.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.container.Size = new System.Drawing.Size(180, 141);
            this.container.TabIndex = 4;
            this.container.TabStop = false;
            // 
            // tbBoxes
            // 
            this.tbBoxes.Location = new System.Drawing.Point(50, 11);
            this.tbBoxes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbBoxes.Name = "tbBoxes";
            this.tbBoxes.Size = new System.Drawing.Size(101, 20);
            this.tbBoxes.TabIndex = 3;
            this.tbBoxes.TextChanged += new System.EventHandler(this.tbBoxes_TextChanged);
            // 
            // points
            // 
            this.points.AutoSize = true;
            this.points.Font = new System.Drawing.Font("Ravie", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.points.Location = new System.Drawing.Point(3, 9);
            this.points.Name = "points";
            this.points.Size = new System.Drawing.Size(76, 22);
            this.points.TabIndex = 2;
            this.points.Text = "label1";
            this.points.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(6, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Width:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tbContainer
            // 
            this.tbContainer.BackColor = System.Drawing.Color.Gainsboro;
            this.tbContainer.Controls.Add(this.label1);
            this.tbContainer.Controls.Add(this.tbBoxes);
            this.tbContainer.Location = new System.Drawing.Point(5, 94);
            this.tbContainer.Name = "tbContainer";
            this.tbContainer.Size = new System.Drawing.Size(160, 36);
            this.tbContainer.TabIndex = 5;
            this.tbContainer.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LawnGreen;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.gameboard);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Snake";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gameboard.ResumeLayout(false);
            this.gameboard.PerformLayout();
            this.container.ResumeLayout(false);
            this.container.PerformLayout();
            this.tbContainer.ResumeLayout(false);
            this.tbContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSnake;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Panel gameboard;
        private System.Windows.Forms.Label points;
        private System.Windows.Forms.TextBox tbBoxes;
        private System.Windows.Forms.GroupBox container;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox tbContainer;
    }
}

