using AMM_Domain_2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMM_Domain_2
{
    public interface IRepository
    {
        FamilyAMM FamilyAMM { get; }
        UserAMM UserAMM { get; }
        SourceAMM SourceAMM { get; }
        TransactionAMM TransactionAMM { get; }
        //TypeOfSourceAMM TypeOfSourceAMM { get; }
    }
}
