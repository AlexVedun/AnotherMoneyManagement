using AMM_WebUI_2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace AMM_WebUI_2.Controllers
{
    public class ChunckController : ApiController
    {
        [Route("api/chunck")]
        public Object Get([FromUri] ChunckRequestForm _chunckRequest)
        {
            return GetHTMLPageText(AppDomain.CurrentDomain.BaseDirectory + "\\wwwroot\\pages\\" + _chunckRequest.Chunck + ".htm");
        }

        private Object GetHTMLPageText(string _pageUri/*, string _param*/)
        {
            var response = new HttpResponseMessage();
            string page = "";
            using (StreamReader reader = new StreamReader(_pageUri))
            {
                page = reader.ReadToEnd();
                //page = page.Replace("param", _param);
            }
            response.Content = new StringContent(page);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            return response;
        }
    }
}
