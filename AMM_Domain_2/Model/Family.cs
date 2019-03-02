using Newtonsoft.Json;
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
            this.Sources = new HashSet<Source>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]        
        public virtual ICollection<User> Users { get; set; }
        [JsonIgnore]
        public virtual User Admin { get; set; }
        public virtual ICollection<Source> Sources { get; set; }
    }
}
