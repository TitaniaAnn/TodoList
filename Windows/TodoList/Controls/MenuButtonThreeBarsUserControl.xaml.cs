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

namespace TodoList.Controls
{
    /// <summary>
    /// Interaction logic for MenuButtonThreeBarsUserControl.xaml
    /// </summary>
    public partial class MenuButtonThreeBarsUserControl : UserControl
    {
        public event RoutedEventHandler Click;

        public MenuButtonThreeBarsUserControl()
        {
            InitializeComponent();
        }

        public double Width
        {
            get { return MenuButtonThreeBars.Width; }
            set
            {
                if (MenuButtonThreeBars.Width != value)
                {
                    MenuButtonThreeBars.Width = value;
                }
            }
        }

        public double Height
        {
            get { return MenuButtonThreeBars.Height; }
            set
            {
                if (MenuButtonThreeBars.Height != value)
                {
                    MenuButtonThreeBars.Height = value;
                }
            }
        }

        public Color LineColor
        {
            get { return ((SolidColorBrush)Resources["BrushLineColor"]).Color; }
            set
            {
                if (((SolidColorBrush)Resources["BrushLineColor"]).Color != value)
                {
                    ((SolidColorBrush)Resources["BrushLineColor"]).Color = value;
                }
            }
        }

        void onButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.Click != null)
            {
                this.Click(this, e);
            }
        }

    }
}
