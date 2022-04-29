using ImageToWB.Classes;
using ImageToWB.ColorToWBAlgorithms;
using ImageToWB.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
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
    /// Логика взаимодействия для WorkingWindow.xaml
    /// </summary>
    public partial class WorkingWindow : Window
    {
        //property which have all WB algorithms
        private ObservableCollection<Algorithm> Algorithms { get; set; } = new ObservableCollection<Algorithm>();
       
        
        //property with all tabs
        private ObservableCollection<TabInformation> AppTabs { get; set; } = new ObservableCollection<TabInformation>();


        private ConvertionArgs ConvertArgs { get; set; } = new ConvertionArgs();
        private OptionsWindow OptionsWindowInstanse = null;

        //After creating method add it to the collection
        private void LoadWbAlgorithms()
        {
            Algorithms.Add(new Algorithm("ArithmeticAverage", ArithmeticAverage.ConvertImage));
            Algorithms.Add(new Algorithm("OnlyBWConvertion", OnlyBWConvertion.ConvertImage));
            Algorithms.Add(new Algorithm("Coefficients", Coefficients.ConvertImage));
        }
        

        public WorkingWindow()
        {
            InitializeComponent();
            LoadWbAlgorithms();
            WbAlg.ItemsSource = Algorithms;
            images.ItemsSource = AppTabs;
        }

        //By clicking on text MouseMiddle close tab
        private void CloseTabMiddle(object sender, RoutedEventArgs e)
        {
            var mouseEvent = (MouseButtonEventArgs)e;
            if (mouseEvent.MiddleButton == MouseButtonState.Pressed)
            {
                TabInformation item = null;
                //Get DataContext from sender, convert it to TabInformation and remove from list
                if (sender is TextBlock)
                    item = (TabInformation)(sender as TextBlock).DataContext;
                else if (sender is StackPanel)
                    item = (TabInformation)(sender as StackPanel).DataContext;
                if(item != null)
                    AppTabs.Remove(item);
            }
        }

        //By clicking on X button
        private void CloseTab(object sender, RoutedEventArgs e)
        {
            //Get DataContext from sender, convert it to TabInformation and remove from list
            var item = sender as TextBlock;
            AppTabs.Remove((TabInformation)item.DataContext);
        }

        //Close WorkingWindow
        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
            if(OptionsWindowInstanse!=null)
                OptionsWindowInstanse.Close();

        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialogResult dialogResult = DialogsService.OpenFileDialog();
            if(dialogResult.Result == OpenDialogResult.OK)
            {
                string fileName = dialogResult.Path.Split("\\").Last();
                AppTabs.Add(new TabInformation(fileName, LoadImage.LoadImageFromFile(dialogResult.Path)));
                images.SelectedIndex = AppTabs.Count - 1;
                AppTabs[images.SelectedIndex].DefaultBitmapImage = BitmapConversion.ToWpfBitmap(AppTabs[images.SelectedIndex].DefaultImage);
            }
        }

        private void SaveWBImage_Click(object sender, RoutedEventArgs e)
        {
            if(AppTabs.Count < 1 || AppTabs[images.SelectedIndex].WBImage==null)
            {
                DialogsService.ShowMessage("There isn't any generated WB image. Try again after generating image");
                return;
            }

            SaveImageDialogResult dialogResult = DialogsService.SaveFileDialog();
            if (dialogResult.Result == ImageDialogResult.OK)
            {
                SaveImage.SaveImageToFile(AppTabs[images.SelectedIndex].WBImage, dialogResult.Path, dialogResult.Format);
            }
        }

        private void ConvertToWB_Click(object sender, RoutedEventArgs e)
        {
            Algorithm selectedAlg = (Algorithm)WbAlg.SelectedItem;
            if (selectedAlg == null)
            {
                DialogsService.ShowMessage("There isn't any algorithm for WB convertion");
                return;
            }
            if (AppTabs[images.SelectedIndex].DefaultImage == null)
            {
                DialogsService.ShowMessage("There isn't any image, try again after generating it");
                return;
            }
            Bitmap result = selectedAlg.Method?.Invoke(AppTabs[images.SelectedIndex].DefaultImage, ConvertArgs);

            if (AppTabs[images.SelectedIndex].WBImage == null)
            {
                AppTabs[images.SelectedIndex].WBImage = new Bitmap(result);
            }
            else AppTabs[images.SelectedIndex].WBImage = result;
            AppTabs[images.SelectedIndex].WBBitmapImage = BitmapConversion.ToWpfBitmap(AppTabs[images.SelectedIndex].WBImage);
        }
        private void OpenOptionsWindow(object sender, RoutedEventArgs e)
        {
            OptionsWindowInstanse = new OptionsWindow(ConvertArgs);
            OptionsWindowInstanse.Show();
        }
    }
}
