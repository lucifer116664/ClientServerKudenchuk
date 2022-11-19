using System;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class Authorisation : Form
    {
        private int size;
        private byte[] buffer = new byte[256];
        private StringBuilder answer = new StringBuilder();

        public Authorisation()
        {
            InitializeComponent();
            StartPosition= FormStartPosition.CenterScreen;
        }

        private void Authorisation_Load(object sender, EventArgs e)
        {
            ControlBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;

            PasswordTextbox.PasswordChar = '⁕';
            ShowPictureBox.Visible = true;
            HidePictureBox.Visible = false;
        }

        private void ShowPictureBox_Click(object sender, EventArgs e)
        {
            PasswordTextbox.UseSystemPasswordChar = true;
            ShowPictureBox.Visible = false;
            HidePictureBox.Visible = true;
        }

        private void HidePictureBox_Click(object sender, EventArgs e)
        {
            PasswordTextbox.UseSystemPasswordChar = false;
            ShowPictureBox.Visible = true;
            HidePictureBox.Visible = false;
        }

        private void CreateAccButton_Click(object sender, EventArgs e)
        {
            Registration reg = new Registration();
            reg.Show();
            Hide();
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LogInButton_Click(object sender, EventArgs e)
        {
            AllAboutSocket socket = new AllAboutSocket();
            socket.Connect();

            var command = Encoding.UTF8.GetBytes("Authorisation");
            var login = Encoding.UTF8.GetBytes(LoginTextbox.Text);
            var password = Encoding.UTF8.GetBytes(Program.PasswordHashing(PasswordTextbox.Text));

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
                socket.Send(login);

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
                    socket.Send(password);

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

                        string serverAnswer = answer.ToString();
                        answer.Clear();

                        switch (serverAnswer)
                        {
                            case "Success":
                                Cabinet cabinet = new Cabinet(socket, Encoding.UTF8.GetString(login));
                                cabinet.Show();
                                Hide();
                                break;

                            case "Error":
                                MessageBox.Show("Login or password is wrong", "Wrong login or password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                socket.Send(Encoding.UTF8.GetBytes("Disconnect"));
                                socket.Disconnect();
                                break;

                            default:
                                MessageBox.Show(serverAnswer, "Where is it from?", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                socket.Send(Encoding.UTF8.GetBytes("Disconnect"));
                                socket.Disconnect();
                                break;
                        }
                    }
                }
            }
        }

    }
}
