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
    
    public class ConnectionController : ApiController
    {


        [HttpGet]
        [Route("api/connection/followers/{uid}")]
        public IList<ConnectionDto> Followers(int uid)
        {
            ConnectionBll connectionBll = new ConnectionBll();
            return connectionBll.GetFollower(uid);

        }

        
        // GET: api/Connection
        [HttpGet]
        [Route("api/connection/followees/{uid}")]
        public IList<ConnectionDto> Followees(int uid)
        {
            
            ConnectionBll connectionBll = new ConnectionBll();
            return connectionBll.GetFollowee(uid);
        }

        // GET: api/Connection/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

         [HttpPost]
         [Route("api/connection/Follow/{fId}")]
        public bool Follow(int fId) {
            int uid = 1;
            ConnectionBll connectionBll = new ConnectionBll();
            return connectionBll.FollowUser(uid, fId);
        }

        [HttpPut]
        [Route("api/connection/Unfollow/{fId}")]
        public bool UnFollow(int fid) {
            int uId = 1;
            ConnectionBll connectionBll = new ConnectionBll();
            return connectionBll.UnfollowUser(uId, fid);
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
