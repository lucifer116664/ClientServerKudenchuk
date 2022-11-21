using System;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class FindDoctorResult : Form
    {
        private AllAboutSocket socket;
        private string login;

        byte[] command = Encoding.UTF8.GetBytes("FindDoctor");
        byte[] doctor;

        private int size;
        private byte[] buffer = new byte[256];
        private StringBuilder answer = new StringBuilder();

        public FindDoctorResult(AllAboutSocket socket, string login, string doctor)
        {
            InitializeComponent();

            this.socket = socket;
            this.login = login;
            this.doctor = Encoding.UTF8.GetBytes(doctor);

            StartPosition = FormStartPosition.CenterScreen;
        }

        private void FindDoctorResult_Load(object sender, EventArgs e)
        {
            LoginLabel.Text = login;
            ControlBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            socket.Connect();

            socket.Send(command);

            do
            {
                size = socket.Receive(buffer);
                answer.Append(Encoding.UTF8.GetString(buffer, 0, size));
            }
            while (socket.AvailableBiggerThanZero());

            if (answer.ToString() != "GotData")
            {
                MessageBox.Show("Server didn`t got the data", "Server ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                answer.Clear();
                socket.Send(doctor);

                do
                {
                    size = socket.Receive(buffer);
                    answer.Append(Encoding.UTF8.GetString(buffer, 0, size));
                }
                while (socket.AvailableBiggerThanZero());

                if (answer.ToString() != "GotData")
                {
                    MessageBox.Show("Server didn`t got the data", "Server ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    answer.Clear();

                    do
                    {
                        size = socket.Receive(buffer);
                        answer.Append(Encoding.UTF8.GetString(buffer, 0, size));
                    }
                    while (socket.AvailableBiggerThanZero());

                    string result = answer.ToString();
                }
            }
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            socket.Send(Encoding.UTF8.GetBytes("Disconnect"));
            socket.Disconnect();
            Application.Exit();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            FindDoctor fDoc = new FindDoctor(socket, login);
            fDoc.Show();
            Hide();
        }
    }
}
