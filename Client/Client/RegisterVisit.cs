using System;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class RegisterVisit : Form
    {
        private AllAboutSocket socket;
        private string login;

        private byte[] command = Encoding.UTF8.GetBytes("RegisterVisit");

        private int size;
        private byte[] buffer = new byte[256];
        private StringBuilder answer = new StringBuilder();


        public RegisterVisit(AllAboutSocket socket, string login)
        {
            InitializeComponent();
            this.socket = socket;
            this.login = login;
            StartPosition= FormStartPosition.CenterScreen;
        }

        private void RegisterVisit_Load(object sender, EventArgs e)
        {
            LoginLabel.Text = login;
            ControlBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            NameTextbox.Text = "";
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

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            string docSurname = NameTextbox.Text;
            string dateTime = DatePicker.Value.ToString();

            dateTime = dateTime.Replace("0:00:00", TimePicker.Text + ":00");

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
                socket.Send(Encoding.UTF8.GetBytes(docSurname));

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
                    socket.Send(Encoding.UTF8.GetBytes(dateTime));

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

                            if (answer.ToString() == "Success")
                            {
                                MessageBox.Show("You were registered", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                RegisterVisit_Load(sender, e);
                                answer.Clear();
                            }
                            else if (answer.ToString() == "Exists")
                            {
                                MessageBox.Show("You can not rigister in this time", "Doctor is busy", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                answer.Clear();
                            }
                            else
                            {
                                MessageBox.Show(answer.ToString(), "Server ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                answer.Clear();
                            }
                        }
                    }
                }
            }
        }

        private void TimePicker_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
