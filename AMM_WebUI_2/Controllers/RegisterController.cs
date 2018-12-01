using AMM_Domain;
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
    public class RegisterController : ApiController
    {
        private IRepository mRepository;

        public RegisterController(IRepository _repository)
        {
            mRepository = _repository;
        }

        [Route("api/register")]
        public ApiResponse<User> Post([FromBody]RegisterRequestForm _registerForm)
        {
            try
            {
                User user = mRepository.UserAMM.GetUserByLogin(_registerForm.Login);
                if (user == null)
                {
                    user = new User()
                    {
                        Login = _registerForm.Login,
                        Password = _registerForm.Password,
                        Surname = _registerForm.Surname,
                        Name = _registerForm.Name,
                        Patronymic = _registerForm.Patronymic
                    };
                    mRepository.UserAMM.SaveUser(user);
                    return new ApiResponse<User>() { data = user, error = "" };
                }
                else
                {
                    return new ApiResponse<User>() { error = "Пользователь с таким логином уже существует!" };
                }
            }
            catch (Exception ex)
            {

                return new ApiResponse<User>() { error = ex.Message };
            }
        }
    }
}
