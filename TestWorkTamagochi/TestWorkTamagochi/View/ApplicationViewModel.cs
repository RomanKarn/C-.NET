using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using TestWorkTamagochi.Model;

namespace TestWorkTamagochi.View
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {

        private EnterNameTomog userEnterWindow;
        private RelayCommand eatCommand;
        private RelayCommand plaerGameCommand;
        private RelayCommand sleepingCommand;
        private RelayCommand healingCommand;
        public Plaer Plaer { get; set; }
        public ApplicationViewModel() 
        {
            Plaer = new Plaer();
        }

        public int Health
        {
            get
            {
                return Plaer.HealthPlaer.Param;
            }
            set
            {

            }
        }
        public int Full
        {
            get
            {
                return Plaer.FullPlaer.Param;
            }
            set
            {

            }
        }
        public int Sleep
        {
            get
            {
                return Plaer.SleepPlaer.Param;
            }
            set
            {

            }
        }
        public int Happi
        {
            get
            {
                return Plaer.HeppiPlaer.Param;
            }
            set
            {

            }
        }

        public RelayCommand EatCommand
        {
            get
            {
                return eatCommand ??
                    (eatCommand = new RelayCommand(obj =>
                    {
                        Plaer.EatPlaer();
                        OnPropertyChanged("Health");
                        OnPropertyChanged("Full");
                    }, (obj) => Health > 0 && Full > 0 && Sleep > 0 && Happi > 0
                    ));
            }
        }
        public RelayCommand PlaerGameCommand
        {
            get
            {
                return plaerGameCommand ??
                    (plaerGameCommand = new RelayCommand(obj =>
                    {
                        Plaer.PlayGamePlaer();
                        OnPropertyChanged("Health");
                        OnPropertyChanged("Full");
                        OnPropertyChanged("Sleep");
                        OnPropertyChanged("Happi");
                    }, (obj) => Health > 0 && Full > 0 && Sleep > 0 && Happi > 0
                    ));
            }
        }
        public RelayCommand SleepingCommand
        {
            get
            {
                return sleepingCommand ??
                    (sleepingCommand = new RelayCommand(obj =>
                    {
                        Plaer.SleepingPlaer();
                        OnPropertyChanged("Health");
                        OnPropertyChanged("Full");
                        OnPropertyChanged("Sleep");
                        OnPropertyChanged("Happi");
                    }, (obj) => Health > 0 && Full > 0 && Sleep > 0 && Happi > 0
                    ));
            }
        }
        public RelayCommand HealingCommand
        {
            get
            {
                return healingCommand ??
                    (healingCommand = new RelayCommand(obj =>
                    {
                        Plaer.HealingPlaer();
                        OnPropertyChanged("Health");
                        OnPropertyChanged("Full");
                        OnPropertyChanged("Sleep");
                        OnPropertyChanged("Happi");
                    }, (obj) => Health > 0 && Full > 0 && Sleep > 0 && Happi > 0
                    )
                );
            }
        }

        public void ShowWindowEnterNamePlaer()
        {
            Window parent = new Window();
            foreach (Window window in App.Current.Windows)
            {
                if (window is MainWindow)
                {
                    parent = window;
                }
            }
            userEnterWindow = new EnterNameTomog(parent);
            userEnterWindow.Show();
        }

        public RelayCommand ClouseWindow
        {
            get
            {
                return (new RelayCommand(obj =>
                    {
                        userEnterWindow.Close();
                    }
                    ));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
