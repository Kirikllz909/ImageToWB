using System;
using System.Collections.Generic;
using System.Text;

namespace ImageToWB.Classes
{
    public enum OpenDialogResult
    {
        OK,
        ERROR
    }
    public class OpenFileDialogResult
    {
        public OpenDialogResult Result { get; set; }
        public string Path { get; set; }
        public OpenFileDialogResult(OpenDialogResult result, string path = null)
        {
            Result = result;
            Path = path;
        }
    }
}
