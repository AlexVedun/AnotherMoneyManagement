using AMM_Desktop_Client.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMM_Desktop_Client.Services
{
    static class Globals
    {
        public static ObservableCollection<Transaction> Transactions { get; set; } = new ObservableCollection<Transaction>();
        public static ObservableCollection<Source> Sources { get; set; } = new ObservableCollection<Source>();

        
    }
}
