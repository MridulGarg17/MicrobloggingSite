using DTOs;
using GlitterBll;
using System.Collections.Generic;
using System.Web.Http;
namespace GlitterApi.Controllers
{
    
    public class ConnectionController : ApiController
    {


        [HttpGet]
        [Route("api/connection/followers/{SessionId}")]
        public IList<ConnectionDto> Followers(string SessionId)
        {
            if (Session.Session.Guid.ContainsKey(SessionId))
            {
                ConnectionBll connectionBll = new ConnectionBll();
                return connectionBll.GetFollower(Session.Session.Guid[SessionId]);
            }
            return null;
        }

        
        // GET: api/Connection
        [HttpGet]
        [Route("api/connection/followees/{Sessionid}")]
        public IList<ConnectionDto> Followees(string Sessionid)
        {
            if (Session.Session.Guid.ContainsKey(Sessionid))
            {
                ConnectionBll connectionBll = new ConnectionBll();
                return connectionBll.GetFollowee(Session.Session.Guid[Sessionid]);
            }
            return null;
        }

        // GET: api/Connection/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

         [HttpPost]
         [Route("api/connection/Follow")]
        public bool Follow(ConnectPersonDto connect) {
            
            if (Session.Session.Guid.ContainsKey(connect.sessionId))
            {
                ConnectionBll connectionBll = new ConnectionBll();
                return connectionBll.FollowUser(Session.Session.Guid[connect.sessionId], connect.fid);
            }
            return false;
        }

        [HttpPut]
        [Route("api/connection/Unfollow")]
        public bool UnFollow(ConnectPersonDto connect) {
           
            if (Session.Session.Guid.ContainsKey(connect.sessionId))
            {
                ConnectionBll connectionBll = new ConnectionBll();
                return connectionBll.UnfollowUser(Session.Session.Guid[connect.sessionId], connect.fid);
            }
            return false;
        }

        // POST: api/Connection
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Connection/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Connection/5
        public void Delete(int id)
        {
        }
    }
}
