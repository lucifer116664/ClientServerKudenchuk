using System;
using System.Text;
using System.Windows.Forms;


namespace Client
{
    public partial class CancelVisit : Form
    {
        private AllAboutSocket socket;
        private string login;

        private byte[] command;
       
        private byte[] buffer = new byte[256];
        private int size;
        private StringBuilder answer = new StringBuilder();
        public CancelVisit(AllAboutSocket socket, string login)
        {
            InitializeComponent();
            this.socket = socket;
            this.login = login;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void CancelVisit_Load(object sender, EventArgs e)
        {
            LoginLabel.Text = login;
            ControlBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;

            socket.Connect();

            command = Encoding.UTF8.GetBytes("showVisits");
            socket.Send(command);

            do
            {
                size = socket.Receive(buffer);
                answer.Append(Encoding.UTF8.GetString(buffer, 0, size));
            }
            while (socket.AvailableBiggerThanZero());

            if (answer.ToString() != "GotData")
            {
                MessageBox.Show("Server didn`t got the data", "Server ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                string[] visitsArray = new string[1];
                char[] visitsBuffer = answer.ToString().ToCharArray();
                int visitsArrayCounter = 0;

                answer.Clear();

                for (int visitsBufferCounter = 0; visitsBufferCounter < visitsBuffer.Length; visitsBufferCounter++)
                {
                    if (visitsBuffer[visitsBufferCounter].Equals(','))
                    {
                        Array.Resize(ref visitsArray, visitsArray.Length + 1);
                        visitsArrayCounter++;
                    }
                    else if (visitsBuffer[visitsBufferCounter].Equals('\r') || visitsBuffer[visitsBufferCounter].Equals('\n'))
                    {
                        continue;
                    }
                    else
                    {
                        visitsArray[visitsArrayCounter] += visitsBuffer[visitsBufferCounter];
                    }
                }

                CheckedListBox.Items.Clear();

                for (int i = 0; i < visitsArray.Length - 1; i++)
                {
                    CheckedListBox.Items.Insert(i, visitsArray[i]);
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

        private void CancelButton_Click(object sender, EventArgs e)
        {
            command = Encoding.UTF8.GetBytes("CancelVisits");
            socket.Send(command);

            do
            {
                size = socket.Receive(buffer);
                answer.Append(Encoding.UTF8.GetString(buffer, 0, size));
            }
            while (socket.AvailableBiggerThanZero());

            if (answer.ToString() != "GotData")
            {
                MessageBox.Show("Server didn`t got the data", "Server ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                answer.Clear();
                foreach (string item in CheckedListBox.CheckedItems)
                {
                    string id = "";
                    char[] row = item.ToCharArray();

                    foreach(char c in row)
                    {
                        if (c == ',')
                            break;
                        id += c.ToString();
                    }

                    socket.Send(Encoding.UTF8.GetBytes(id));

                    do
                    {
                        size = socket.Receive(buffer);
                        answer.Append(Encoding.UTF8.GetString(buffer, 0, size));
                    }
                    while (socket.AvailableBiggerThanZero());

                    if (answer.ToString() != "Success")
                    {
                        MessageBox.Show("Server can not delete this users", "Server ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        answer.Clear();
                    }
                    else
                    {
                        answer.Clear();
                    }
                }
                socket.Send(Encoding.UTF8.GetBytes("thatWasLastOne"));

                do
                {
                    size = socket.Receive(buffer);
                    answer.Append(Encoding.UTF8.GetString(buffer, 0, size));
                }
                while (socket.AvailableBiggerThanZero());

                if (answer.ToString() != "GotData")
                {
                    MessageBox.Show("Server didn`t got the command to stop", "Server ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                answer.Clear();
                CancelVisit_Load(sender, e);

            }
        }
    }
}
