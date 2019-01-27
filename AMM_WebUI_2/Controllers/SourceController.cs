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
    public class SourceController : ApiController
    {
        private IRepository mRepository;

        public SourceController(IRepository _repository)
        {
            mRepository = _repository;
        }

        //[Route("api/get-source-types")]
        //public Object Get()
        //{
        //    return new ApiResponse<Object>() { data = mRepository.TypeOfSourceAMM.GetTypes(), error = "" };
        //}
        // запрос источников для текущего пользователя
        [Route("api/get-sources")]
        public Object Get(/*bool _b1 = false*/)
        {
            return new ApiResponse<Object>()
                {
                    data = mRepository.SourceAMM.GetSourcesForUser(HttpContext.Current.Session["user_login"].ToString()),
                    error = ""
                };
        }

        [Route("api/add-source")]
        public ApiResponse<Source> Post([FromBody]AddSourceForm _addSourceForm)
        {
            string login = HttpContext.Current.Session["user_login"].ToString();
            try
            {
                Source source = mRepository.SourceAMM.GetSourceByName(login, _addSourceForm.Name);
                if (source == null)
                {
                    source = new Source()
                    {
                        Name = _addSourceForm.Name,
                        Money = _addSourceForm.Money,
                        Description = _addSourceForm.Description,
                        IsDeleted = false,
                        //Type = mRepository.TypeOfSourceAMM.GetTypeById(_addSourceForm.TypeOfSource),
                        Type = (TypeOfSource)_addSourceForm.TypeOfSource,
                        User = mRepository.UserAMM.GetUserByLogin(login)
                    };
                    mRepository.SourceAMM.SaveSource(source);
                    return new ApiResponse<Source>() { data = source, error = "" };
                }                
                else if (source.IsDeleted == true)
                {
                    source.Money = _addSourceForm.Money;
                    source.Description = _addSourceForm.Description;
                    source.IsDeleted = false;
                    mRepository.SourceAMM.SaveSource(source);
                    return new ApiResponse<Source>() { data = source, error = "" };
                }
                else
                {
                    return new ApiResponse<Source>() { error = "Кошелек/карта/категория расходов с таким именем уже существуют!" };
                }
            }
            catch (Exception ex)
            {

                return new ApiResponse<Source>() { error = ex.Message };
            }
        }

        [Route("api/delete-source/{_Id}")]
        public ApiResponse<Source> Delete([FromUri] int _Id)
        {
            string login = HttpContext.Current.Session["user_login"].ToString();
            try
            {
                Source source = mRepository.SourceAMM.GetSourceById(login, _Id);                
                if (source != null)
                {
                    source.IsDeleted = true;
                    mRepository.SourceAMM.SaveSource(source);
                    return new ApiResponse<Source>() { data = source, error = "" };
                }
                else
                {
                    return new ApiResponse<Source>() { error = "Критическая ошибка! Не могу найти выбранный для удуления источник." };
                }
            }
            catch (Exception ex)
            {

                return new ApiResponse<Source>() { error = ex.Message };
            }
        }
    }
}
