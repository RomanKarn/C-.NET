using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace WpfApp1.Model
{
    public class Mission : INotifyPropertyChanged
    {
        private int id;
        private string name;
        private string description;
        private User userCriatingMission;
        [Key]
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }

        }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }
        public int UserCriatedID { get;set; }
        [ForeignKey("UserCriatedID")]
        public virtual User UserCriate
        {
            get { return userCriatingMission; }
            set { userCriatingMission = value; OnPropertyChanged("UserCriate"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
