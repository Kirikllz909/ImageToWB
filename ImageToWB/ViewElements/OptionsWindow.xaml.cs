using ImageToWB.Classes;
using ImageToWB.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ImageToWB.ViewElements
{
    /// <summary>
    /// Логика взаимодействия для OptionsWindow.xaml
    /// </summary>
    public partial class OptionsWindow : Window
    {
        private ConvertionArgs PreviousOptions { get; set; } = null;
        public ConvertionArgs Options { get; set; } = new ConvertionArgs();
        public OptionsWindow(ConvertionArgs args)
        {
            InitializeComponent();
            PreviousOptions = args;
            Options.Level = args.Level;
            Options.R_Coefficient = args.R_Coefficient;
            Options.G_Coefficient = args.G_Coefficient;
            Options.B_Coefficient = args.B_Coefficient;

            textBox1.Text = Convert.ToString(Options.Level);
            textBox2.Text = Convert.ToString(Options.R_Coefficient);
            textBox3.Text = Convert.ToString(Options.G_Coefficient);
            textBox4.Text = Convert.ToString(Options.B_Coefficient);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void ChangeArgsValue(object sender, RoutedEventArgs e)
        {
            try
            {
                double newLevel = Convert.ToDouble(textBox1.Text);
                double newRCoefficient = Convert.ToDouble(textBox2.Text);
                double newGCoefficient = Convert.ToDouble(textBox3.Text);
                double newBCoefficient = Convert.ToDouble(textBox4.Text);

                PreviousOptions.Level = newLevel;
                PreviousOptions.R_Coefficient = newRCoefficient;
                PreviousOptions.G_Coefficient = newGCoefficient;
                PreviousOptions.B_Coefficient = newBCoefficient;
                Close();
            }
            catch (Exception ex)
            {
                DialogsService.ShowMessage(ex.Message);
            }
        }
    }
}
