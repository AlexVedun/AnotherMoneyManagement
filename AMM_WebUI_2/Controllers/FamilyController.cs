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
    public class FamilyController : ApiController
    {
        private IRepository mRepository;

        public FamilyController(IRepository _repository)
        {
            mRepository = _repository;
        }

        [Route("api/family/add")]
        public ApiResponse<Family> Post([FromBody]FamilyForm _family)
        {
            string login = HttpContext.Current.Session["user_login"].ToString();
            try
            {
                Family family = new Family();
                User user = mRepository.UserAMM.GetUserByLogin(login);
                family.Name = _family.Name;
                //family.Users.Add(user);
                family.Admin = user;
                mRepository.FamilyAMM.SaveFamily(family);
                user.Family = family;
                mRepository.UserAMM.SaveUser(user);
                return new ApiResponse<Family>() { data = family, error = "" };
            }
            catch (Exception ex)
            {
                return new ApiResponse<Family>() { error = ex.Message };
            }
        }
    }
}
