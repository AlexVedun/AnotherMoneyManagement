using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMM_Domain_2.Model
{
    public class SourceAMM
    {
        private AMMContainer mdb;
        public SourceAMM(AMMContainer _db)
        {
            mdb = _db;
        }

        public IEnumerable<Source> GetSources()
        {
            return mdb.SourceSet.ToList();
        }

        public IEnumerable<Source> GetSourcesForUser(string _login)
        {
            return mdb.SourceSet.Where(x => x.User.Login == _login && x.IsDeleted == false).ToList();
        }

        public Source GetSourceByName(string _login, string _name)
        {
            return mdb.SourceSet.Where(x => x.User.Login == _login && x.Name == _name).FirstOrDefault();
        }

        public Source GetSourceById(string _login, int _id)
        {
            return mdb.SourceSet.Where(x => x.User.Login == _login && x.Id == _id).FirstOrDefault();
        }

        public void SaveSource (Source _source)
        {
            Source source = GetSourceById(_source.User.Login, _source.Id);
            if (source == null)
            {
                mdb.SourceSet.Add(_source);
            }
            else
            {
                Type type = typeof(Source);
                foreach (var item in type.GetProperties())
                {
                    item.SetValue(source, item.GetValue(_source));
                }
            }
            mdb.SaveChanges();
        }
    }
}
