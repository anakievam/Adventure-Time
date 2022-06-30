namespace Adventure_Time
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            PlayingForm newForm = new PlayingForm();
            newForm.Scene.Multiplayer = false;
            this.Visible = false;
            newForm.ShowDialog();
            this.Close();
        }

        private void btnMultiplayer_Click(object sender, EventArgs e)
        {
            PlayingForm newForm = new PlayingForm();
            newForm.Scene.Multiplayer = true;
            this.Visible = false;
            newForm.ShowDialog();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo);
            if (dg == DialogResult.Yes)
                this.Close();
        }
    }
}