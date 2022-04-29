using Microsoft.Win32;
using System.IO;
using System.Windows;

namespace ImageToWB.Classes
{
    public static class DialogsService
    {
        /// <summary>
        /// Show dialog for selecting picture
        /// </summary>
        /// <returns></returns>

        public static OpenFileDialogResult OpenFileDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "JPG|*jpg|PNG|*png|TIFF|*tiff|BMP|*bmp";

            if (openFileDialog.ShowDialog() == true)
            {
                return new OpenFileDialogResult(OpenDialogResult.OK, openFileDialog.FileName);
            }

            return new OpenFileDialogResult(OpenDialogResult.ERROR);
        }
        /// <summary>
        /// Open dialog for saving processed picture
        /// </summary>
        /// <returns></returns>
        public static SaveImageDialogResult SaveFileDialog()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Bitmap files(*.bmp)| *.bmp| JPG files(*.jpg)| *.jpg| GIF files(*.gif)|" +
                " *.gif| PNG files(*.png)| *.png| TIFF files(*.tiff)| *.tiff| Icons(*.icon)| *.icon";
            saveFileDialog.FilterIndex = 2;

            if (saveFileDialog.ShowDialog() == true)
            {
                string fileFormat = Path.GetExtension(saveFileDialog.FileName).ToLower();
                string SavePath = saveFileDialog.FileName;
                return new SaveImageDialogResult(ImageDialogResult.OK,fileFormat,SavePath);
            }

            return new SaveImageDialogResult(ImageDialogResult.ERROR);
        }

        /// <summary>
        /// Show MessageBox with received message
        /// </summary>
        /// <param name="message"></param>
        public static void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
