using System;
using System.Windows;
using TestWorkTamagochi.View;

namespace TestWorkTamagochi
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new ApplicationViewModel();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is ApplicationViewModel vieModel)
            {
                vieModel.ShowWindowEnterNamePlaer();
            }
            
        }
    }
}
