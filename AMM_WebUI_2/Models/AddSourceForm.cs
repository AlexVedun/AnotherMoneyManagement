using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMM_WebUI_2.Models
{
    public class AddSourceForm
    {
        public string Name { get; set; }
        public decimal Money { get; set; }
        public string Description { get; set; }
        public int TypeOfSource { get; set; }
    }
}