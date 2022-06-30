namespace Adventure_Time
{
    partial class PlayingForm
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
            this.components = new System.ComponentModel.Container();
            this.timerJump = new System.Windows.Forms.Timer(this.components);
            this.timerAddObstacle = new System.Windows.Forms.Timer(this.components);
            this.timerMove = new System.Windows.Forms.Timer(this.components);
            this.timerJump1 = new System.Windows.Forms.Timer(this.components);
            this.lblScore = new System.Windows.Forms.Label();
            this.timerScore = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timerJump
            // 
            this.timerJump.Interval = 20;
            this.timerJump.Tick += new System.EventHandler(this.timerJump_Tick);
            // 
            // timerAddObstacle
            // 
            this.timerAddObstacle.Interval = 2000;
            this.timerAddObstacle.Tick += new System.EventHandler(this.timerObstacle_Tick);
            // 
            // timerMove
            // 
            this.timerMove.Interval = 30;
            this.timerMove.Tick += new System.EventHandler(this.timerMove_Tick);
            // 
            // timerJump1
            // 
            this.timerJump1.Interval = 20;
            this.timerJump1.Tick += new System.EventHandler(this.timerJump1_Tick_1);
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.BackColor = System.Drawing.Color.Transparent;
            this.lblScore.Font = new System.Drawing.Font("Comic Sans MS", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblScore.Location = new System.Drawing.Point(30, 28);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(118, 39);
            this.lblScore.TabIndex = 0;
            this.lblScore.Text = "SCORE:";
            // 
            // timerScore
            // 
            this.timerScore.Interval = 500;
            this.timerScore.Tick += new System.EventHandler(this.timerScore_Tick);
            // 
            // PlayingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Adventure_Time.Properties.Resources.background21;
            this.ClientSize = new System.Drawing.Size(991, 560);
            this.Controls.Add(this.lblScore);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PlayingForm";
            this.Text = "PlayingForm";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PlayingForm_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PlayingForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PlayingForm_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerJump;
        private System.Windows.Forms.Timer timerAddObstacle;
        private System.Windows.Forms.Timer timerMove;
        private System.Windows.Forms.Timer timerJump1;
        private Label lblScore;
        private System.Windows.Forms.Timer timerScore;
    }
}