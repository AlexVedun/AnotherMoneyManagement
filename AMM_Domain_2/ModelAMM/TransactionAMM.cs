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

        public IEnumerable<Transaction> GetTransactionsForToday(string _login)
        {
            DateTime t1 = DateTime.Today;
            List<DateTime> tt = new List<DateTime>();
            tt = mdb.TransactionSet.Select(x => x.Date.Date).ToList();
            return mdb.TransactionSet.Where(x => x.User.Login == _login && x.Date.Date == DateTime.Today).ToList();
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
