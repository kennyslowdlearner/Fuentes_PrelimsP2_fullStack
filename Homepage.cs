namespace Fuentes_PrelimsP2
{
    public partial class Homepage : Form
    {
        public Homepage()
        {
            InitializeComponent();
        }


        private void Homepage_Paint(object sender, PaintEventArgs e)
        {

            // Define your two colors (use RGB from Canva)
            Color color1 = Color.FromArgb(44, 62, 80);  // Dark Blue
            Color color2 = Color.FromArgb(253, 116, 0); // AWS Orange

            // Create the brush
            using (System.Drawing.Drawing2D.LinearGradientBrush brush =
                new System.Drawing.Drawing2D.LinearGradientBrush(this.ClientRectangle, color1, color2, 45F))
            {
                // Paint the background
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }

        }

        

        private void loginButton_Click(object sender, EventArgs e)
        {
            LoginOptions loginOptions = new LoginOptions();

            loginOptions.Show();

            this.Hide();
        }

        private void signupButton_Click(object sender, EventArgs e)
        {
            UserSignUp userSignUp = new UserSignUp();

            userSignUp.Show();
            this.Hide();
        }

        private void Homepage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void AboutUs(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AboutUs about = new AboutUs();
            about.Show();

            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Objectives objectives = new Objectives();

            objectives.Show();

            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VisionMission vm = new VisionMission();
            vm.Show();

            this.Hide();
        }
    }
}
