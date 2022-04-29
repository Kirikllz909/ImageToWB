using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageToWB.Classes
{
    public static class SaveImage
    {
        /// <summary>
        /// Select ImageFormat by provided string format. If such formats do not exist throws an exception
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private static ImageFormat SelectFileFormat(string format)
        {
            switch(format)
            {
                case ".jpg":
                    return ImageFormat.Jpeg;
                case ".bmp":
                    return ImageFormat.Bmp;
                case ".png":
                    return ImageFormat.Png;
                case ".tiff":
                    return ImageFormat.Tiff;
                case ".gif":
                    return ImageFormat.Gif;
                case ".icon":
                    return ImageFormat.Icon;
                default:
                    throw new Exception("Wrong input format");
            }
        }
        /// <summary>
        /// Save image to directory
        /// </summary>
        /// <param name="img"></param>
        /// <param name="path"></param>
        /// <param name="format"></param>
        public static void SaveImageToFile(Image img, string path, string format)
        {
            ImageFormat selectedFormat = SelectFileFormat(format);
            img.Save(path, selectedFormat);
        }
    }
}
