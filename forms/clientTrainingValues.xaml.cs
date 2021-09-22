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
    /// Interaktionslogik für clientTrainingValues.xaml
    /// </summary>
    public partial class clientTrainingValues : Window
    {
        public clientTrainingValues(string cellValue)
        {
            InitializeComponent();

            string values = "";

            //Kontrolle wann letzte Mal abgespeichert
            //BSP: Last save: 21.09.2021
            //Werte wieder in die Textbox einfügen

            DBstatements db = new DBstatements();
            db.GetBodyValues(cellValue);

            Console.WriteLine(values);
        }

        private void SaveBody_Click(object sender, RoutedEventArgs e)
        {
            //Werte abspeichern
        }

        private void ReturnBody_Click(object sender, RoutedEventArgs e)
        {
            //Window wird geschlossen
            this.Close();
        }
    }
}
