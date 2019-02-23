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
    public class UserController : ApiController
    {
        private IRepository mRepository;

        public UserController(IRepository _repository)
        {
            mRepository = _repository;
        }

        [Route("api/user/get")]
        public Object Get()
        {
            string login = HttpContext.Current.Session["user_login"].ToString();
            try
            {
                return new ApiResponse<Object>()
                {
                    data = mRepository.UserAMM.GetUserByLogin(login),
                    error = ""
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<Object>()
                {
                    error = ex.Message
                };
            }

        }

        [Route("api/user/save")]
        public ApiResponse<User> Post([FromBody]UserRequestForm _userForm)
        {
            try
            {
                User user = mRepository.UserAMM.GetUserByLogin(_userForm.Login);
                user.Password = _userForm.Password;
                user.Surname = _userForm.Surname;
                user.Name = _userForm.Name;
                user.Patronymic = _userForm.Patronymic;
                mRepository.UserAMM.SaveUser(user);
                return new ApiResponse<User>() { data = user, error = "" };                
            }
            catch (Exception ex)
            {

                return new ApiResponse<User>() { error = ex.Message };
            }
        }

        [Route("api/user/delete")]
        public ApiResponse<Object> Delete()
        {
            string login = HttpContext.Current.Session["user_login"].ToString();
            try
            {
                mRepository.UserAMM.DeleteUserByLogin(login);
                return new ApiResponse<Object>() { data = null, error = "" };
            }
            catch (Exception ex)
            {
                return new ApiResponse<Object>() { error = ex.Message };
            }
        }
    }
}
