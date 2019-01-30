using AMM_Domain_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AMM_WebUI_2.Controllers
{
    public class TransactionController : ApiController
    {
        private IRepository mRepository;

        public TransactionController(IRepository _repository)
        {
            mRepository = _repository;
        }
    }
}
