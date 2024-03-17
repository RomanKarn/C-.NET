using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.Model;
using WpfApp1.Model.DBMameger;

namespace WpfApp1.ViewModel.ControllersView
{
    public class ElementMissionController : INotifyPropertyChanged
    {
        private DBController dbController;
        private User userLogger;

        private Mission selectedMission = new Mission();
        private Mission selectedMissionOnDiscriphen = new Mission();
        private Mission newMission;
        private bool takeMissionThisUser;
        private int startTakeElements = 0;
        private int collTakeNeedElement = 5;
        private int collHavingBaseElemetLastEpirasion = 1;

       
        private RelayCommand lodingElementMissionList;
        private RelayCommand selectFilterTakeMissionIsUser;
        private RelayCommand addMissionCommand;
        private RelayCommand saveMissionCommand;
        private RelayCommand deletMissionCommand;
        public ElementMissionController(DBController dbController, User userEnteringLigin)
        {
            this.dbController = dbController;
            this.userLogger = userEnteringLigin;
        }
        public ObservableCollection<Mission> MissionLoad { get; set; } = new ObservableCollection<Mission>();
        public Mission SelectedMission
        {
            get
            {
                return selectedMission;
            }
            set
            {
                if (value == null)
                    return;

                if (newMission != null && value.Id != newMission.Id)
                {
                    foreach (Mission mission in MissionLoad)
                    {
                        if (mission.Id == newMission.Id)
                        {
                            MissionLoad.Remove(mission);
                            newMission = null;
                            break;
                        }
                    }
                }
                selectedMission = value;
                selectedMissionOnDiscriphen = new Mission() { Id = selectedMission.Id, Name = selectedMission.Name, Description = selectedMission.Description, UserCriate = selectedMission.UserCriate };
                OnPropertyChanged("SelectedMissionOnDiscriphen");
            }
        }
        public Mission SelectedMissionOnDiscriphen
        {
            get
            {
                return selectedMissionOnDiscriphen;
            }
            set
            {
                if (value == null)
                    return;
                selectedMissionOnDiscriphen = value;
            }
        }

        public RelayCommand LodingElementMissionList
        {
            get
            {
                return lodingElementMissionList ??
                    (lodingElementMissionList = new RelayCommand(obj =>
                    {
                        IEnumerable<Mission> listArgementTakeMissionBD;
                        if (takeMissionThisUser && userLogger != null)
                        {
                            listArgementTakeMissionBD = dbController.LodintMissionToDoFiltersUserCriate(startTakeElements, collTakeNeedElement, (x => x.UserCriate.Id == userLogger.Id));
                        }
                        else
                        {
                            listArgementTakeMissionBD = dbController.LodintMissionToDo(startTakeElements, collTakeNeedElement);
                        }
                        collHavingBaseElemetLastEpirasion = listArgementTakeMissionBD.Count();
                        startTakeElements += collTakeNeedElement;
                        foreach (var missing in listArgementTakeMissionBD)
                        {
                            MissionLoad.Add(missing);
                        }

                    }, (obj) => collHavingBaseElemetLastEpirasion > 0
                    ));
            }
        }

        public RelayCommand SelectFilterTakeMissionThisUser
        {
            get
            {
                return selectFilterTakeMissionIsUser ??
                    (selectFilterTakeMissionIsUser = new RelayCommand(obj =>
                    {
                        var chek = obj as CheckBox;
                        takeMissionThisUser = !takeMissionThisUser;
                        if (chek != null)
                            chek.IsChecked = takeMissionThisUser;
                        RelodingListMisiionLoad();
                    }, (obj) => userLogger != null
                    ));
            }
        }

        public RelayCommand AddMissionCommand
        {
            get
            {
                return addMissionCommand ??
                    (addMissionCommand = new RelayCommand(obj =>
                    {
                        if (newMission != null)
                        {
                            foreach (Mission mission in MissionLoad)
                            {
                                if (mission.Id == newMission.Id)
                                {
                                    MissionLoad.Remove(mission);
                                    newMission = null;
                                    break;
                                }
                            }
                        }
                        newMission = new Mission() { UserCriate = userLogger };
                        MissionLoad.Add(newMission);
                        SelectedMission = newMission;
                        SelectedMissionOnDiscriphen = newMission;
                        OnPropertyChanged("SelectedMissionOnDiscriphen");
                    }, (obj) => userLogger != null
                    ));
            }
        }

        public RelayCommand SaveMissionCommand
        {
            get
            {
                return saveMissionCommand ??
                  (saveMissionCommand = new RelayCommand(obj =>
                  {
                      if (SelectedMission == null || SelectedMission.UserCriate == null)
                          return;
                      if (userLogger.Id != SelectedMission.UserCriate.Id)
                      {
                          MessageBox.Show("You not can edit not your miossion");
                          return;
                      }
                      if (selectedMissionOnDiscriphen.Name == null|| selectedMissionOnDiscriphen.Name == "")
                      {
                          MessageBox.Show("Name not be enpty");
                          return;
                      }
                      if(selectedMissionOnDiscriphen.Description == null || selectedMissionOnDiscriphen.Description == "")
                      {
                          MessageBox.Show("Description not be enpty");
                          return;
                      }
                      if (newMission != null)
                      {
                          bool save = dbController.AddMission(selectedMissionOnDiscriphen.Name, selectedMissionOnDiscriphen.Description, userLogger);
                          if (save)
                              MessageBox.Show("Save Conferm.");
                          else
                              MessageBox.Show("Save Error.");
                      }
                      else
                      {
                          foreach (Mission mission in MissionLoad)
                          {
                              if (mission.Id == selectedMission.Id)
                              {
                                  bool change = dbController.ChangeMission(selectedMission.Id, selectedMissionOnDiscriphen.Name, selectedMissionOnDiscriphen.Description);
                                  if (change)
                                      MessageBox.Show("Change Save Conferm.");
                                  else
                                      MessageBox.Show("Change Save Error.");
                                  break;
                              }
                          }
                      }
                      selectedMission = null;
                      selectedMissionOnDiscriphen = null;
                      newMission = null;
                      RelodingListMisiionLoad();
                      OnPropertyChanged("SelectedMissionOnDiscriphen");

                  }, (obj) => userLogger != null
                  ));
            }
        }

        public RelayCommand DeletMissionCommand
        {
            get
            {
                return deletMissionCommand ??
                  (deletMissionCommand = new RelayCommand(obj =>
                  {
                      if (SelectedMission == null || SelectedMission.UserCriate == null)
                          return;
                      if (userLogger.Id != SelectedMission.UserCriate.Id)
                      {
                          MessageBox.Show("You not can delet not your miossion");
                          return;
                      }

                      bool delet = dbController.DeletMission(SelectedMission.Id);
                      if (delet)
                      {
                          selectedMission = null;
                          selectedMissionOnDiscriphen = null;
                          newMission = null;
                          RelodingListMisiionLoad();
                          OnPropertyChanged("SelectedMissionOnDiscriphen");
                          MessageBox.Show("Delet Conferm.");
                      }
                      else
                      {
                          MessageBox.Show("Delet Error.");
                      }

                  }, (obj) => MissionLoad.Count > 0 && userLogger != null
                  ));
            }
        }

        public void SetUser(User user)
        {
            userLogger = user;
        }
        private void RelodingListMisiionLoad()
        {
            startTakeElements = 0;
            MissionLoad.Clear();
            LodingElementMissionList.Execute(null);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
