using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Media.Imaging;

namespace ImageToWB.Models
{
    public class TabInformation : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //Process changing property
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        //Updating Field
        protected bool SetField<T>(ref T field, T value, string propertyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        //Name of tab
        private string _header;
        public string Header
        {
            get 
            { 
                return _header; 
            }
            set
            {
                SetField(ref _header, value, "Header");
            }
        }

        //Image loaded from file
        private Bitmap _defaultImage;
        public Bitmap DefaultImage
        {
            get
            {
                return _defaultImage;
            }
            set
            {
                SetField(ref _defaultImage, value, "DefaultImage");
            }
        }
        
        private BitmapImage _defaultBitmapImage;
        public BitmapImage DefaultBitmapImage
        {
            get
            {
                return _defaultBitmapImage;
            }
            set
            {
                SetField(ref _defaultBitmapImage, value, "DefaultBitmapImage");
            }
        }

        //WB image
        private Bitmap _wbImage;
        public Bitmap WBImage
        {
            get
            {
                return _wbImage;
            }
            set
            {
                SetField(ref _wbImage, value, "WBImage");
            }
        }

        private BitmapImage _wbBitmapImage;
        public BitmapImage WBBitmapImage
        {
            get
            {
                return _wbBitmapImage;
            }
            set
            {
                SetField(ref _wbBitmapImage, value, "WBBitmapImage");
            }
        }

        public TabInformation(string Header, Bitmap defaultImage)
        {
            this.Header = Header;
            this.DefaultImage = defaultImage;
        }
    }
}
