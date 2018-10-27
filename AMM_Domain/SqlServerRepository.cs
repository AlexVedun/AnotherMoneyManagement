using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMM_Domain.Model;

namespace AMM_Domain
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

        
    }
}
