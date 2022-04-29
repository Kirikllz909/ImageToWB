using ImageToWB.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ImageToWB.ColorToWBAlgorithms
{
    public static class Coefficients
    {
        public static Bitmap ConvertImage(Bitmap img, ConvertionArgs args = null)
        {
            Bitmap inputImg = new Bitmap(img);
            Bitmap outputImg = new Bitmap(inputImg.Width, inputImg.Height);

            for (int i = 0; i < inputImg.Height; i++)
                for (int j = 0; j < inputImg.Width; j++)
                {
                    UInt32 pixel = (UInt32)(inputImg.GetPixel(j, i).ToArgb());
                    //Color format is 0xAARRGGBB where each symbol is 4 bytes
                    float R = (pixel & 0x00FF0000) >> 16;//Right on 16 bytes
                    float G = (pixel & 0x0000FF00) >> 8;//Right on 8 bytes
                    float B = (pixel & 0x000000FF);

                    //Arithmetic average of R,G,B
                    float color = R * (float)args.R_Coefficient + G * (float)args.G_Coefficient + B * (float)args.B_Coefficient;
                    R = G = B = color;
                    UInt32 newPixelColor = 0xFF000000 | ((UInt32)R << 16) | ((UInt32)G << 8) | ((UInt32)B);

                    outputImg.SetPixel(j, i, Color.FromArgb((int)newPixelColor));
                }
            return outputImg;
        }
    }
}
