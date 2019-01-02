using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMM_Domain_2.Model
{
    public partial class Family
    {        
        public Family()
        {
            this.Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
                
        public virtual ICollection<User> Users { get; set; }
        public virtual User Admin { get; set; }
    }
}
