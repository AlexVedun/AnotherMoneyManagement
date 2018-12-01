using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMM_WebUI_2.Models
{
    public class RegisterRequestForm: LoginRequestForm
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
    }
}