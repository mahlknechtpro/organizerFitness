﻿using MySql.Data.MySqlClient;
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

            
        }

        private void bodyValues_onClick(object sender, RoutedEventArgs e)
        {
            string clientNr = lbl_clientNr.Content.ToString();
            string bodyPart = cmb_bodyPart.Text;
            string sqlBody = "";

            plot_clientValues.Refresh();

            //MessageBox.Show(bodyPart);

            if (bodyPart == "Arm")
                sqlBody = "v_arm";
            else if (bodyPart == "Chest")
                sqlBody = "v_chest";
            else if (bodyPart == "Leg")
                sqlBody = "v_leg";
            else if (bodyPart == "Calves")
                sqlBody = "v_calves";
            else if (bodyPart == "Stomach")
                sqlBody = "v_hips";
            else if (bodyPart == "Muscle")
                sqlBody = "v_muscle";
            else if (bodyPart == "Fat")
                sqlBody = "v_fat";
            else if (bodyPart == "vFat")
                sqlBody = "v_vFat";
            else if (bodyPart == "Calories")
                sqlBody = "v_calories";
            else if (bodyPart == "Weight")
                sqlBody = "v_weight";
            else
                MessageBox.Show("Nothing selected!");

            DBstatements db = new DBstatements();


            if (db.OpenConnection() == true)
            {
                string getQuery = (
                    " SELECT " + sqlBody +
                    " FROM t_cvalues" +
                    " WHERE v_cid = " + clientNr + " " +
                    " ORDER BY vid ASC LIMIT 5;");

                Console.WriteLine(getQuery);

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

                double[] values = { 0.0, 0.0, 0.0, 0.0, 0.0 };
                int i = 0;
                MySqlCommand cmd = new MySqlCommand(getQuery, connection);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    //MessageBox.Show(i.ToString());
                    values[i] = Convert.ToDouble(rdr.GetString(0));
                    MessageBox.Show(values[i].ToString());
                    i++;
                }

                double[] dataX = new double[] { 1, 2, 3, 4, 5 };
                double[] dataY = new double[] { values[0], values[1], values[2], values[3], values[4] };
                plot_clientValues.Plot.AddScatter(dataX, dataY);

                plot_clientValues.Refresh();

                Array.Clear(dataY, 0, dataY.Length);


                rdr.Close();
                db.CloseConnection();
            }
        }
    }
}