using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMM_Domain.Model
{
    public class UserAMM
    {
        private AMMContainer mdb;
        public UserAMM(AMMContainer _db)
        {
            mdb = _db;
        }

        public IEnumerable<User> GetUsers()
        {
            return mdb.UserSet.ToList();
        }

        public void SaveUser(User _user)
        {
            User user = GetUserByLogin(_user.Login);
            if (user == null)
            {
                mdb.UserSet.Add(_user);
            }
            else
            {
                Type type = typeof(User);
                foreach (var item in type.GetProperties())
                {
                    item.SetValue(user, item.GetValue(_user));
                }
            }
            mdb.SaveChanges();
        }

        public User GetUserByLogin(string _login)
        {
            return mdb.UserSet.Where(x => x.Login == _login).FirstOrDefault();
        }
    }
}
