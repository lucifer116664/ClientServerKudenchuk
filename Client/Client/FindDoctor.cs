using System;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class FindDoctor : Form
    {
        private AllAboutSocket socket;
        private string login;

        public FindDoctor(AllAboutSocket socket, string login)
        {
            InitializeComponent();
            this.socket = socket;
            this.login = login;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void FindDoctor_Load(object sender, EventArgs e)
        {
            LoginLabel.Text = login;
            ControlBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            socket.Connect();
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            socket.Send(Encoding.UTF8.GetBytes("Disconnect"));
            socket.Disconnect();
            Application.Exit();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Cabinet cabinet = new Cabinet(socket, login);
            cabinet.Show();
            Hide();
        }

        private void FindDoctorButton_Click(object sender, EventArgs e)
        {
            FindDoctorResult fDocRes = new FindDoctorResult(socket, login, DoctorNameTextBox.Text);
            fDocRes.Show();
            Hide();
        }
    }
}
