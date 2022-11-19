using System;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class Cabinet : Form
    {
        private AllAboutSocket socket;
        private string login;

        public Cabinet(AllAboutSocket socket, string login)
        {
            InitializeComponent();
            this.login = login;
            this.socket = socket;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Cabinet_Load(object sender, EventArgs e)
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

        private void RegisterVisitButton_Click(object sender, EventArgs e)
        {
            RegisterVisit registerVisit= new RegisterVisit(socket, login);
            registerVisit.Show();
            Hide();
        }

        private void FindDoctorButton_Click(object sender, EventArgs e)
        {
            FindDoctor findDoc = new FindDoctor(socket, login);
            findDoc.Show();
            Hide();
        }

        private void MedicalHistoryButton_Click(object sender, EventArgs e)
        {
            MedicalHistory medHistory = new MedicalHistory(socket, login);
            medHistory.Show();
            Hide();
        }

        private void CancelVisitButton_Click(object sender, EventArgs e)
        {
            CancelVisit cancelVisit= new CancelVisit(socket, login);
            cancelVisit.Show();
            Hide();
        }
    }
}
