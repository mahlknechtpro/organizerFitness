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

            DBstatements db = new DBstatements();

            lbl_clientNr.Content = clientNr.ToString();

            clientNr = lbl_clientNr.Content.ToString();
            string sqlBody = "v_arm";

            showCharts(sqlBody);

        }

        public void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                //do work when tab is changed

                string sqlBody = "v_arm";

                if (ti_arm.IsSelected)
                {
                    Console.WriteLine("Arm");
                    sqlBody = "v_arm";
                    showCharts(sqlBody);
                }
                if (ti_chest.IsSelected)
                {
                    Console.WriteLine("Chest");
                    sqlBody = "v_chest";
                    showCharts(sqlBody);
                }
                if (ti_leg.IsSelected)
                {
                    Console.WriteLine("Leg");
                    sqlBody = "v_leg";
                    showCharts(sqlBody);
                }
                if (ti_calves.IsSelected)
                {
                    Console.WriteLine("Calves");
                    sqlBody = "v_calves";
                    showCharts(sqlBody);
                }
                if (ti_stomach.IsSelected)
                {
                    Console.WriteLine("Stomach");
                    sqlBody = "v_stomach";
                    showCharts(sqlBody);
                }
                if (ti_hips.IsSelected)
                {
                    Console.WriteLine("Hips");
                    sqlBody = "v_hips";
                    showCharts(sqlBody);
                }
                if (ti_muscle.IsSelected)
                {
                    Console.WriteLine("Muscle");
                    sqlBody = "v_muscle";
                    showCharts(sqlBody);
                }
                if (ti_fat.IsSelected)
                {
                    Console.WriteLine("Fat");
                    sqlBody = "v_fat";
                    showCharts(sqlBody);
                }
                if (ti_vfat.IsSelected)
                {
                    Console.WriteLine("vFat");
                    sqlBody = "v_vfat";
                    showCharts(sqlBody);
                }
                if (ti_calories.IsSelected)
                {
                    Console.WriteLine("Calories");
                    sqlBody = "v_calories";
                    showCharts(sqlBody);
                }
                if (ti_weight.IsSelected)
                {
                    Console.WriteLine("Weight");
                    sqlBody = "v_weight";
                    showCharts(sqlBody);
                }

            }
        }

        private void showCharts(string sqlBody)
        {
            DBstatements db = new DBstatements();

            string clientNr = lbl_clientNr.Content.ToString();

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

                    values[i] = Convert.ToDouble(rdr.GetString(0));
                    i++;
                }

                double[] dataX = new double[] { 1, 2, 3, 4, 5 };
                double[] dataY = new double[] { values[0], values[1], values[2], values[3], values[4] };


                if (ti_arm.IsSelected)
                {
                    Console.WriteLine("Arm");
                    plot_values_arm.Plot.AddScatter(dataX, dataY);
                    plot_values_arm.Render();
                    rdr.Close();
                }
                if (ti_chest.IsSelected)
                {
                    Console.WriteLine("Chest");
                    plot_values_chest.Plot.AddScatter(dataX, dataY);
                    plot_values_chest.Render();
                    rdr.Close();
                }
                if (ti_leg.IsSelected)
                {
                    Console.WriteLine("Leg");
                    plot_values_leg.Plot.AddScatter(dataX, dataY);
                    plot_values_leg.Render();
                    rdr.Close();
                }
                if (ti_calves.IsSelected)
                {
                    Console.WriteLine("Calves");
                    plot_values_calves.Plot.AddScatter(dataX, dataY);
                    plot_values_calves.Render();
                    rdr.Close();
                }
                if (ti_stomach.IsSelected)
                {
                    Console.WriteLine("Stomach");
                    plot_values_stomach.Plot.AddScatter(dataX, dataY);
                    plot_values_stomach.Render();
                    rdr.Close();
                }
                if (ti_hips.IsSelected)
                {
                    Console.WriteLine("Hips");
                    plot_values_hips.Plot.AddScatter(dataX, dataY);
                    plot_values_hips.Render();
                    rdr.Close();
                }
                if (ti_muscle.IsSelected)
                {
                    Console.WriteLine("Muscle");
                    plot_values_muscle.Plot.AddScatter(dataX, dataY);
                    plot_values_muscle.Render();
                    rdr.Close();
                }
                if (ti_fat.IsSelected)
                {
                    Console.WriteLine("Fat");
                    plot_values_fat.Plot.AddScatter(dataX, dataY);
                    plot_values_fat.Render();
                    rdr.Close();
                }
                if (ti_vfat.IsSelected)
                {
                    Console.WriteLine("vFat");
                    plot_values_vfat.Plot.AddScatter(dataX, dataY);
                    plot_values_vfat.Render();
                    rdr.Close();
                }
                if (ti_calories.IsSelected)
                {
                    Console.WriteLine("Calories");
                    plot_values_calories.Plot.AddScatter(dataX, dataY);
                    plot_values_calories.Render();
                    rdr.Close();
                }
                if (ti_weight.IsSelected)
                {
                    Console.WriteLine("Weight");
                    plot_values_weight.Plot.AddScatter(dataX, dataY);
                    plot_values_weight.Render();

                    rdr.Close();
                }

                
                



                plot_values_arm.Refresh();

                //Array.Clear(dataY, 0, dataY.Length);


                rdr.Close();
                db.CloseConnection();
            }
        }
    }
}
