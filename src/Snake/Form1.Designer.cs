﻿namespace Snake
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
            this.lblSnake = new System.Windows.Forms.Label();
            this.btnPlay = new System.Windows.Forms.Button();
            this.gameboard = new System.Windows.Forms.Panel();
            this.points = new System.Windows.Forms.Label();
            this.tbBoxes = new System.Windows.Forms.TextBox();
            this.gameboard.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSnake
            // 
            this.lblSnake.AutoSize = true;
            this.lblSnake.Font = new System.Drawing.Font("Showcard Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSnake.ForeColor = System.Drawing.Color.DarkRed;
            this.lblSnake.Location = new System.Drawing.Point(135, 130);
            this.lblSnake.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSnake.Name = "lblSnake";
            this.lblSnake.Size = new System.Drawing.Size(110, 37);
            this.lblSnake.TabIndex = 0;
            this.lblSnake.Text = "Snake";
            // 
            // btnPlay
            // 
            this.btnPlay.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnPlay.FlatAppearance.BorderSize = 3;
            this.btnPlay.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlay.Location = new System.Drawing.Point(83, 183);
            this.btnPlay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(213, 49);
            this.btnPlay.TabIndex = 1;
            this.btnPlay.Text = "PLAY";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // gameboard
            // 
            this.gameboard.Controls.Add(this.tbBoxes);
            this.gameboard.Controls.Add(this.points);
            this.gameboard.Controls.Add(this.btnPlay);
            this.gameboard.Controls.Add(this.lblSnake);
            this.gameboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameboard.Location = new System.Drawing.Point(0, 0);
            this.gameboard.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gameboard.Name = "gameboard";
            this.gameboard.Size = new System.Drawing.Size(379, 321);
            this.gameboard.TabIndex = 2;
            this.gameboard.Paint += new System.Windows.Forms.PaintEventHandler(this.gameboard_Paint);
            // 
            // points
            // 
            this.points.AutoSize = true;
            this.points.Font = new System.Drawing.Font("Ravie", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.points.Location = new System.Drawing.Point(4, 11);
            this.points.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.points.Name = "points";
            this.points.Size = new System.Drawing.Size(91, 27);
            this.points.TabIndex = 2;
            this.points.Text = "label1";
            this.points.Visible = false;
            // 
            // tbBoxes
            // 
            this.tbBoxes.Location = new System.Drawing.Point(83, 239);
            this.tbBoxes.Name = "tbBoxes";
            this.tbBoxes.Size = new System.Drawing.Size(213, 22);
            this.tbBoxes.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LawnGreen;
            this.ClientSize = new System.Drawing.Size(379, 321);
            this.Controls.Add(this.gameboard);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Snake";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gameboard.ResumeLayout(false);
            this.gameboard.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSnake;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Panel gameboard;
        private System.Windows.Forms.Label points;
        private System.Windows.Forms.TextBox tbBoxes;
    }
}

