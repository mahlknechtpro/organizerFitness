using organizerFitness.Models;
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
            ClientValues cValues = db.GetBodyValues(cellValue);
            if (cValues == null)
            {
                
            }

            lbl_lastSave.Content = "Last save: " + cValues.v_date.ToString("dd/MM/yyyy");


            Console.WriteLine(cValues.v_date.ToString("dd/MM/yyyy"));
            
        }

        private void SaveBody_Click(object sender, RoutedEventArgs e)
        {
            //Werte abspeichern

            DBstatements db = new DBstatements();

            //Variables inizialize
            string v_arm;
            string v_chest;
            string v_upperlegs;
            string v_calves;
            string v_stomach;
            string v_hips;
            string v_muscles;
            string v_fat;
            string v_vfat;
            string v_calories;
            string v_weight;

            //Data to variables
            v_arm = txtb_arm.Text;
            v_chest = txtb_chest.Text;
            v_upperlegs = txtb_upperlegs.Text;
            v_calves = txtb_lowerlegs.Text;
            v_stomach = txtb_stomach.Text;
            v_hips = txtb_hips.Text;
            v_muscles = txtb_muscles.Text;
            v_fat = txtb_fat.Text;
            v_vfat = txtb_vfat.Text;
            v_calories = txtb_calories.Text;
            v_weight = txtb_weight.Text;

            db.saveClientValues(v_arm, v_chest, v_upperlegs, v_calves, v_stomach, v_hips, v_muscles,
                v_fat, v_vfat, v_calories, v_weight);
        }

        private void ReturnBody_Click(object sender, RoutedEventArgs e)
        {
            //Window wird geschlossen
            this.Close();
        }

        private void clearValue_Click(object sender, RoutedEventArgs e)
        {
            txtb_arm.Text = "";
            txtb_calories.Text = "";
            txtb_chest.Text = "";
            txtb_fat.Text = "";
            txtb_hips.Text = "";
            txtb_lowerlegs.Text = "";
            txtb_lowerlegs.Text = "";
            txtb_muscles.Text = "";
            txtb_stomach.Text = "";
            txtb_upperlegs.Text = "";
            txtb_weight.Text = "";
            txtb_vfat.Text = "";
        }
    }
}
