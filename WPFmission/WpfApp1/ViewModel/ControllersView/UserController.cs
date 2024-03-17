using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfApp1.Model;

namespace WpfApp1.ViewModel.ControllersView
{
    public class UserController : INotifyPropertyChanged
    {
        private User userLogger;
        public User UserLogger
        {
            get { return userLogger; }
            set
            {
                userLogger = value;
                OnPropertyChanged("UserLogger");
                OnPropertyChanged("ThisUserLoggerVisibility");
                OnPropertyChanged("ThisNotUserLoggerVisibility");
            }
        }
        public object ThisUserLoggerVisibility
        {
            get
            {
                BooleanToVisibilityConverter booleanToVisibilityConverter = new BooleanToVisibilityConverter();
                if (UserLogger != null)
                {
                    return booleanToVisibilityConverter.Convert(true, typeof(bool), null, new CultureInfo(1, true));
                }
                return booleanToVisibilityConverter.Convert(false, typeof(bool), null, new CultureInfo(1, true));
            }

        }
        public object ThisNotUserLoggerVisibility
        {
            get
            {
                BooleanToVisibilityConverter booleanToVisibilityConverter = new BooleanToVisibilityConverter();
                if (UserLogger != null)
                    return booleanToVisibilityConverter.Convert(false, typeof(bool), null, new CultureInfo(1, true));
                return booleanToVisibilityConverter.Convert(true, typeof(bool), null, new CultureInfo(1, true));
            }

        }
        public void ExitUser()
        {
            UserLogger = null;
            OnPropertyChanged("ThisUserLoggerVisibility");
            OnPropertyChanged("ThisNotUserLoggerVisibility");
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
