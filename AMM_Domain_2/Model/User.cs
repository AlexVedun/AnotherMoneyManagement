using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMM_Domain_2.Model
{
    public partial class User
    {        
        public User()
        {
            this.Sources = new HashSet<Source>();
            this.Transactions = new HashSet<Transaction>();
            //this.TransactionLogs = new HashSet<TransactionLog>();
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }

        public virtual Family Family { get; set; }
        [JsonIgnore]
        public virtual ICollection<Source> Sources { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        //public virtual ICollection<TransactionLog> TransactionLogs { get; set; }
    }
}
