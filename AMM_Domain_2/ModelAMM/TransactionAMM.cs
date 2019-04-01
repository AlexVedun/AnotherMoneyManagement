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
            List<Transaction> tempList = mdb.TransactionSet.Where(x => x.User.Login == _login).ToList();
            List<Transaction> result = new List<Transaction>();
            foreach (var item in tempList)
            {
                if (DateTime.Parse(item.Date).Date == DateTime.Today)
                {
                    result.Add(item);
                }
            }
            return result;
            //return mdb.TransactionSet.Where(x => x.User.Login == _login && DbFunctions.TruncateTime(DateTime.Parse(x.Date)) == DateTime.Today).ToList();            
        }

        public IEnumerable<Transaction> GetTransactionsFromTo(string _login, DateTime _from, DateTime _to)
        {
            List<Transaction> tempList = mdb.TransactionSet.Where(x => x.User.Login == _login).ToList();
            List<Transaction> result = new List<Transaction>();
            foreach (var item in tempList)
            {
                if (DateTime.Parse(item.Date).Date >= _from && DateTime.Parse(item.Date).Date <= _to)
                {
                    result.Add(item);
                }
            }
            return result;
            //return mdb.TransactionSet.Where(
            //    x => x.User.Login == _login && 
            //    DbFunctions.TruncateTime(DateTime.Parse(x.Date)) >= _from &&
            //    DbFunctions.TruncateTime(DateTime.Parse(x.Date)) <= _to
            //).ToList();
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
