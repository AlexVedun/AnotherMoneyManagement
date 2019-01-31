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
        public decimal Debet { get; set; }
        public decimal Credit { get; set; }

        [JsonIgnore]
        //public virtual TransactionLog TransactionLog { get; set; }
        public virtual Source Source { get; set; }
    }
}
