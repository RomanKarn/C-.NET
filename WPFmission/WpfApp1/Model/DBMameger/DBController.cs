using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WpfApp1.Model.DBMameger
{
    public class DBController
    {
        public User GetUser(string Name)
        {
            User user = new User();
            using (ApplicationContext DB = new ApplicationContext())
            {
                user = DB.Users.Where(n=>n.NickName==Name).Include(m =>m.Missions).FirstOrDefault();
            }
            return user;
        }
        public bool HaveUser(string Name)
        {
            bool result = false;

            using (ApplicationContext DB = new ApplicationContext())
            {
                var user = DB.Users.Where(n => n.NickName == Name).FirstOrDefault();
                if(user != null)
                {
                    result = true;
                }
            }
            return result;
        }
        public User AddUser(string Name, string Password)
        {
            User userNew = new User() { NickName = Name, Password = Password };

            using(ApplicationContext DB = new ApplicationContext())
            {
                DB.Users.Add(userNew);
                DB.SaveChanges();
            }
            return userNew;
        }

        public bool AddMission(string Name, string Description, User UserCriate)
        {
            using(ApplicationContext DB = new ApplicationContext())
            {
                Mission missionNew = new Mission() { Name = Name, Description = Description};
                var user = DB.Users.Where(n => n.Id == UserCriate.Id).FirstOrDefault();
                if (user != null)
                    missionNew.UserCriate = user;
                else
                {
                    return false;
                }
                DB.Missions.Add(missionNew);
                DB.SaveChanges();
                return true;
            }
        }
        public bool DeletMission(int MissionId)
        {
            using(ApplicationContext DB = new ApplicationContext())
            {
                var mission= DB.Missions.Where(m=>m.Id==MissionId).FirstOrDefault();
                if(mission == null)
                    return false;
                DB.Remove(mission);
                DB.SaveChanges();
                return true;
            }
        }
        public bool ChangeMission(int Id,string Name, string Description)
        {
            Mission mission = new Mission();

            using (ApplicationContext DB = new ApplicationContext())
            {
                mission = DB.Missions.Where(m => m.Id == Id).Include(m => m.UserCriate).FirstOrDefault();
                if (mission == null)
                    return false;
                mission.Name = Name;
                mission.Description = Description;
                DB.Missions.Update(mission);
                DB.SaveChanges();
            }
            return true;
        }
        public IEnumerable<Mission> LodintMissionToDo(int startLoding,int collTake)
        {
            IEnumerable<Mission> missions;
            using (ApplicationContext DB = new ApplicationContext())
            {
                missions = DB.Missions.Include(m => m.UserCriate).Skip(startLoding).Take(collTake).ToList();
            }
            return missions;
        }
        public IEnumerable<Mission> LodintMissionToDoFiltersUserCriate(int startLoding, int collTake,Func<Mission, bool> filter)
        {
            IEnumerable<Mission> missions;
            using (ApplicationContext DB = new ApplicationContext())
            {
                missions = DB.Missions.Include(m => m.UserCriate).Where(filter).Skip(startLoding).Take(collTake).ToList();
            }
            return missions;
        }
    }
}
