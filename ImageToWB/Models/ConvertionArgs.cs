using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ImageToWB.Models
{
    public class ConvertionArgs : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
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

        private double _level = 150;
        public double Level { 
            get
            {
                return _level;
            }
            set
            {
                SetField(ref _level, value, "Level");
            } 
        }

        private double _R_Coefficient = 0.2989;
        private double _G_Coefficient = 0.5870;
        private double _B_Coefficient = 0.1140;

        public double R_Coefficient
        {
            get
            {
                return _R_Coefficient;
            }
            set
            {
                SetField(ref _R_Coefficient, value, "R_Coefficient");
            }
        }
        public double G_Coefficient
        {
            get
            {
                return _G_Coefficient;
            }
            set
            {
                SetField(ref _G_Coefficient, value, "G_Coefficient");
            }
        }
        public double B_Coefficient
        {
            get
            {
                return _B_Coefficient;
            }
            set
            {
                SetField(ref _B_Coefficient, value, "B_Coefficient");
            }
        }
        public ConvertionArgs()
        {
        }
    }
}
