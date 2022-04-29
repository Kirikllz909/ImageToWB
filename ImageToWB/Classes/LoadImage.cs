using System.IO;
using System.Drawing;

namespace ImageToWB.Classes
{
    public static class LoadImage
    {
        /// <summary>
        /// Load image from provided path
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>Loaded image</returns>
        public static Bitmap LoadImageFromFile(string filePath)
        {
            byte[] bytes = File.ReadAllBytes(filePath);
            MemoryStream ms = new MemoryStream(bytes);
            Image img = Image.FromStream(ms);
            return (Bitmap) img;
        }
    }
}
