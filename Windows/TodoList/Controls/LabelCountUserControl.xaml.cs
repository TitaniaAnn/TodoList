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
    /// Interaction logic for LabelCountUserControl.xaml
    /// </summary>
    public partial class LabelCountUserControl : UserControl
    {
        public LabelCountUserControl()
        {
            InitializeComponent();
        }

        public object ButtonName
        {
            get { return btnName.Content.ToString(); }
            set
            {
                if (btnName.Content != value)
                {
                    btnName.Content = value;
                }
            }
        }
        public object ButtonCount
        {
            get { return btnCount.Content.ToString(); }
            set
            {
                if (btnCount.Content != value)
                {
                    btnCount.Content = value;
                }
            }
        }
    }
}
