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

         
            Color color1 = Color.FromArgb(44, 62, 80);  
            Color color2 = Color.FromArgb(253, 116, 0); 

           
            using (System.Drawing.Drawing2D.LinearGradientBrush brush =
                new System.Drawing.Drawing2D.LinearGradientBrush(this.ClientRectangle, color1, color2, 45F))
            {
              
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

        private void ContactDeveloper_Click(object sender, EventArgs e) 
        {
            ContactUs contactDeveloper = new ContactUs();

            contactDeveloper.Show();
            this.Hide();
        }

        private void MessageUs_Click(object sender, EventArgs e) 
        {
            MessageUs messageUs = new MessageUs();
            messageUs.Show();
            this.Hide();
        }

        private void Support_Click(object sender, EventArgs e) 
        {
            SupportUs support = new SupportUs();
            support.Show();
            this.Hide();
        }
    }
}
