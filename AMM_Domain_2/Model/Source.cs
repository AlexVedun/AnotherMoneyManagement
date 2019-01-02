using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMM_Domain_2.Model
{
    public partial class Source
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Money { get; set; }
        public string Description { get; set; }

        public virtual TypeOfSource Type { get; set; }
    }
}
