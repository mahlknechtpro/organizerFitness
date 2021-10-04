using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;
using organizerFitness.forms;
using organizerFitness.Views;
using organizerFitness.Viewmodels;
using System.Data;
using Tulpep.NotificationWindow;
using organizerFitness.Models;

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
                connectionString.Server = "159.69.105.146";
                connectionString.Port = 3331;
                connectionString.UserID = "root";
                connectionString.Password = "Mmn339FpS#E2f99!et";
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
            string query = (
                "SELECT Count(*) as user_count" 
            +   "  FROM t_user" 
            +   " WHERE u_username = '" + username + "'" 
            +   "   AND u_password = '" + pwd + "'"
            +   ";"
            );
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
                    //User pm Pwd 1234 for technician
                    if (username=="pm" && pwd == "1234")
                    {
                        forms.mainScreen mainScreen = new forms.mainScreen();
                        mainScreen.Show();
                    }
                    else
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

        //Insert NewClient
        public void InsertNewClient(string firstname, string lastname, string birthdate, string phone, string email, string codfisc, string payment, string height, string weight, string notice)
        {
            string query = (
                "INSERT "
            +   "  INTO t_clients "
            +   "     ( `c_name`"
            +   "     ,`c_lastname`"
            +   "     ,`c_birth`"
            +   "     ,`c_height`"
            +   "     ,`c_startweight`"
            +   "     ,`c_codfisc`"
            +   "     ,`c_pay`"
            +   "     ,`c_phone`"
            +   "     ,`c_email`"
            +   "     ,`c_notice`"
            +   "     ) "
            +   "VALUES "
            +   "     ( '" + firstname + "'"
            +   "     , '" + lastname + "'"
            +   "     , '" + birthdate + "'"
            +   "     , '" + height + "'"
            +   "     , '" + weight + "'"
            +   "     , '" + codfisc + "'"
            +   "     , '" + payment + "'"
            +   "     , '" + phone + "'"
            +   "     , '" + email + "'"
            +   "     , '" + notice + "'"
            +   "     )"
            +   ";"
            );

            

            if (this.OpenConnection() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, this.connection);

                MySqlDataReader MyReader2 = cmd.ExecuteReader();

                MessageBox.Show("Data saved!");

                this.connection.Close();

            }
        }

        public void InsertNewContract(string clientNr, string conStart, string conEnd, int length, string paid)
        {
            Console.WriteLine("New Contract- Data: " + clientNr + " " + conStart + " " + length + " " + conEnd);

            string querySearchContract = (
                "SELECT COUNT(*)"
            +   "  FROM t_contracts"
            +   " WHERE co_active = 1"
            +   "   AND co_number = '" + clientNr + "'"
            +   ";"
            );

            //Check if contract already exists
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(querySearchContract, this.connection);

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                Console.WriteLine("Count: " + count);

                //If yes put flag co_active on 0
                if (count == 1)
                {
                    string querySetNullActive = (
                        "UPDATE t_contracts"
                    +   "   SET co_active = 0"
                    +   " WHERE co_number = '" + clientNr + "'"
                    +   ";"
                    );

                    MySqlCommand cmdSetNull = new MySqlCommand(querySetNullActive, this.connection);

                    MySqlDataReader MyReader2 = cmdSetNull.ExecuteReader();
                }
            }

            //Insert new contract for client
            string queryNewContract = (
                "INSERT" 
            +   "  INTO t_contracts" 
            +   "     ( `co_number`" 
            +   "     , `co_begin`" 
            +   "     , `co_end`" 
            +   "     , `co_active`" 
            +   "     , `co_duration`" 
            +   "     , `co_paid`" 
            +   "     ) " 
            +   "VALUES "
            +   "     ( '" + clientNr + "'" 
            +   "     , '" + conStart + "'" 
            +   "     , '" + conEnd + "'" 
            +   "     , 1"
            +   "     , '" + length + "'" 
            +   "     , '" + paid + "'" 
            +   "     )"
            +   ";"
            );
            Console.WriteLine("Test: " + queryNewContract);

            if (this.OpenConnection() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(queryNewContract, this.connection);

                MySqlDataReader MyReader2 = cmd.ExecuteReader();

                MessageBox.Show("Data saved!");
                
                this.connection.Close();

            }

        }

        public string getNotice(string index, string notice)
        {

            string query = (
                "SELECT c_notice" 
            +   "  FROM t_clients" 
            +   " WHERE cid ='" + index + "'"
            +   ";"
            );
            string user_notice;

            //Open Connection
            if (this.OpenConnection() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, this.connection);

                //ExecuteScalar will return one value
                user_notice = cmd.ExecuteScalar().ToString();

                //close Connection
                this.CloseConnection();

                if(user_notice != null)
                {
                    //string noticeClient;

                    forms.userNotice userNotice = new forms.userNotice(user_notice, index);
                    userNotice.Show();
                }

            }
                
            return notice;
        }

        public void setNotice(string noticeClient, string clientID)
        {
            //Insert new contract for client
            string query = (
                "UPDATE t_clients" 
            +   "   SET c_notice = '" + noticeClient + "' " 
            +   " WHERE cid = '" + clientID + "'" 
            +   ";"
            );

            Console.WriteLine("Test Query: " + query);

            if (this.OpenConnection() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, this.connection);

                MySqlDataReader MyReader = cmd.ExecuteReader();

                this.CloseConnection();

            }
        }

        public void getFinishContract()
        {
            //Show Contracts
            if (this.OpenConnection() == true)
            {
                DateTime dateTime = DateTime.UtcNow.Date;
                string getQuery = (
                    "SELECT DATE_FORMAT(DATE_SUB(tco.co_end, INTERVAL 7 DAY), '%d.%m.%Y')" 
                +   "     , tco.co_number" 
                +   "     , tcl.c_name" 
                +   "     , tcl.c_lastname" 
                +   "  FROM t_contracts  AS tco"
                +   " INNER"
                +   "  JOIN t_clients    AS tcl"
                +   "    ON tcl.cid       = tco.co_number"
                +   " WHERE tco.co_active = 1"
                +   ";"
                );
                
                MySqlCommand cmd = new MySqlCommand(getQuery, this.connection);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    if (rdr.GetString(0) == dateTime.ToString("dd/MM/yyyy"))
                    {
                        PopupNotifier popup = new PopupNotifier();
                        popup.Image = Properties.Resources.mail;
                        popup.TitleText = "Contract is ending!";
                        popup.ContentText = "The contract of " + rdr.GetString(3) + " " + rdr.GetString(2) + " ends in 7 days (" + rdr.GetString(0) + ")!";
                        popup.Popup();
                    }

                }
            }

            //Console.WriteLine("Date: " + dateContract);
        }

        public ClientValues GetBodyValues(string clientNr)
        {
            //Show Contracts
            if (this.OpenConnection() == true)
            {

                Console.WriteLine(clientNr[0]);

                //Hinzufügen VFat

                //ex.: SELECT v_cid, v_date, v_arm, v_chest, v_leg, v_calves, v_stomach,
                //v_hips, v_muscle, v_fat, v_calories, v_weight FROM t_cvalues WHERE v_cid = 1 AND
                //vid = (SELECT MAX(vid) FROM t_cvalues WHERE v_cid = 1);
                string query = (
                    "SELECT v_cid"
                +   "     , v_calories"
                +   "     , v_date" 
                +   "     , v_arm" 
                +   "     , v_chest" 
                +   "     , v_leg" 
                +   "     , v_calves" 
                +   "     , v_stomach" 
                +   "     , v_hips" 
                +   "     , v_muscle" 
                +   "     , v_fat" 
                +   "     , v_vfat"
                +   "     , v_weight"
                +   "  FROM t_cvalues" 
                +   " WHERE v_cid = " + clientNr
                +   "   AND vid = ("
                +   "        SELECT MAX(vid)"
                +   "          FROM t_cvalues" 
                +   "         WHERE v_cid = " + clientNr
                +   "             )"
                +   ";"
                );

                MySqlCommand cmd = new MySqlCommand(query, this.connection);
                MySqlDataReader rdr = cmd.ExecuteReader();

                try
                {
                    rdr.Read();

                    return new ClientValues(
                        rdr.GetInt32(0),      //ClientNr
                        rdr.GetInt32(1),      //Kalorien
                        rdr.GetDateTime(2),   //Datum
                        rdr.GetDecimal(3),    //Arm
                        rdr.GetDecimal(4),    //Brust
                        rdr.GetDecimal(5),    //Beine
                        rdr.GetDecimal(6),    //Unterschenkel
                        rdr.GetDecimal(7),    //Bauch
                        rdr.GetDecimal(8),    //Hüfte
                        rdr.GetDecimal(9),    //Muskeln
                        rdr.GetDecimal(10),   //Fett
                        rdr.GetDecimal(11),   //vFett
                        rdr.GetDecimal(12)    //Gewicht
                    );
                } catch (Exception ex)
                {
                    return new ClientValues(-100);
                }
            } else
            {
                return new ClientValues(-100);
            }
        }

        public void saveClientValues(string clientNr, string v_arm, string v_chest, string v_upperlegs,
            string v_calves, string v_stomach, string v_hips, string v_muscles,
                string v_fat, string v_vfat, string v_calories, string v_weight)
        {

            string dateToday = DateTime.Now.ToString("yyyy-MM-dd");

            if (this.OpenConnection() == true)
            {
                string query = "INSERT"
            + "  INTO t_cvalues"
            + "     ( `v_cid`"
            + "     , `v_date`"
            + "     , `v_arm`"
            + "     , `v_chest`"
            + "     , `v_leg`"
            + "     , `v_calves`"
            + "     , `v_stomach`"
            + "     , `v_hips`"
            + "     , `v_muscle`"
            + "     , `v_fat`"
            + "     , `v_vfat`"
            + "     , `v_calories`"
            + "     , `v_weight`"
            + "     ) "
            + "VALUES "
            + "     ( '" + clientNr + "'"
            + "     , '" + dateToday + "'"
            + "     , '" + v_arm + "'"
            + "     , '" + v_chest + "'"
            + "     , '" + v_upperlegs + "'"
            + "     , '" + v_calves + "'"
            + "     , '" + v_stomach + "'"
            + "     , '" + v_hips + "'"
            + "     , '" + v_muscles + "'"
            + "     , '" + v_fat + "'"
            + "     , '" + v_vfat + "'"
            + "     , '" + v_calories + "'"
            + "     , '" + v_weight + "'"
            + "     )"
            + ";";

                Console.WriteLine(query);
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, this.connection);

                MySqlDataReader MyReader = cmd.ExecuteReader();

                this.CloseConnection();

            }
        }
    }
}
