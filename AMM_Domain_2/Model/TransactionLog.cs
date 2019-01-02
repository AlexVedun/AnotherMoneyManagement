using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMM_Domain_2.Model
{
    public partial class TransactionLog
    {        
        public TransactionLog()
        {
            this.Transactions = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public TransStatus Status { get; set; }
        public string ErrorDetail { get; set; }
        public string Comment { get; set; }

        public virtual User User { get; set; }
        public virtual Source From { get; set; }
        public virtual Source To { get; set; }        
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
