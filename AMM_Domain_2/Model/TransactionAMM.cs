using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMM_Domain_2.Model
{
    public class TransactionAMM
    {
        private AMMContainer mdb;
        public TransactionAMM(AMMContainer _db)
        {
            mdb = _db;
        }

        public void SaveTransaction(TransactionLog _transactionLog)
        {
            if (_transactionLog != null)
            {
                mdb.TransactionLogSet.Add(_transactionLog);
            }            
            mdb.SaveChanges();
        }
    }
}
