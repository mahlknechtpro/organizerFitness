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
    /// Interaktionslogik für clientCharts.xaml
    /// </summary>
    public partial class clientCharts : Window
    {
        private MySqlConnection connection;

        public clientCharts(string clientNr)
        {
            InitializeComponent();

            lbl_clientNr.Content = clientNr.ToString();

            DBstatements db = new DBstatements();

            if (db.OpenConnection() == true)
            {
                string getQuery = (
                    " SELECT v_arm" +
                    " FROM t_cvalues" +
                    " WHERE v_cid = "+ clientNr + ";");

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
                    }
                }

                MySqlCommand cmd = new MySqlCommand(getQuery, connection);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    double values = Convert.ToDouble(rdr.GetString(0));
                    double values1 = Convert.ToDouble(rdr.GetString(1));
                    double values2 = Convert.ToDouble(rdr.GetString(1));
                    double values3 = Convert.ToDouble(rdr.GetString(1));
                    double values4 = Convert.ToDouble(rdr.GetString(1));

                    double[] dataX = new double[] { 1, 2, 3, 4, 5 };
                    double[] dataY = new double[] { values, values1, values2, values3, values4 };

                    plot_clientValues.Plot.AddScatter(dataX, dataY);
                    plot_clientValues.Refresh();


                    rdr.Close();
                }

                db.CloseConnection();
            }
        }
    }
}
