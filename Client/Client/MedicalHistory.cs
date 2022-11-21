using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class MedicalHistory : Form
    {
        private AllAboutSocket socket;

        private string login;

        byte[] command = Encoding.UTF8.GetBytes("MedHistory");

        private int size;
        private byte[] buffer = new byte[256];
        private StringBuilder answer = new StringBuilder();

        public MedicalHistory(AllAboutSocket socket, string login)
        {
            InitializeComponent();
            this.socket = socket;
            this.login = login;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void MedicalHistory_Load(object sender, EventArgs e)
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
                socket.Send(Encoding.UTF8.GetBytes(login));

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
                    DoctorTextBox.Text = result;
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
            Cabinet cabinet = new Cabinet(socket, login);
            cabinet.Show();
            Hide();
        }
    }
}
