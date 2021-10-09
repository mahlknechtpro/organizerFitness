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
            DBstatements DB = new DBstatements();

            string firstname = txtb_firstname.Text;
            string lastname = txtb_lastname.Text;
            string birth_day = txtb_birthday.Text;
            string birth_month = txtb_birthmonth.Text;
            string birth_year = txtb_birthyear.Text;
            string phone = txtb_phone.Text;
            string email = txtb_email.Text;
            string codfisc = txtb_codfisc.Text;
            string payment = cmb_pay.Text;
            string height = txtb_height.Text;
            string weight = txtb_weight.Text;
            string size = txtb_size.Text;
            string birthdate;
            string notice = txtblo_notice.Text;

            birthdate = birth_year + "-" + birth_month + "-" + birth_day;

            height = height.Replace(',', '.');
            weight = weight.Replace(',', '.');

            DB.InsertNewClient(firstname,lastname,birthdate,phone,email,codfisc,payment,size,height,weight,notice);
            //(string firstname, string lastname, string birthdate, string phone, string email, string codfisc, string payment, string height, string weight)
        }
    }
}
