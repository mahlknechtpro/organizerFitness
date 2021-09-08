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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace organizerFitness
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string username;
        string pwd;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_login(object sender, RoutedEventArgs e)
        {
            DBstatements DB = new DBstatements();

            //Initialize Username + Password
            username = txtb_username.Text;
            pwd = txtb_pwd.Password;
            Console.WriteLine("Username: " + username);
            Console.WriteLine("Password: " + pwd);

            //Start function USERCONNECTION
            DB.UserConnection(username, pwd);

            forms.mainScreen mainScreen = new forms.mainScreen();
            mainScreen.Show();

            //Opened windows get closed
            this.Close();

        }
    }
}
