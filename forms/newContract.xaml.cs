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
    /// Interaktionslogik für newContract.xaml
    /// </summary>
    public partial class newContract : Window
    {
        public newContract()
        {
            InitializeComponent();
        }

        private void btn_saveContract(object sender, RoutedEventArgs e)
        {
            string conLength = cmb_lengthcontract.SelectedItem.ToString();
            string datum = cal_beginContract.SelectedDate.Value.Date.ToShortDateString();
            Console.WriteLine("Contract length: " + conLength);
            Console.WriteLine("datum : " + datum);

            if (conLength != "")
            {
                
            }
            else if (conLength == "")
            {
                MessageBox.Show("Please, insert the length of the contract!");
            }
        }

        private void btn_closeContract(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
