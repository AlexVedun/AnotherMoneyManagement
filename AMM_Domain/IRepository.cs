using AMM_Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMM_Domain
{
    public interface IRepository
    {
        FamilyAMM FamilyAMM { get; }
        UserAMM UserAMM { get; }
    }
}
