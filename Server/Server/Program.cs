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
            bool makeNextLoop = true;

            byte[] buffer = new byte[256];

            int size;

            StringBuilder data = new StringBuilder();

            while (makeNextLoop)
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
                        listener.Shutdown(SocketShutdown.Both);
                        listener.Close();
                        makeNextLoop= false;
                        break;

                    case "FindDoctor":
                        FindDoctor(listener);
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

        public static void FindDoctor(Socket listener)
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

            string doctorName = data.ToString();
            data.Clear();

            listener.Send(Encoding.UTF8.GetBytes("GotData"));

            string sqlQuery = "SELECT * FROM Doctors WHERE Surname = @doctorName";

            SqlCommand cmd = new SqlCommand(sqlQuery, sqlConnection);

            cmd.Parameters.Add("@doctorName", SqlDbType.VarChar, 50).Value = doctorName;

            table.Load(cmd.ExecuteReader());

            string doctorInfo = DataTableToString(table);

            listener.Send(Encoding.UTF8.GetBytes(doctorInfo));
        }

        private static string DataTableToString(DataTable dt)
        {
            StringBuilder builder = new StringBuilder();

            foreach (DataRow row in dt.Rows)
            {
                for (int i = 0; i < row.ItemArray.Length; i++)
                {
                    string rowText = row.ItemArray[i].ToString();
                    if (rowText.Contains(","))
                    {
                        rowText = rowText.Replace(",", "/");
                    }

                    builder.Append(rowText + ",  ");
                }
                builder.Append(Environment.NewLine);
            }
            return builder.ToString();
        }
    }
}