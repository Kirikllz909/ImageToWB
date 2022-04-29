using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace ImageToWB.Models
{
    public delegate Bitmap ImgConvertion(Bitmap img, ConvertionArgs args = null);
    public class Algorithm : INotifyPropertyChanged
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

        private string _name;
        private ImgConvertion _method;
        public string Name { get => _name; set => SetField(ref _name, value, "Name"); }
        public ImgConvertion Method { get => _method; set => SetField(ref _method, value, "Method"); }
        public Algorithm(string name, ImgConvertion method)
        {
            Name = name;
            Method = method;
        }
    }
}
