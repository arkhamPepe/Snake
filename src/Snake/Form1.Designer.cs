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
            this.lblSnake = new System.Windows.Forms.Label();
            this.btnPlay = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSnake
            // 
            this.lblSnake.AutoSize = true;
            this.lblSnake.Font = new System.Drawing.Font("Showcard Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSnake.ForeColor = System.Drawing.Color.DarkRed;
            this.lblSnake.Location = new System.Drawing.Point(94, 29);
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
            this.btnPlay.Location = new System.Drawing.Point(57, 62);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(160, 40);
            this.btnPlay.TabIndex = 1;
            this.btnPlay.Text = "PLAY";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LawnGreen;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.lblSnake);
            this.Name = "Form1";
            this.Text = "Snake";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSnake;
        private System.Windows.Forms.Button btnPlay;
    }
}

