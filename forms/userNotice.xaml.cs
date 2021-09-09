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
    /// Interaktionslogik für userNotice.xaml
    /// </summary>
    public partial class userNotice : Window
    {

        public userNotice(string noticeClient, string clientNumber)
        {
            InitializeComponent();

            lbl_nr.Content = clientNumber;

            rtb_notice.Document.Blocks.Add(new Paragraph(new Run(noticeClient)));
        }

        private void btn_notice_close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_notice_save(object sender, RoutedEventArgs e)
        {
            string rtb_noticeClient = new TextRange(rtb_notice.Document.ContentStart, rtb_notice.Document.ContentEnd).Text;


            DBstatements DB = new DBstatements();
            DB.setNotice(rtb_noticeClient, lbl_nr.Content.ToString());
        }
    }
}
