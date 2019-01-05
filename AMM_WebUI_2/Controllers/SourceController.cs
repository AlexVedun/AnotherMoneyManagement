﻿using AMM_Domain_2;
using AMM_Domain_2.Model;
using AMM_WebUI_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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

        [Route("api/get-source-types")]
        public Object Get()
        {
            return new ApiResponse<Object>() { data = mRepository.TypeOfSourceAMM.GetTypes(), error = "" };
        }

        [Route("api/get-sources")]
        public Object Get(bool _b1 = false)
        {
            return new ApiResponse<Object>() { data = mRepository.SourceAMM.GetSources(), error = "" };
        }

        [Route("api/add-source")]
        public ApiResponse<Source> Post([FromBody]AddSourceForm _addSourceForm)
        {
            try
            {
                Source source = mRepository.SourceAMM.GetSourceByName(_addSourceForm.Name);
                if (source == null)
                {
                    source = new Source()
                    {
                        Name = _addSourceForm.Name,
                        Money = _addSourceForm.Money,
                        Description = _addSourceForm.Description,
                        Type = mRepository.TypeOfSourceAMM.GetTypeById(_addSourceForm.TypeOfSource)
                    };
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
    }
}
