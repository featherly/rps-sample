using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using rpsWindowsPhone.ViewModel.Controls;
using rpsWindowsPhone.Model;

namespace rpsWindowsPhone.Controls
{
    public partial class RpsChooser : UserControl
    {
        public RpsChooserViewModel ViewModelBehind
        {
            get
            {
                if (viewModelBehind == null)
                {
                    viewModelBehind = (RpsChooserViewModel)this.LayoutRoot.DataContext;
                }
                return viewModelBehind;
            }
        }
        private RpsChooserViewModel viewModelBehind;
        
        public RpsEnum RpsChosen
        {
            get { return ViewModelBehind.RpsChosen; }
            set { ViewModelBehind.RpsChosen = value; }
        }

        public RpsChooser()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(RpsChooser_Loaded);
        }

        void RpsChooser_Loaded(object sender, RoutedEventArgs e)
        {
            if (ViewModelBehind != null)
                ViewModelBehind.RpsChanged += new EventHandler(ViewModelBehind_RpsChanged);
        }

        void ViewModelBehind_RpsChanged(object sender, EventArgs e)
        {
            OnRpsChanged(new EventArgs());
        }

        public event EventHandler RpsChanged;
        protected virtual void OnRpsChanged(EventArgs e)
        {
            if (RpsChanged != null)
            {
                RpsChanged(this, e);
            }
        }
    }
}
