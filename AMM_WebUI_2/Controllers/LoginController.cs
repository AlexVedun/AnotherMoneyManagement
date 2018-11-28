using AMM_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AMM_WebUI_2.Controllers
{
    public class LoginController : ApiController
    {
        private IRepository mRepository;

        public LoginController(IRepository _repository)
        {
            mRepository = _repository;
        }
    }
}
