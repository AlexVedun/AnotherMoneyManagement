using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMM_Domain.Model
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
            return null;
        }

        public void SaveFamily(Family _family)
        {

        }

        public Family GetFamilyByName (string _name)
        {
            return null;
        }
    }
}
