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
    public class TweetController : ApiController
    {
        // GET: api/Tweet
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Tweet/5
        public IList<TweetDto> Get(int id)
        {
            TweetBll tweetBll = new TweetBll();
            return tweetBll.GetAllTweet(id);
            
        }


        // POST: api/Tweet
        public bool Post(TweetDto tweetDtoObject)
        {
            TweetBll tweetBll = new TweetBll();
            tweetBll.AddTweet(tweetDtoObject);
            return true;
        }

        // PUT: api/Tweet/5
        public void Put(TweetDto updatedTweet)
        {
            TweetBll tweetBll = new TweetBll();
            tweetBll.UpdateTweet(updatedTweet);

        }

        // DELETE: api/Tweet/5
        public bool Delete(int id)
        {
            TweetBll tweetBll = new TweetBll();
            return tweetBll.DeleteTweet(id);
        }
    }
}
