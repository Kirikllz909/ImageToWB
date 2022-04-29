using ImageToWB.Models;
using System.Drawing;

namespace ImageToWB.ColorToWBAlgorithms
{
    public static class OnlyBWConvertion
    {
        /// <summary>
        /// Convert provided image to black and white picture
        /// </summary>
        /// <param name="img"></param>
        /// <returns>Converted image</returns>
        public static Bitmap ConvertImage(Bitmap img, ConvertionArgs args)
        {
            Bitmap inputImg = new Bitmap(img);
            Bitmap outputImg = new Bitmap(inputImg.Width, inputImg.Height);

            for (int i = 0; i < inputImg.Height; i++)
                for (int j = 0; j < inputImg.Width; j++)
                {
                    uint pixel = (uint)(inputImg.GetPixel(j, i).ToArgb());                    
                    //Color format is 0xAARRGGBB where each symbol is 4 bytes
                    float R = (pixel & 0x00FF0000) >> 16;//Right on 16 bytes
                    float G = (pixel & 0x0000FF00) >> 8;//Right on 8 bytes
                    float B = (pixel & 0x000000FF);
                    bool isWhite = R > args.Level && G> args.Level && B > args.Level;
                    
                    outputImg.SetPixel(j, i, isWhite? Color.White:Color.Black);
                }
            return outputImg;
        }
    }
}
