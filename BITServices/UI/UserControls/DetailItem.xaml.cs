using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BITServices.Control;

namespace BITServices.UI.UserControls
{
    /// <summary>
    /// Interaction logic for DetailItem.xaml
    /// </summary>
    public partial class DetailItem : UserControl
    {
        public DetailItem()
        {
            InitializeComponent();
            LayoutRoot.DataContext = this; //Allows for data to be bound from outside usercontrol
        }

        public string DetailLabel
        {
            get { return (string)GetValue(DetailLabelProperty); }
            set { SetValue(DetailLabelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DetailLabel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DetailLabelProperty =
            DependencyProperty.Register("DetailLabel", typeof(string), typeof(DetailItem), new PropertyMetadata(string.Empty));


        public string DetailValue
        {
            get { return (string)GetValue(DetailValueProperty); }
            set { SetValue(DetailValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DetailValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DetailValueProperty =
            DependencyProperty.Register("DetailValue", typeof(string), typeof(DetailItem), new PropertyMetadata(string.Empty));


        public Commander ValueChangedCommand
        {
            get { return (Commander)GetValue(ValueChangedCommandProperty); }
            set { SetValue(ValueChangedCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DetailValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueChangedCommandProperty =
            DependencyProperty.Register("ValueChangedCommand", typeof(Commander), typeof(DetailItem), new PropertyMetadata(null));

    }
}
