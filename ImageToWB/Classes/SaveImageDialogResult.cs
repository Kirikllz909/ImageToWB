using System;
using System.Collections.Generic;
using System.Text;

namespace ImageToWB.Classes
{
    public enum ImageDialogResult
    {
        OK,
        ERROR
    }
    public class SaveImageDialogResult
    {
        public ImageDialogResult Result { get; set; }
        public string Format { get; set; }
        public string Path { get; set; }
        public SaveImageDialogResult(ImageDialogResult result, string format = null, string path = null)
        {
            Result = result;
            Format = format;
            Path = path;
        }
    }
}
