using System.Windows;

namespace WpfApp1.Windows
{

    public partial class UserEnter : Window
    {
        public UserEnter(Window parent)
        {
            InitializeComponent();
            this.Owner = parent;
            this.DataContext = parent.DataContext;
        }
    }
}
