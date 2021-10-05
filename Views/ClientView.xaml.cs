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

            //SELECT - STATEMENT executed and showed in the datagrid
            fillDataGridAllClients();
        }

        #region NewClient_context
        public void NewClient_Click(object sender, RoutedEventArgs e)
        {
            //Windows for new client will be opened
            forms.NewClient newClientScreen = new forms.NewClient();
            newClientScreen.Show();
        }
        #endregion

        #region InsertValues_context
        private void InsertValues_Click(object sender, RoutedEventArgs e)
        {
            //Get Index (ClientNr)
            DataRowView dataRow = (DataRowView)grdClients.SelectedItem;
            string cellValue = dataRow.Row.ItemArray[0].ToString();

            forms.clientTrainingValues newContractWindow = new forms.clientTrainingValues(cellValue);
            newContractWindow.Show();
        }
        #endregion

        #region ClientDataChange_Context
        private void ChangeData_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region DeleteClient_context
        private void DeleteClient_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        private void SearchData_Click(object sender, RoutedEventArgs e)
        {
            searchData();
        }

        #region Reload_Button
        private void ReloadData_Click(object sender, RoutedEventArgs e)
        {
            fillDataGridAllClients();

            if (txtb_search.Text != "")
            {
                txtb_search.Text = "";
            }
        }
        #endregion

        private void fillDataGrid()
        {
            //Open Database
            DB.OpenConnection();

            string MyConString =
                "SERVER=159.69.105.146;" +
                "DATABASE=db_organizerFitness;" +
                "PORT=3331;" +
                "UID=root;" +
                "PASSWORD=Mmn339FpS#E2f99!et;" +
                "SslMode=none;";

            string cmdString;
            cmdString = ( "SELECT  tcl.cid AS Nummer"
                        + "     ,  tcl.c_lastname AS Nachname"
                        + "     ,  tcl.c_name AS Vorname"
                        + "     ,  DATE_FORMAT(tcl.c_birth, '%d-%m-%Y') AS Geburtstag"
                        + "     ,  tcl.c_height AS Gewicht"
                        + "     ,  tcl.c_startweight AS Startgewicht"
                        + "     ,  tcl.c_codfisc AS Steuernr"
                        + "     ,  tcl.c_pay AS Bezahlung"
                        + "     ,  tcl.c_phone AS Handynr"
                        + "     ,  tcl.c_email AS Mail"
                        + "     ,  tco.co_active AS Aktiv"
                        + "     ,  DATE_FORMAT(tco.co_begin, '%d-%m-%Y') AS Beginn"
                        + "     ,  tco.co_duration AS Dauer"
                        + "     ,  DATE_FORMAT(tco.co_end, '%d-%m-%Y') AS Ende"
                        + "     ,  tco.co_paid AS Bezahlt"
                        + "  FROM t_clients AS tcl"
                        + " INNER"
                        + "  JOIN t_contracts    AS tco"
                        + "    ON tcl.cid = tco.co_number"
                        + " WHERE tco.co_active = 1"
                        + ";"
            );

            MySqlConnection connection = new MySqlConnection(MyConString);
            MySqlCommand cmdSel = new MySqlCommand(cmdString, connection);
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmdSel);
            da.Fill(dt);
            grdClients.DataContext = dt;


            //Close Database
            DB.CloseConnection();
        }

        private void fillDataGridAllClients()
        {
            //Open Database
            DB.OpenConnection();

            string MyConString =
                "SERVER=159.69.105.146;" +
                "DATABASE=db_organizerFitness;" +
                "PORT=3331;" +
                "UID=root;" +
                "PASSWORD=Mmn339FpS#E2f99!et;" +
                "SslMode=none;";

            string cmdString;
            cmdString = ( "SELECT  tcl.cid AS Nummer"
                        + "     ,  tcl.c_lastname AS Nachname"
                        + "     ,  tcl.c_name AS Vorname"
                        + "     ,  DATE_FORMAT(tcl.c_birth, '%d-%m-%Y') AS Geburtstag"
                        + "     ,  tcl.c_height AS Gewicht"
                        + "     ,  tcl.c_startweight AS Startgewicht"
                        + "     ,  tcl.c_codfisc AS Steuernr"
                        + "     ,  tcl.c_pay AS Bezahlung"
                        + "     ,  tcl.c_phone AS Handynr"
                        + "     ,  tcl.c_email AS Mail"
                        + "  FROM t_clients AS tcl"
                        + ";"
            );

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
            //Get Index (ClientNr)
            DataRowView dataRow = (DataRowView)grdClients.SelectedItem;
            string cellValue = dataRow.Row.ItemArray[0].ToString();


            forms.newContract newContractWindow = new forms.newContract(cellValue);
            newContractWindow.Show();
            
        }

        private void ClientSearch_KeyDown(object sender, KeyEventArgs e)
        {
            searchData();
        }

        private void ClientSearch_KeyUp(object sender, KeyEventArgs e)
        {
            searchData();
        }

        private void searchData()
        {
            //Initialize variable
            string searchValue = txtb_search.Text;

            //Open Database
            DB.OpenConnection();

            string MyConString =
                "SERVER=159.69.105.146;" +
                "DATABASE=db_organizerFitness;" +
                "PORT=3331;" +
                "UID=root;" +
                "PASSWORD=Mmn339FpS#E2f99!et;" +
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

        private void ClientContract_Click(object sender, RoutedEventArgs e)
        {
            if(chb_withContract.IsChecked == true)
            {
                fillDataGrid();
                //MessageBox.Show("Checked");
            }
            else
            {
                fillDataGridAllClients();
                //MessageBox.Show("Unchecked");
            }
        }

        private void GetNotice_Click(object sender, RoutedEventArgs e)
        {
            string notice = "";

            //Get Index (ClientNr)
            DataRowView dataRow = (DataRowView)grdClients.SelectedItem;
            string cellValue = dataRow.Row.ItemArray[0].ToString();

            DB.getNotice(cellValue, notice);
        }
    }
}
