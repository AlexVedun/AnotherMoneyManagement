using AMM_Domain_2;
using AMM_Domain_2.Model;
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
    public class LoginController : ApiController
    {
        private IRepository mRepository;

        public LoginController(IRepository _repository)
        {
            mRepository = _repository;
        }

        [Route("api/login")]
        public ApiResponse<User> Post ([FromBody]LoginRequestForm _loginForm)
        {
            try
            {
                User user = mRepository.UserAMM.GetUserByLogin(_loginForm.Login);
                if (user != null && _loginForm.Password == user.Password)
                {
                    HttpContext.Current.Session["user_login"] = _loginForm.Login;
                    return new ApiResponse<User>() { data = user, error = "" };
                }
                else
                {
                    return new ApiResponse<User>() { error = "Нет такого пользователя или задан неверный пароль!" };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<User>() { error = ex.Message };
            }
        }

        [Route("api/login/checkout")]
        public Object Get ()
        {
            return HttpContext.Current.Session["user_login"];
        }
    }
}
