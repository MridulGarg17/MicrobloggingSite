using DTOs;
using GlitterBll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GlitterApi.Controllers
{
    public class AnalyticsController : ApiController
    {


        [HttpGet]
        [Route("api/analytics/bonus")]
        public AnalyticsDto Bonus() {
            AnalyticsBll analytics = new AnalyticsBll();
           return analytics.Analytic();
        }



        // GET: api/Analytics
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Analytics/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Analytics
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Analytics/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Analytics/5
        public void Delete(int id)
        {
        }
    }
}
