using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Windows.Documents;

namespace WpfApp1.Model
{
    [Index(nameof(NickName), IsUnique = true)]
    public class User : INotifyPropertyChanged
    {
        private int id;
        private string nickName;
        private string password;
        private List<Mission> missions =new();
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }

        }
        [Required]
        public string NickName
        {
            get { return nickName; }
            set
            {
                nickName = value;
                OnPropertyChanged("NickName");
            }
        }
        [Required]
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }
        public List<Mission> Missions
        {
            get { return missions; }
            set
            {
                missions.AddRange(value);
                OnPropertyChanged("Missions");
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
