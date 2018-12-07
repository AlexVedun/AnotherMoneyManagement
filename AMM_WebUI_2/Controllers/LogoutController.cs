using AMM_WebUI_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace AMM_WebUI_2.Controllers
{
    public class LogoutController : ApiController
    {
        [Route("api/logout")]
        public ApiResponse<Object> Post()
        {
            try
            {
                HttpContext.Current.Session["user_login"] = null;
                return new ApiResponse<Object>() { data = "logout" };
            }
            catch (Exception ex)
            {
                return new ApiResponse<Object>() { error = ex.Message };
            }
        }
    }
}
