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
    public class SearchController : ApiController
    {

        [HttpGet]
        [Route("api/search/tweet/{tag}")]
        public IList<GetTweetDto> SearchTweet(string tag) {

            SearchBll searchBll = new SearchBll();
            return searchBll.SearchTweet(tag);

        }

        [HttpGet]
        [Route("api/search/user/{tag}/{uid}")]
        public IList<UserDto> Searchdto(string tag,int uid) {
            SearchBll searchBll = new SearchBll();
            return searchBll.SearchUser(tag,uid);
        }


        // GET: api/Search
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Search/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Search
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Search/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Search/5
        public void Delete(int id)
        {
        }
    }
}
