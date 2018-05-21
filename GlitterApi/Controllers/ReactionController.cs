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
    public class ReactionController : ApiController
    {
        // GET: api/Reaction
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Reaction/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet]
        [Route("api/reaction/allusers/{tweetId}")]
        public IList<UserDto> GetAllUser(int tweetId) {
            ReactionBll reactionBll = new ReactionBll();
            return reactionBll.GetReactedUser(tweetId);
        }

        // POST: api/Reaction
        public bool Post(ReactionDto reaction)
        {
            ReactionBll reactionBll = new ReactionBll();
            return reactionBll.AddReaction(reaction);
        }

        // PUT: api/Reaction/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Reaction/5
        public void Delete(int id)
        {
        }
    }
}
