using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMM_Domain
{
    public class AMM_Interface
    {
        ObservableCollection<User> GetUsers()
        {
            AMMContainer db = new AMMContainer();
            ObservableCollection<User> users = new ObservableCollection<User>(db.UserSet.ToList());
            return users;
        }

        void AddOrChangeUser(User _user)
        {
            AMMContainer db = new AMMContainer();
            User user = db.UserSet.Where(x => x.Login == _user.Login).FirstOrDefault();
            if (user == null)
            {
                db.UserSet.Add(_user);
            }
            else
            {
                user.Login = _user.Login;
                user.Name = _user.Name;
                user.Password = _user.Password;
                user.Patronymic = _user.Patronymic;
                user.Surname = _user.Surname;
            }
            db.SaveChanges();
        }


    }
}
