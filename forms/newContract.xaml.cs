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
            DBstatements db = new DBstatements();

            string datum;
            string clientNr;
            string conLength;
            int length = 0;
            string year;
            int yearEnd;
            string month;
            int monthEnd;
            string day;
            int dayEnd;
            string conStart;
            string conEnd;
            string paid;

            clientNr = txtb_clientnr.Text;
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

            year = datum.Substring(6, 4);
            month = datum.Substring(3, 2);
            day = datum.Substring(0, 2);

            conStart = year + "-" + month + "-" + day;

            yearEnd = Int32.Parse(year);
            monthEnd = Int32.Parse(month);
            dayEnd = Int32.Parse(day);

            var dat = new DateTime(yearEnd, monthEnd, dayEnd);
            Console.WriteLine(dat.AddMonths(length).ToString("d"));

            year = dat.AddMonths(length).ToString("d").Substring(6, 4);
            month = dat.AddMonths(length).ToString("d").Substring(3, 2);
            day = dat.AddMonths(length).ToString("d").Substring(0, 2);

            conEnd = year + "-" + month + "-" + day;

            //Auslesen ob der Kunde bezahlt hat oder nicht
            if (cb_paid.IsChecked == true)
                paid = "Yes";

            else
                paid = "No";



            Console.WriteLine("conStart: " + conStart + " Länge: " + length);
            Console.WriteLine("conEnd: " + conEnd);



            db.InsertNewContract(clientNr, conStart, conEnd, length, paid);

            
            this.Close();

        }

        private void btn_closeContract(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
