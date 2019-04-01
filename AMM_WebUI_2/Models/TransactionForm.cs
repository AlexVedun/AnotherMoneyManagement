using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMM_WebUI_2.Models
{
    public class TransactionForm
    {
        //public System.DateTime Date { get; set; }
        public string Date { get; set; }
        public string Comment { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public decimal Summ { get; set; }
    }
}