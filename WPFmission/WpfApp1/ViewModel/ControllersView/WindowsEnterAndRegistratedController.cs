using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Model;
using WpfApp1.Model.DBMameger;
using WpfApp1.Windows;

namespace WpfApp1.ViewModel.ControllersView
{
    public class WindowsEnterAndRegistratedController
    {
        private DBController dbController;
        private UserEnter userEnterWindow;
        private UserRegistrated userRegistratedWindow;
        private User userTrayConnect = new User();

        private RelayCommand openWindowEnterUserCommand;
        private RelayCommand openWindowRegistratedUserCommand;

        public WindowsEnterAndRegistratedController(DBController dbController)
        {
            this.dbController = dbController;
        }
        public User UserTrayConnect
        {
            get
            {
                return userTrayConnect;
            }
            set
            {
                userTrayConnect = value;
            }
        }
        public RelayCommand OpenWindowEnterUserCommand
        {
            get
            {
                return openWindowEnterUserCommand ??
                    (openWindowEnterUserCommand = new RelayCommand(obj =>
                    {
                        Window parent = new Window();
                        foreach (Window window in App.Current.Windows)
                        {
                            if (window is MainWindow)
                            {
                                parent = window;
                            }
                        }
                        userEnterWindow = new UserEnter(parent);
                        userEnterWindow.Show();
                    }
                    ));
            }
        }
        public RelayCommand OpenWindowRegistratedUserCommand
        {
            get
            {
                return openWindowRegistratedUserCommand ??
                    (openWindowRegistratedUserCommand = new RelayCommand(obj =>
                    {
                        Window parent = new Window();
                        foreach (Window window in App.Current.Windows)
                        {
                            if (window is MainWindow)
                            {
                                parent = window;
                            }
                        }
                        userRegistratedWindow = new UserRegistrated(parent);
                        userRegistratedWindow.Show();
                    }
                    ));
            }
        }

        public User EnterUser()
        {
            if (UserTrayConnect == null)
                return null;
            var userFoing = dbController.GetUser(UserTrayConnect.NickName);
            if (userFoing == null)
            {
                MessageBox.Show("Not Foind");
                return null;
            }
            if (userFoing.Password != UserTrayConnect.Password)
            {
                MessageBox.Show("Error Password");
                return null;
            }
            return userFoing;
        }

        public User RegistratedUser()
        {
            if (UserTrayConnect.NickName == "" || UserTrayConnect.NickName == null)
            {
                MessageBox.Show("NickName emnty");
                return null;
            }
            if (UserTrayConnect.Password == "" || UserTrayConnect.Password == null)
            {
                MessageBox.Show("Password emnty");
                return null;
            }
            if (dbController.HaveUser(UserTrayConnect.NickName))
            {
                MessageBox.Show("User exist.");
                return null;
            }
            return dbController.AddUser(UserTrayConnect.NickName, UserTrayConnect.Password);
        }

        public void ClouseWindowEnterUser()
        {
            if(userEnterWindow==null) 
                return;
            userEnterWindow.Close();
        }

        public void ClouseWindowRegistratedUser()
        {
            if (userRegistratedWindow == null) 
                return;
            userRegistratedWindow.Close();
        }
    }
}
