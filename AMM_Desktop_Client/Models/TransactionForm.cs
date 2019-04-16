using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMM_Desktop_Client.Models
{
    public class TransactionForm
    {
        public string Date { get; set; }
        public string Comment { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public decimal Summ { get; set; }
    }
}