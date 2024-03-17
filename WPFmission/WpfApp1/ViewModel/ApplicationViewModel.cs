using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.Model;
using WpfApp1.Model.DBMameger;
using WpfApp1.ViewModel.ControllersView;
using WpfApp1.Windows;

namespace WpfApp1.ViewModel
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private DBController DBController;
        public ElementMissionController ElementMissionControllerVuew { get; set; }
        public UserController UserControllerVuew { get; set; }
        public WindowsEnterAndRegistratedController WindowsEnterAndRegistratedControllerVuew { get; set; }

        private RelayCommand exitUser;
        private RelayCommand enterUserCommand;
        private RelayCommand registratedUserCommand;


        public ApplicationViewModel()
        {
            DBController = new DBController();
            

/*          var  Users = new ObservableCollection<User>()
            {
                new User() {NickName ="Bori",Password="1234"},
                new User() {NickName ="Liki",Password="1234"},
                new User() {NickName ="Zuba",Password="1234"},
                new User() {NickName ="Albert",Password="1234"},
                new User() {NickName ="Alberasdt",Password="1234"},
            };
            var MissionBD = new List<Mission>()
            {
                 new Mission() {Name="Work Homework", Description="Maf work, Litrecha work, russan work", UserCriate =Users[0]},
            new Mission() {Name="Work ATAAK!", Description="ATAAK BASE!", UserCriate =Users[0]},
            new Mission() {Name="Cocing", Description="Cucing maffolz", UserCriate =Users[2]},
            new Mission() {Name="Run", Description="Run boy run", UserCriate =Users[3]},
            new Mission() {Name="Somfing", Description="Work Somfing", UserCriate =Users[1]},
            };*/

            using (ApplicationContext db = new ApplicationContext())
            {
               // db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

             //   db.Users.AddRange(Users);
             //   db.Missions.AddRange(MissionBD);
            //    db.SaveChanges();
            }

            UserControllerVuew = new UserController();
            ElementMissionControllerVuew = new ElementMissionController(this.DBController, UserControllerVuew.UserLogger);
            WindowsEnterAndRegistratedControllerVuew = new WindowsEnterAndRegistratedController(this.DBController);
        }

        #region UserCommandMainWindow
       
       
        public RelayCommand ExitUser
        {
            get
            {
                return exitUser ??
                    (exitUser = new RelayCommand(obj =>
                    {
                        UserControllerVuew.ExitUser();
                        ElementMissionControllerVuew.SetUser(UserControllerVuew.UserLogger);
                        SelectFilterTakeMissionThisUser.Execute(null);
                    }, (obj) => UserControllerVuew.UserLogger != null
                    ));
            }
        }

        #endregion

        #region WindowsEnterAndRegistrateController
        
        public RelayCommand OpenWindowEnterUserCommand
        {
            get
            {
                return WindowsEnterAndRegistratedControllerVuew.OpenWindowEnterUserCommand;
            }
        }
        public RelayCommand OpenWindowRegistratedUserCommand
        {
            get
            {
                return WindowsEnterAndRegistratedControllerVuew.OpenWindowRegistratedUserCommand;
            }
        }
        public RelayCommand EnterUserCommand
        {
            get
            {
                return enterUserCommand ??
                    (enterUserCommand = new RelayCommand(obj =>
                    {
                        if (WindowsEnterAndRegistratedControllerVuew.EnterUser() is User user)
                        {
                            UserControllerVuew.UserLogger = user;
                            ElementMissionControllerVuew.SetUser(user);
                            WindowsEnterAndRegistratedControllerVuew.ClouseWindowEnterUser();
                        }
                    }
                    ));
            }


        }
        public RelayCommand RegistratedUserCommand
        {
            get
            {
                return registratedUserCommand ??
                    (registratedUserCommand = new RelayCommand(obj =>
                    {

                        if (WindowsEnterAndRegistratedControllerVuew.RegistratedUser() is User user)
                        {
                            UserControllerVuew.UserLogger = user;
                            ElementMissionControllerVuew.SetUser(user);
                            WindowsEnterAndRegistratedControllerVuew.ClouseWindowRegistratedUser();
                        }
                    }
                    ));
            }


        }
        #endregion

        #region ElementsController
        public RelayCommand LodingElementMissionList
        {
            get
            {
                return ElementMissionControllerVuew.LodingElementMissionList;
            }
        }
        public RelayCommand SelectFilterTakeMissionThisUser
        {
            get
            {
                return ElementMissionControllerVuew.SelectFilterTakeMissionThisUser;
            }
        }
        #endregion

     
        #region ButtonMissionCommand
        public RelayCommand AddMissionCommand
        {
            get
            {
                return ElementMissionControllerVuew.AddMissionCommand;
            }
        }

        public RelayCommand SaveMissionCommand
        {
            get
            {
                return ElementMissionControllerVuew.SaveMissionCommand;
            }
        }

        public RelayCommand DeletMissionCommand
        {
            get
            {
                return ElementMissionControllerVuew.DeletMissionCommand;
            }
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
