using System.ComponentModel;
using System.Runtime.CompilerServices;
using TestWorkTamagochi.Model.Actions;
using TestWorkTamagochi.Model.Parameters;

namespace TestWorkTamagochi.Model
{
    public class Plaer : INotifyPropertyChanged
    {
        private string name;

        private Health health;
        private Full full;
        private Sleep sleep;
        private Happi happi;

        private Eat eat;
        private PlayGame playGame;
        private Sleeping sleeping;
        private Healing healing;
        public Plaer(string Name = "Upa", int maxHealth = 10, int maxFull = 10, int maxSleep = 10, int maxHappi = 10)
        {
            this.Name = Name;
            this.health = new Health(maxHealth,"Здоровье");
            this.full = new Full(maxFull, "Еда");
            this.sleep = new Sleep(maxSleep, "Сон");
            this.happi = new Happi(maxHappi, "Счастья");
            this.eat = new Eat(this);
            this.playGame = new PlayGame(this);
            this.sleeping = new Sleeping(this);
            this.healing = new Healing(this);
        }
        public string Name
        {
            get 
            { 
                return name; 
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public void EatPlaer()
        {
            this.eat.DoMake();
        }
        public void PlayGamePlaer()
        {
            this.playGame.DoMake();
        }
        public void SleepingPlaer()
        {
            this.sleeping.DoMake();
        }
        public void HealingPlaer()
        {
            this.healing.DoMake();
        }
        public Health HealthPlaer
        {
            get
            {
                return health;
            }
            set
            {
                health = value;
            }
        }
        public Full FullPlaer
        {
            get
            {
                return full;
            }
            set
            {
                full = value;
            }
        }
        public Sleep SleepPlaer
        {
            get
            {
                return sleep;
            }
            set
            {
                sleep = value;
            }
        }
        public Happi HeppiPlaer
        {
            get
            {
                return happi;
            }
            set
            {
                happi = value;
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
