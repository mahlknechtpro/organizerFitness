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
            string datum;
            string conLength;
            int length = 0;

            conLength = cmb_lengthcontract.SelectedItem.ToString().Remove(0,38);
            Console.WriteLine("conlength= " + conLength);
            switch (conLength)
            {
                case "1 month":
                    length = 1;
                    break;

                case "3 months":
                    length = 3;
                    break;

                case "6 months":
                    length = 6;
                    break;

                case "12 months":
                    length = 12;
                    break;
            }

            datum = cal_beginContract.SelectedDate.Value.Date.ToShortDateString();
            Console.WriteLine("datum : " + datum);
            Console.WriteLine("Monate : " + length);
            
            
        }

        private void btn_closeContract(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
