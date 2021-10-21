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

            //Save clientNr
            lbl_clientNr.Content = cellValue;

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
                    "       ,c_size" +
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

                    if (rdr.GetString(6) == "Bancomat")
                    {
                        MessageBox.Show("Pay: " + rdr.GetString(6));
                        cmb_pay.Text = "Bancomat";
                    }

                    cmb_pay.SelectedValue = rdr.GetString(6);
                    txtb_phone.Text = rdr.GetString(7);
                    txtb_email.Text = rdr.GetString(8);
                    txtblo_notice.Text = rdr.GetString(9);
                    txtb_size.Text = rdr.GetString(10);

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
            //Initialize object
            DBstatements db = new DBstatements();

            //Initialize variables
            string clientNr;
            string firstname;
            string lastname;
            string birth_day;
            string birth_month;
            string birth_year;
            string birthdate;
            string phone;
            string email;
            string codfisc;
            string payment;
            string height;
            string weight;
            string notice;
            string size;

            clientNr = lbl_clientNr.Content.ToString();
            firstname = txtb_firstname.Text;
            lastname = txtb_lastname.Text;
            phone = txtb_phone.Text;
            email = txtb_email.Text;
            codfisc = txtb_codfisc.Text;
            payment = cmb_pay.Text;
            height = txtb_height.Text;
            weight = txtb_weight.Text;
            notice = txtblo_notice.Text;
            size = txtb_size.Text;

            birth_day = txtb_birthday.Text;
            birth_month = txtb_birthmonth.Text;
            birth_year = txtb_birthyear.Text;
            birthdate = birth_year + "-" + birth_month + "-" + birth_day;

            height = height.Replace(',', '.');
            weight = weight.Replace(',', '.');

            db.UpdateClient(clientNr,firstname, lastname, birthdate, phone, email, codfisc, payment, size, height, weight, notice);
        }
    }
}
