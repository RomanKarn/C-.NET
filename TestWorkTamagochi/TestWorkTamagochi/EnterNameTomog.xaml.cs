using System.Windows;

namespace TestWorkTamagochi
{
    public partial class EnterNameTomog : Window
    {
        public EnterNameTomog(Window parent)
        {
            InitializeComponent();
            this.DataContext = parent.DataContext;
        }
    }
}
