using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMM_Desktop_Client.Models
{
    public class ApiResponse<T>
    {
        public T data { get; set; }
        public string error { get; set; }
    }
}