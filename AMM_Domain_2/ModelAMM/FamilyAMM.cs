using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMM_Domain_2.Model
{
    public class FamilyAMM
    {
        private AMMContainer mdb;
        public FamilyAMM(AMMContainer _db)
        {
            mdb = _db;
        }

        public IEnumerable<Family> GetFamilies()
        {
            return mdb.FamilySet.ToList();
        }

        public void SaveFamily(Family _family)
        {
            Family family = GetFamilyByName(_family.Name);
            if (family == null)
            {
                mdb.FamilySet.Add(_family);
            }
            else
            {
                Type type = typeof(Family);
                foreach (var item in type.GetProperties())
                {
                    item.SetValue(family, item.GetValue(_family));
                }
            }
            mdb.SaveChanges();
        }

        public Family GetFamilyByName (string _name)
        {
            return mdb.FamilySet.Where(x => x.Name == _name).FirstOrDefault();
        }
    }
}
