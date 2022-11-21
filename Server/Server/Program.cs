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

                    case "MedHistory":
                        MedHistory(listener);
                        break;

                    case "RegisterVisit":
                        RegisterVisit(listener);
                        break;

                    case "showVisits":
                        ShowVisits(listener);
                        break;

                    case "CancelVisits":
                        CancelVisits(listener);
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

            string sqlQuery = "SELECT * FROM Doctors WHERE Surname = @doctorName";

            SqlCommand cmd = new SqlCommand(sqlQuery, sqlConnection);

            cmd.Parameters.Add("@doctorName", SqlDbType.VarChar, 50).Value = doctorName;

            table.Load(cmd.ExecuteReader());
            sqlConnection.Close();

            if (table.Rows.Count < 1)  //if doctor not exists
            {
                listener.Send(Encoding.UTF8.GetBytes("There is no doctor with this surname"));
            }
            else
            {
                sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
                sqlConnection.Open();
                sqlQuery = "SELECT Name, Surname, Cabinet, DateTime FROM Visits WHERE Surname = @doctorName";

                cmd = new SqlCommand(sqlQuery, sqlConnection);

                cmd.Parameters.Add("@doctorName", SqlDbType.VarChar, 50).Value = doctorName;

                table = new DataTable();
                table.Load(cmd.ExecuteReader());

                string doctorInfo = DataTableToString(table);

                if (doctorInfo == "")
                    listener.Send(Encoding.UTF8.GetBytes("Doctor is free all the time"));
                else
                    listener.Send(Encoding.UTF8.GetBytes(doctorInfo));
                sqlConnection.Close();
            }
        }

        private static void MedHistory(Socket listener)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
            sqlConnection.Open();
            
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

            string sqlQuery = "SELECT * FROM MedicalHistory WHERE Login = @login";

            SqlCommand cmd = new SqlCommand(sqlQuery, sqlConnection);

            cmd.Parameters.Add("@login", SqlDbType.VarChar, 50).Value = login;

            table.Load(cmd.ExecuteReader());
            if (table.Rows.Count < 1)  //if doctor not exists
            {
                listener.Send(Encoding.UTF8.GetBytes("You have no medical history"));
            }
            else
            {
                StringBuilder builder = new StringBuilder();

                foreach (DataRow row in table.Rows)
                {
                    int counter = 0;
                    for (int i = 0; i < row.ItemArray.Length; i++)
                    {
                        string rowText = row.ItemArray[i].ToString();
                        if (rowText.Contains(","))
                        {
                            rowText = rowText.Replace(",", "/");
                        }
                        counter++;
                        if (counter == 5 || counter == 6)
                            builder.Append(rowText + Environment.NewLine);
                        else
                            builder.Append(rowText + ",  ");

                    }
                    builder.Append(Environment.NewLine);
                }

                string medHistory = builder.ToString();
                medHistory = medHistory.Replace($"{login}, ", "");
                medHistory = medHistory.Replace(" 0:00:00", "");

                listener.Send(Encoding.UTF8.GetBytes(medHistory));
            }
            sqlConnection.Close();
        }

        public static void RegisterVisit(Socket listener)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
            sqlConnection.Open();

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

            string surname = data.ToString();
            data.Clear();
            listener.Send(Encoding.UTF8.GetBytes("GotData"));

            do
            {
                size = listener.Receive(buffer);
                data.Append(Encoding.UTF8.GetString(buffer, 0, size));
            }
            while (listener.Available > 0);

            string dateTime = data.ToString();
            data.Clear();

            listener.Send(Encoding.UTF8.GetBytes("GotData"));

            do
            {
                size = listener.Receive(buffer);
                data.Append(Encoding.UTF8.GetString(buffer, 0, size));
            }
            while (listener.Available > 0);

            string login = data.ToString();
            data.Clear();

            listener.Send(Encoding.UTF8.GetBytes("GotData"));

            string sqlQuery = $"SELECT * FROM Visits WHERE Surname = @Surname AND DateTime = @DateTime";

            SqlCommand cmd = new SqlCommand(sqlQuery, sqlConnection);
            SqlDataAdapter adapter= new SqlDataAdapter();

            cmd.Parameters.Add("@Surname", SqlDbType.VarChar, 50).Value = surname;
            cmd.Parameters.Add("@DateTime", SqlDbType.DateTime).Value = dateTime;

            adapter.SelectCommand = cmd;
            adapter.Fill(table);

            sqlConnection.Close();

            if (table.Rows.Count >= 1)  //if doctor is busy
            {
                table.Clear();
                listener.Send(Encoding.UTF8.GetBytes("Exists"));
            }
            else
            {
                sqlConnection.Open();

                sqlQuery = "SELECT * FROM Doctors WHERE Surname = @Surname";

                cmd = new SqlCommand(sqlQuery, sqlConnection);

                cmd.Parameters.Add("@Surname", SqlDbType.VarChar, 50).Value = surname;

                table.Load(cmd.ExecuteReader());

                sqlConnection.Close();

                StringBuilder builder = new StringBuilder();

                string name = "", cabinet = "";

                foreach (DataRow row in table.Rows)
                {
                    for (int i = 0; i < row.ItemArray.Length; i++)
                    {
                        string rowText = row.ItemArray[i].ToString();
                        if (rowText.Contains(","))
                        {
                            rowText = rowText.Replace(",", "/");
                        }

                        builder.Append(rowText);
                        if (i == 1)
                            name = rowText;
                        if (i == 3)
                            cabinet = rowText;
                    }
                }
                sqlConnection.Open();

                sqlQuery = "INSERT INTO Visits VALUES (@Name, @Surname, @Cabinet, @DateTime, @Login)";

                cmd = new SqlCommand(sqlQuery, sqlConnection);

                cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = name;
                cmd.Parameters.Add("@Surname", SqlDbType.VarChar, 50).Value = surname;
                cmd.Parameters.Add("@Cabinet", SqlDbType.Int).Value = cabinet;
                cmd.Parameters.Add("@DateTime", SqlDbType.DateTime).Value = dateTime;
                cmd.Parameters.Add("@Login", SqlDbType.VarChar, 50).Value = login;

                if (cmd.ExecuteNonQuery() == 1)
                {
                    listener.Send(Encoding.UTF8.GetBytes("Success"));
                }
                else
                {
                    listener.Send(Encoding.UTF8.GetBytes("Error"));
                }
                sqlConnection.Close();
            }
        }

        public static void ShowVisits(Socket listener)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
            sqlConnection.Open();

            StringBuilder data = new StringBuilder();
            byte[] buffer = new byte[256];

            do
            {
                int size = listener.Receive(buffer);
                data.Append(Encoding.UTF8.GetString(buffer, 0, size));
            }
            while (listener.Available > 0);

            string login = data.ToString();
            data.Clear();

            DataTable table = new DataTable();

            string sqlQuery = $"SELECT ID, Name, Surname, DateTime, Login FROM Visits WHERE Login = @Login";

            SqlCommand cmd = new SqlCommand(sqlQuery, sqlConnection);

            cmd.Parameters.Add("@Login", SqlDbType.VarChar, 50).Value = login;

            table.Load(cmd.ExecuteReader());

            if (table.Rows.Count < 1)  //if doctor not exists
            {
                listener.Send(Encoding.UTF8.GetBytes("You have no registered visits"));
            }
            else
            {
                string visits = DataTableToString(table);
                listener.Send(Encoding.UTF8.GetBytes(visits));
            }
            sqlConnection.Close();
        }

        public static void CancelVisits(Socket listener)
        {
            StringBuilder data = new StringBuilder();

            byte[] buffer = new byte[256];
            string id = "";

            while (id != "thatWasLastOne")
            {
                SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
                sqlConnection.Open();

                do
                {
                    int size = listener.Receive(buffer);
                    data.Append(Encoding.UTF8.GetString(buffer, 0, size));
                }
                while (listener.Available > 0);

                id = data.ToString();
                data.Clear();

                if (id != "thatWasLastOne")
                {
                    string sqlQuery = "DELETE FROM Visits WHERE ID = @ID";

                    SqlCommand cmd = new SqlCommand(sqlQuery, sqlConnection);

                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;

                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        listener.Send(Encoding.UTF8.GetBytes("Success"));
                    }
                    else
                    {
                        listener.Send(Encoding.UTF8.GetBytes("Error"));
                    }
                }
                else
                    listener.Send(Encoding.UTF8.GetBytes("GotData"));
                sqlConnection.Close();
            }
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