using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public IEnumerable<Transaction> GetTransactionsForToday(string _login)
        {
            return mdb.TransactionSet.Where(x => x.User.Login == _login && DbFunctions.TruncateTime(x.Date) == DateTime.Today).ToList();            
        }

        public IEnumerable<Transaction> GetTransactionsFromTo(string _login, DateTime _from, DateTime _to)
        {
            return mdb.TransactionSet.Where(
                x => x.User.Login == _login && 
                DbFunctions.TruncateTime(x.Date) >= _from &&
                DbFunctions.TruncateTime(x.Date) <= _to
            ).ToList();
        }

        public void SaveTransaction(Transaction _transaction)
        {
            if (_transaction != null)
            {
                mdb.TransactionSet.Add(_transaction);
            }
            mdb.SaveChanges();
        }
    }
}
