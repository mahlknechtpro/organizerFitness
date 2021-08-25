using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using organizerFitness.forms;

namespace organizerFitness.Views
{
    /// <summary>
    /// Interaktionslogik für ClientView.xaml
    /// </summary>
    public partial class ClientView : UserControl
    {
        DBstatements DB = new DBstatements();

        public ClientView()
        {
            InitializeComponent();

            fillDataGrid();
        }

        public void NewClient_Click(object sender, RoutedEventArgs e)
        {
            forms.NewClient newClientScreen = new forms.NewClient();
            newClientScreen.Show();
        }

        private void InsertValues_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ChangeData_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteClient_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchData_Click(object sender, RoutedEventArgs e)
        {
            //Initialize variable
            string searchValue = txtb_search.Text;

            //Open Database
            DB.OpenConnection();

            string MyConString =
                "SERVER=mimasrv2.ddns.net;" +
                "DATABASE=db_organizerFitness;" +
                "UID=mima;" +
                "PASSWORD=mima_10492;" +
                "SslMode=none;";

            string cmdString;
            cmdString = "SELECT cid AS Nummer, c_lastname AS Nachname, c_name AS Vorname, DATE_FORMAT(c_birth, '%d-%m-%Y') AS Geburtstag, c_height AS Gewicht," +
                " c_startweight AS Startgewicht, c_codfisc AS Steuernr, c_pay AS Bezahlung, c_phone AS Handynr, c_email AS Mail FROM t_clients " +
                "WHERE cid like '%" + searchValue + "%' || c_lastname like '%" + searchValue + "%' || c_name like '%" + searchValue + "%' || c_birth like '%" + searchValue + "%' || c_height like '%" + searchValue + "%'" +
                " || c_startweight like '%" + searchValue + "%' || c_codfisc like '%" + searchValue + "%' || c_pay like '%" + searchValue + "%' || c_phone like '%" + searchValue + "%' || c_email like '%" + searchValue + "%'";

            Console.WriteLine("cmdString: " + cmdString);

            MySqlConnection connection = new MySqlConnection(MyConString);
            MySqlCommand cmdSel = new MySqlCommand(cmdString, connection);
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmdSel);
            da.Fill(dt);
            grdClients.DataContext = dt;


            //Close Database
            DB.CloseConnection();
        }

        private void ReloadData_Click(object sender, RoutedEventArgs e)
        {
            fillDataGrid();

            if (txtb_search.Text != "")
            {
                txtb_search.Text = "";
            }
        }

        private void fillDataGrid()
        {
            //Open Database
            DB.OpenConnection();

            string MyConString =
                "SERVER=mimasrv2.ddns.net;" +
                "DATABASE=db_organizerFitness;" +
                "UID=mima;" +
                "PASSWORD=mima_10492;" +
                "SslMode=none;";

            string cmdString;
            cmdString = "SELECT cid AS Nummer, c_lastname AS Nachname, c_name AS Vorname, DATE_FORMAT(c_birth, '%d-%m-%Y') AS Geburtstag, c_height AS Gewicht," +
                " c_startweight AS Startgewicht, c_codfisc AS Steuernr, c_pay AS Bezahlung, c_phone AS Handynr, c_email AS Mail FROM t_clients";

            MySqlConnection connection = new MySqlConnection(MyConString);
            MySqlCommand cmdSel = new MySqlCommand(cmdString, connection);
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmdSel);
            da.Fill(dt);
            grdClients.DataContext = dt;


            //Close Database
            DB.CloseConnection();
        }

        private void NewContract_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
