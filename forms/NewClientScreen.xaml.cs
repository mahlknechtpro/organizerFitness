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
    /// Interaktionslogik für NewClient.xaml
    /// </summary>
    public partial class NewClient : Window
    {
        public NewClient()
        {
            InitializeComponent();
        }

        private void btn_newClient_close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_newClient_save(object sender, RoutedEventArgs e)
        {

        }

        #region GotFocus
        private void gf_year(object sender, RoutedEventArgs e)
        {
            if(txtb_birthyear.Text == "")
            {
                txtb_birthyear.Text = "1900";
            }
        }
        #endregion
    }
}
