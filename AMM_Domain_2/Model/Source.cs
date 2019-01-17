using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMM_Domain_2.Model
{
    public partial class Source
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal Money { get; set; }
        public string Description { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
        [Required]
        public TypeOfSource Type { get; set; }

        [Required]
        public virtual User User { get; set; }        
    }
}
