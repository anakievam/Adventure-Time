using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adventure_Time
{
    public partial class PlayingForm : Form
    {
        public Scene Scene { get; set; }

        public int Count { get; set; } = 0;

        public int Count2 { get; set; } = 0;

        public bool UpDone1 { get; set; } = false;

        public bool UpDone2 { get; set; } = false;

        public bool GameOver { get; set; } = false; 

        public PlayingForm()
        {
            InitializeComponent();
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            Scene =new Scene(this.Width,this.Height);
            timerAddObstacle.Start();
            timerMove.Start();
            timerScore.Start();
        }

        private void PlayingForm_Paint(object sender, PaintEventArgs e)
        {
            Brush brush = new SolidBrush(Color.SaddleBrown);
            e.Graphics.FillRectangle(brush, 0, Height - 100, Width, Height);
            brush.Dispose();
            Scene.DrawCharacters(e.Graphics);
            Scene.DrawObstacles(e.Graphics);
            brush = new SolidBrush(Color.Black);
            e.Graphics.DrawString("LIVES: ", new Font("Comic Sans MS", 16), brush, new Point(Width - 260, 30));
            brush.Dispose();
            if (Scene.Character1.Lives == 3)
                e.Graphics.DrawImageUnscaled(Properties.Resources.heart, new Point(Width - 100, 30));
            if (Scene.Character1.Lives == 2 || Scene.Character1.Lives == 3)
                e.Graphics.DrawImageUnscaled(Properties.Resources.heart, new Point(Width - 130, 30));
            if (Scene.Character1.Lives == 1 || Scene.Character1.Lives == 2 || Scene.Character1.Lives == 3)
                e.Graphics.DrawImageUnscaled(Properties.Resources.heart, new Point(Width - 160, 30));
            if (Scene.Multiplayer)
            {
                lblScore.Visible= false;
                brush = new SolidBrush(Color.Black);
                e.Graphics.DrawString("LIVES: ", new Font("Comic Sans MS", 16), brush, new Point(30, 30));
                brush.Dispose();
                if (Scene.Character2.Lives == 3)
                    e.Graphics.DrawImageUnscaled(Properties.Resources.heart, new Point(190, 30));
                if (Scene.Character2.Lives == 2 || Scene.Character2.Lives == 3)
                    e.Graphics.DrawImageUnscaled(Properties.Resources.heart, new Point(160, 30));
                if (Scene.Character2.Lives == 1 || Scene.Character2.Lives == 2 || Scene.Character2.Lives == 3)
                    e.Graphics.DrawImageUnscaled(Properties.Resources.heart, new Point(130, 30));
            }
        }

        private void PlayingForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
                Scene.Character1.Right = true;
            if (e.KeyCode == Keys.Left)
                Scene.Character1.Left = true;
            if (e.KeyCode == Keys.Up)
            {
                if (Count <= 0 && !UpDone1)
                {
                    Scene.Character1.Up = true;
                    timerJump.Start();
                }
            }
            if (e.KeyCode == Keys.D)
                Scene.Character2.Right = true;
            if (e.KeyCode == Keys.A)
                Scene.Character2.Left = true;
            if (e.KeyCode == Keys.W)
            {
                if (Count2 <= 0 && !UpDone2)
                {
                    Scene.Character2.Up = true;
                    timerJump1.Start();
                }
            }
            Invalidate();
        }

        private void PlayingForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
                Scene.Character1.Right = false;
            if (e.KeyCode == Keys.Left)
                Scene.Character1.Left = false;
            if (e.KeyCode == Keys.D)
                Scene.Character2.Right = false;
            if (e.KeyCode == Keys.A)
                Scene.Character2.Left = false;
        }

        private void timerJump_Tick(object sender, EventArgs e)
        {
            if (Count < 13 && !UpDone1)
                Count++;
            else
            {
                UpDone1 = true;
                Scene.Character1.Up = false;
                Scene.Character1.Down = true;
                Count--;
                if (Count == -1)
                {
                    Scene.Character1.Down= false;
                    timerJump.Stop();
                    UpDone1 = false;
                    Scene.Character1.Position = new Point(Scene.Character1.Position.X, this.Height - 300);
                }
            }
            Invalidate();
        }

        private void timerJump1_Tick_1(object sender, EventArgs e)
        {
            if (Count2 < 13 && !UpDone2)
                Count2++;
            else
            {
                UpDone2 = true;
                Scene.Character2.Up = false;
                Scene.Character2.Down = true;
                Count2--;
                if (Count2 == -1)
                {
                    Scene.Character2.Down = false;
                    timerJump1.Stop();
                    UpDone2 = false;
                    Scene.Character2.Position = new Point(Scene.Character2.Position.X, this.Height - 220);
                }
            }
            Invalidate();
        }

        private void timerObstacle_Tick(object sender, EventArgs e)
        {
            Scene.AddObstacle();
        }

        private void timerMove_Tick(object sender, EventArgs e)
        {
            Scene.MoveObstacles();
            Scene.MoveCharacters();
            checkGameOver();
            Invalidate();
        }

        private void timerScore_Tick(object sender, EventArgs e)
        {
            Scene.Score++;
            lblScore.Text = "SCORE: " + Scene.Score.ToString();
            if (Scene.Score % 10 == 0 && timerAddObstacle.Interval > 100)
                timerAddObstacle.Interval = timerAddObstacle.Interval - 100;
        }

        private void checkGameOver()
        {
            if (!Scene.Multiplayer && Scene.Character1.Lives <= 0 && !GameOver)
                gameOver("Your score is: " + Scene.Score.ToString());
            if (Scene.Multiplayer && !GameOver)
            {
                if (Scene.Character1.Lives <= 0) 
                    gameOver("Player 2 wins!");
                if (Scene.Character2.Lives <= 0)
                    gameOver("Player 1 wins!");
            }
        }

        private void gameOver(String message)
        {
            GameOver = true;
            timerAddObstacle.Stop();
            timerMove.Stop();
            timerScore.Stop();
            DialogResult dg = MessageBox.Show(message, "GAME OVER", MessageBoxButtons.OK);
            if (dg == DialogResult.OK)
            {
                Menu menu = new Menu();
                this.Visible = false;
                menu.ShowDialog();
                this.Close();
            }
        }
    }
}
