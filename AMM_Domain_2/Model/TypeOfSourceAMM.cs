using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMM_Domain_2.Model
{
    public class TypeOfSourceAMM
    {
        private AMMContainer mdb;
        public TypeOfSourceAMM(AMMContainer _db)
        {
            mdb = _db;
        }

        public List<TypeOfSource> GetTypes()
        {
            return mdb.TypeOfSourceSet.ToList();
        }

        public TypeOfSource GetTypeById (int _id)
        {
            return mdb.TypeOfSourceSet.Where(x => x.Id == _id).FirstOrDefault();
        }
    }
}
