using System.Windows;
using System.Windows.Controls;
using WpfApp1.ViewModel;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new ApplicationViewModel();
            
        }
        private void ScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            var scrollViewer = (ScrollViewer)sender;
            if (scrollViewer.VerticalOffset == scrollViewer.ScrollableHeight)
            {
                if(DataContext is ApplicationViewModel vieModel)
                {
                    vieModel.ElementMissionControllerVuew.LodingElementMissionList.Execute(null);
                }
            }    
        }
    }
}
