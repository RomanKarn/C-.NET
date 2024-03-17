using System.Windows;

namespace WpfApp1.Windows
{
    public partial class UserRegistrated : Window
    {
        public UserRegistrated(Window parent)
        {
            InitializeComponent();
            this.Owner = parent;
            this.DataContext = parent.DataContext;
        }
    }
}
