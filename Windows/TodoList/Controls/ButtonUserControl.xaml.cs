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
    /// Interaction logic for ButtonUserControl.xaml
    /// </summary>
    public partial class ButtonUserControl : UserControl
    {
        public event RoutedEventHandler Click;

        public static readonly DependencyProperty LabelProperty = DependencyProperty.Register("ButtonLabel", typeof(string), typeof(ButtonUserControl), new PropertyMetadata(""));

        public static readonly DependencyProperty CountProperty = DependencyProperty.Register("ButtonCount", typeof(string), typeof(ButtonUserControl), new PropertyMetadata(""));

        public ButtonUserControl()
        {
            InitializeComponent();

            LayoutRoot.DataContext = this;
        }

        public string ButtonLabel
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        public string ButtonCount
        {
            get { return (string)GetValue(CountProperty); }
            set { SetValue(CountProperty, value); }
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
