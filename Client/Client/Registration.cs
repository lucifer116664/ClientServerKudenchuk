using System;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class Registration : Form
    {
        private int size;
        private byte[] buffer = new byte[256];
        StringBuilder answer = new StringBuilder();

        public Registration()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            ControlBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;

            PasswordTextBox.PasswordChar = '⁕';
            ShowPictureBox.Visible = true;
            HidePictureBox.Visible = false;
        }

        private void ShowPictureBox_Click(object sender, EventArgs e)
        {
            PasswordTextBox.UseSystemPasswordChar = true;
            ShowPictureBox.Visible = false;
            HidePictureBox.Visible = true;
        }

        private void HidePictureBox_Click(object sender, EventArgs e)
        {
            PasswordTextBox.UseSystemPasswordChar = false;
            ShowPictureBox.Visible = true;
            HidePictureBox.Visible = false;
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CreateAccountButton_Click(object sender, EventArgs e)
        {
            if (LoginTextBox.Text.Length < 1 || LoginTextBox.Text.Length > 50)
            {
                MessageBox.Show("Login must be at least 1 symbol and less then 50 symbols long", "Wrong login format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (PasswordTextBox.Text.Length < 4 || PasswordTextBox.Text.Length > 50)
                {
                    MessageBox.Show("Password must be at least 4 symbols and less then 50 symbols long", "Wrong password format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    AllAboutSocket socket = new AllAboutSocket();
                    socket.Connect();

                    var command = Encoding.UTF8.GetBytes("Registration");
                    var newLogin = Encoding.UTF8.GetBytes(LoginTextBox.Text);
                    var newPassword = Encoding.UTF8.GetBytes(Program.PasswordHashing(PasswordTextBox.Text));

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

                        socket.Send(newLogin);

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

                            socket.Send(newPassword);
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
                                        MessageBox.Show("Account was registred", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        socket.Send(Encoding.UTF8.GetBytes("Disconnect"));
                                        socket.Disconnect();
                                        Authorisation logIn = new Authorisation();
                                        logIn.Show();
                                        Hide();
                                        break;

                                    case "Exists":
                                        MessageBox.Show("Account with this login already exists", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        socket.Send(Encoding.UTF8.GetBytes("Disconnect"));
                                        socket.Disconnect();
                                        break;

                                    case "Error":
                                        MessageBox.Show("Server can not register dis account", "Server ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void AuthoriseButton_Click(object sender, EventArgs e)
        {
            Authorisation logIn = new Authorisation();
            logIn.Show();
            Hide();
        }

    }
}
