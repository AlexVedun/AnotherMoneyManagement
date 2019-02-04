using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMM_Domain_2.Model
{
    public partial class Transaction
    {
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public string Comment { get; set; }
        public decimal Debet { get; set; }
        public decimal Credit { get; set; }
        public int UserId { get; set; }        
        public int FromId { get; set; }
        public int ToId { get; set; }

        public virtual User User { get; set; }
        public virtual Source From { get; set; }
        public virtual Source To { get; set; }        
    }

    //public partial class Transaction
    //{
    //    public int Id { get; set; }
    //    public decimal Debet { get; set; }
    //    public decimal Credit { get; set; }
    //    //public int TransactionLogId { get; set; }

    //    //[JsonIgnore]
    //    public virtual TransactionLog TransactionLog { get; set; }
    //    public virtual Source Source { get; set; }
    //}
}
