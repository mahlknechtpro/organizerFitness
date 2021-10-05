using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace organizerFitness.forms
{
    /// <summary>
    /// Interaktionslogik für clientScreen.xaml
    /// </summary>
    public partial class clientScreen : Window
    {
        private MySqlConnection connection;

        public clientScreen(string cellValue)
        {
            InitializeComponent();

            DBstatements db = new DBstatements();

            if(db.OpenConnection() == true)
            {
                string getQuery = (
                    "SELECT  c_name" +
                    "       ,c_lastname" +
                    "       ,c_birth" +
                    "       ,c_height" +
                    "       ,c_startweight" +
                    "       ,c_codfisc" +
                    "       ,c_pay" +
                    "       ,c_phone" +
                    "       ,c_email" +
                    "       ,c_notice" +
                    " FROM t_clients" +
                    " WHERE cid = '" + cellValue + "';" );

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
                }

                MySqlCommand cmd = new MySqlCommand(getQuery, connection);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    /*
                     string getQuery = (
                    "SELECT  c_name" +
                    "       ,c_lastname" +
                    "       ,c_birth" +
                    "       ,c_height" +
                    "       ,c_startweight" +
                    "       ,c_codfisc" +
                    "       ,c_pay" +
                    "       ,c_phone" +
                    "       ,c_email" +
                    "       ,c_notice" +
                    " FROM t_clients" +
                    " WHERE cid = '" + cellValue + "';" );
                    */

                    //Set birthday
                    string birthday = rdr.GetString(2);
                    string day = birthday.Substring(0,2);
                    string month = birthday.Substring(3,2);
                    string year = birthday.Substring(6,4);

                    txtb_firstname.Text = rdr.GetString(0);
                    txtb_lastname.Text = rdr.GetString(1);
                    txtb_birthday.Text = day;
                    txtb_birthmonth.Text = month;
                    txtb_birthyear.Text = year;
                    txtb_height.Text = rdr.GetString(3);
                    txtb_weight.Text = rdr.GetString(4);
                    txtb_codfisc.Text = rdr.GetString(5);
                    //Problem Wert kann nicht angezeigt werden
                    //cmb_pay. = rdr.GetString(6);
                    txtb_phone.Text = rdr.GetString(7);
                    txtb_email.Text = rdr.GetString(8);
                    txtblo_notice.Text = rdr.GetString(9);

                    MessageBox.Show("birthday: " + day + month + year);
                    
                }

                db.CloseConnection();
            }
        }

        private void btn_Client_close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_Client_save(object sender, RoutedEventArgs e)
        {

        }
    }
}
