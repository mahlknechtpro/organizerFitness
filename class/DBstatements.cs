using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace organizerFitness
{
    public class DBstatements
    {
        private MySqlConnection connection;
        public string server;
        public string database;
        public string uid;
        public string password;

        //Constructor
        public DBstatements()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
           
        }

        //open connection to database
        public bool OpenConnection()
        {
        try
        {
            MySqlConnectionStringBuilder connectionString = new MySqlConnectionStringBuilder();
            connectionString.Server = "mimasrv2.ddns.net";
            connectionString.Port = 3306;
            connectionString.UserID = "mima";
            connectionString.Password = "mima_10492";
            connectionString.Database = "db_organizerFitness";
            connectionString.SslMode = MySqlSslMode.None;


            this.connection = new MySqlConnection(connectionString.ToString());
            this.connection.Open();

            return true;
        }
        catch (MySqlException ex)
        {
            switch (ex.Number)
            {
                case 0:
                   MessageBox.Show("Cannot connect to server.  Contact administrator");
                   break;
                case 1045:
                    MessageBox.Show("Invalid username/password, please try again");
                    break;
            }
            return false;
        }
    }

        //Close connection
        public bool CloseConnection()
        {
            try
            {
                this.connection.Close();
                return true;
            }
            catch (MySqlException ex)
{
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public int UserConnection(string username, string pwd)
        {
            string query = "SELECT Count(*) as user_count FROM t_user WHERE u_username = '" + username + "' && u_password = '" + pwd + "'";
            string user_count;

            Console.WriteLine("Query: " + query);
            Console.WriteLine("Try open connection");

            //Open Connection
            if (this.OpenConnection() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, this.connection);

                //ExecuteScalar will return one value
                user_count = cmd.ExecuteScalar().ToString();

                Console.WriteLine("user_count: " + user_count);
                //close Connection
                this.CloseConnection();

                if (Int32.Parse(user_count) == 1)
                {

                    forms.mainScreen mainScreen = new forms.mainScreen();
                    mainScreen.Show();

                }
                else
                {
                    MessageBox.Show("Username/Password is incorrect!");
                }

                return Int32.Parse(user_count);
            }
            else
            {
                MessageBox.Show("Check your Internet");
                return 0;
            }
        }

        public void DataFill()
        {

        }

        //Insert statement
        public void Insert()
        {
        }

        //Update statement
        public void Update()
        {
        }

        //Delete statement
        public void Delete()
        {
        }

        //Select statement
        /*public List<string>[] Select()
        {
            List<string> test =["test1", "test2"];
            return test[0];
        }*/

        //Count statement
        public int Count()
        {
            return 0;
        }

        //Backup
        public void Backup()
        {
        }

        //Restore
        public void Restore()
        {
        }
    }
}
