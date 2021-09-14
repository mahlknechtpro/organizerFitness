using organizerFitness.Viewmodels;
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
using System.Windows.Threading;
using Tulpep.NotificationWindow;

namespace organizerFitness.forms
{
    /// <summary>
    /// Interaktionslogik für mainScreen.xaml
    /// </summary>
    public partial class mainScreen : Window
    {

        private static mainScreen app;
        public static mainScreen App
        {
            get { return app; }
            set { app = value; }
        }
        public mainScreen()
        {
            InitializeComponent();

            startclock();

            //Makes the MainWindow object public so that it and its public methods are visible in the whole project.
            mainScreen.App = this;

            SwitchPage(new MainViewModel());

            //Check Contracts
            DBstatements db = new DBstatements();
            db.getFinishContract();

            //Pop-Up
            PopupNotifier popupContract = new PopupNotifier();
            popupContract.Image = Properties.Resources.mail;
            popupContract.TitleText = "Vertrag bald zu Ende";
            popupContract.ContentText = "Bei diesen Kunden wird der Vertrag auslaufen";
            popupContract.Popup();

            //Mail
        }
        private void startclock()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += tickevent;
            timer.Start();

        }

        private void tickevent(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            main_time.Content = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            //Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
        }


        public void SwitchPage(Object page)
        {
            DataContext = page;
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            var Result = MessageBox.Show("Do you wanna quit?", "Exit", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (Result == MessageBoxResult.Yes)
            {
                System.Windows.Application.Current.Shutdown();
            }
            else if (Result == MessageBoxResult.No)
            {
                //Window remain open
            }
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            SwitchPage(new MainViewModel());
        }

        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ButtonClients_Click(object sender, RoutedEventArgs e)
        {
            SwitchPage(new ClientViewModel());
        }

        private void ButtonSettings_Click(object sender, RoutedEventArgs e)
        {
            SwitchPage(new SettingsViewModel());
        }
    }
}
