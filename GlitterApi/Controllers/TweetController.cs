using DTOs;
using GlitterBll;
using System.Collections.Generic;
using GlitterApi.Session;
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
        [HttpGet]
        [Route("api/tweet/{sessionId}")]
        public IList<GetTweetDto> Get(string sessionId)
        {
            if (Session.Session.Validate(sessionId))
            {
                TweetBll tweetBll = new TweetBll();
                return tweetBll.GetAllTweet(Session.Session.Guid[sessionId]);
            }
            return null;
        }


        // POST: api/Tweet
        public bool Post(TweetDto tweetDtoObject)
        {
            if (ModelState.IsValid)
            {
                if (Session.Session.Validate(tweetDtoObject.SessionId))
                {
                    TweetBll tweetBll = new TweetBll();
                    return tweetBll.AddTweet(tweetDtoObject);

                }
            }
            return false;
        }

        // PUT: api/Tweet/5
        public bool Put(TweetDto updatedTweet)
        {
            if (Session.Session.Validate(updatedTweet.SessionId))
            {
                TweetBll tweetBll = new TweetBll();
               return tweetBll.UpdateTweet(updatedTweet);
                
            }
            return false;
        }

        // DELETE: api/Tweet/5
        [HttpDelete]
        [Route("api/Tweet/{SessionId}/{tid}")]
        public bool Delete(string SessionId,int tid)
        {
            
            if (Session.Session.Validate(SessionId))
            {
                TweetBll tweetBll = new TweetBll();
                return tweetBll.DeleteTweet(Session.Session.Guid[SessionId],tid);
            }
            return false;
        }
    }
}
