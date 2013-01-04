using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace rpsWindowsPhone.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Determines whether or not application is running in Design time (VS designer, Blend).
        /// This is useful to avoid exceptions that occur in Design views.
        /// </summary>
        public bool IsDesignTime
        {
            get
            {
                return DesignerProperties.IsInDesignTool;
            }
        }
    }
}