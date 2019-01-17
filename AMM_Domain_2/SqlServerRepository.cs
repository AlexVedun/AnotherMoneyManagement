using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMM_Domain_2.Model;

namespace AMM_Domain_2
{
    public class SqlServerRepository : IRepository
    {
        private AMMContainer mdb;

        public SqlServerRepository()
        {
            mdb = new AMMContainer();
        }

        public FamilyAMM FamilyAMM => new FamilyAMM(mdb);
        public UserAMM UserAMM => new UserAMM(mdb);
        public SourceAMM SourceAMM => new SourceAMM(mdb);
        //public TypeOfSourceAMM TypeOfSourceAMM => new TypeOfSourceAMM(mdb);
    }
}
