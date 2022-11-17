using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Data;
using System.Configuration;
using Microsoft.Data.SqlClient;

namespace Server
{
    public class Server
    {
        const string IP = "127.0.0.1";
        const int PORT = 8888;

        static void Main(string[] args)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Socket listener;
            IPEndPoint tcpEndPoint = new IPEndPoint(IPAddress.Parse(IP), PORT);

            Console.WriteLine("Server is online");

            socket.Bind(tcpEndPoint);
            socket.Listen(8);

            while (true)
            {
                listener = socket.Accept();
                Thread thread = new(() => { InEveryThread(listener); });
                thread.Start();
            }
        }

        public static void InEveryThread(Socket listener)
        {
            byte[] buffer = new byte[256];

            int size;

            StringBuilder data = new StringBuilder();

            while (true)
            {
                do
                {
                    size = listener.Receive(buffer);
                    data.Append(Encoding.UTF8.GetString(buffer, 0, size));
                }
                while (listener.Available > 0);

                string whatToDo = data.ToString();
                data.Clear();

                listener.Send(Encoding.UTF8.GetBytes("GotData"));

                switch (whatToDo)
                {
                    case "Authorisation":
                        Authorisation(listener);
                        break;

                    case "Registration":
                        Registration(listener);
                        break;

                    case "Disconnect":
                        Disconnect(listener);
                        break;
                }
            }
        }

        public static void Authorisation(Socket listener)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
            sqlConnection.Open();

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            byte[] buffer = new byte[256];
            int size;
            StringBuilder data = new StringBuilder();

            do
            {
                size = listener.Receive(buffer);
                data.Append(Encoding.UTF8.GetString(buffer, 0, size));
            }
            while (listener.Available > 0);

            string login = data.ToString();
            data.Clear();

            listener.Send(Encoding.UTF8.GetBytes("GotData"));

            do
            {
                size = listener.Receive(buffer);
                data.Append(Encoding.UTF8.GetString(buffer, 0, size));
            }
            while (listener.Available > 0);

            string password = data.ToString();
            data.Clear();

            listener.Send(Encoding.UTF8.GetBytes("GotData"));

            string sqlQuery = $"SELECT * FROM Accounts WHERE Login = @Login AND Password = @Password";

            SqlCommand cmd = new SqlCommand(sqlQuery, sqlConnection);

            cmd.Parameters.Add("@Login", SqlDbType.VarChar, 50).Value = login;
            cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = password;

            adapter.SelectCommand = cmd;
            adapter.Fill(table);

            if (table.Rows.Count != 1)  //if account not exists
            {
                table.Clear();
                listener.Send(Encoding.UTF8.GetBytes("Error"));
            }
            else
            {
                table.Clear();
                listener.Send(Encoding.UTF8.GetBytes("Success"));
            }
        }

        public static void Registration(Socket listener)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
            sqlConnection.Open();

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            byte[] buffer = new byte[256];
            int size;
            StringBuilder data = new StringBuilder();
            
            do
            {
                size = listener.Receive(buffer);
                data.Append(Encoding.UTF8.GetString(buffer, 0, size));
            }
            while (listener.Available > 0);

            string login = data.ToString();
            data.Clear();

            listener.Send(Encoding.UTF8.GetBytes("GotData"));

            do
            {
                size = listener.Receive(buffer);
                data.Append(Encoding.UTF8.GetString(buffer, 0, size));
            }
            while (listener.Available > 0);
            
            string password = data.ToString();
            data.Clear();

            listener.Send(Encoding.UTF8.GetBytes("GotData"));

            string sqlQuery = $"SELECT * FROM Accounts WHERE Login = @Login";

            SqlCommand cmd = new SqlCommand(sqlQuery, sqlConnection);

            cmd.Parameters.Add("@Login", SqlDbType.VarChar, 50).Value = login;

            adapter.SelectCommand = cmd;
            adapter.Fill(table);

            if (table.Rows.Count >= 1)  //if login already exists
            {
                table.Clear();
                listener.Send(Encoding.UTF8.GetBytes("Exists"));
            }
            else
            {
                table.Clear();
                sqlQuery = "INSERT INTO Accounts VALUES (@Login, @Password)";

                cmd = new SqlCommand(sqlQuery, sqlConnection);

                cmd.Parameters.Add("@Login", SqlDbType.VarChar, 50).Value = login;
                cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = password;

                if (cmd.ExecuteNonQuery() == 1)
                {
                    listener.Send(Encoding.UTF8.GetBytes("Success"));
                }
                else
                {
                    listener.Send(Encoding.UTF8.GetBytes("Error"));
                }
            }
            sqlConnection.Close();
        }

        public static void Disconnect(Socket listener)
        {
            listener.Shutdown(SocketShutdown.Both);
            listener.Close();
        }
    }
}