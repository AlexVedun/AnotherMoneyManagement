using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMM_Desktop_Client.Model
{
    public partial class Transaction
    {
        public int Id { get; set; }        
        public string Date { get; set; }
        public string Time { get; set; }
        public string Comment { get; set; }
        public decimal Debet { get; set; }
        public decimal Credit { get; set; }
        public decimal Summ { get; set; }

        public virtual Source From { get; set; }
        public virtual Source To { get; set; }
    }    
}
