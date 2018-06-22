using DTOs;
using GlitterBll;
using System.Collections.Generic;
using System.Web.Http;
using GlitterApi.Session;
using System.IO;

namespace GlitterApi.Controllers
{
    public class UserController : ApiController
    {
        // GET: api/User
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/User/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        [Route("api/user/login")]
        public NewSessionDto login(LoginDto loggedData)
        {
            if (ModelState.IsValid)
            {


                UserBll userBll = new UserBll();
                int id = userBll.Login(loggedData).id;
                if (id > 0 && !Session.Session.Guid.ContainsValue(id))
                {
                    Session.Session session = new Session.Session();
                    NewSessionDto NewSession = new NewSessionDto();
                    NewSession.userId = id;
                    NewSession.SessionId = session.CreateSession(id);
                    return NewSession;
                }
                NewSessionDto newSession = new NewSessionDto();
                newSession.userId = 0;
                newSession.SessionId = null;
                return newSession;
            }

            NewSessionDto empty = new NewSessionDto();
            empty.userId = 0;
            empty.SessionId = null;
            return empty;
        }


        [HttpPost]
        [Route("api/user/signup")]
        public bool Signup(SignupDto userData) {
           

                if (ModelState.IsValid)
            {
                UserBll userBll = new UserBll();
                return userBll.Signup(userData);
            }
            return false;

        }

        [HttpGet]
        [Route("api/user/country")]
        public IList<CountryDto> Country() {
            CountryBll countryBll = new CountryBll();
            return countryBll.getCountryList();

        }

        [HttpGet]
        [Route("api/user/logout/{sessionId}")]
        public bool logout(string sessionId) {
            if (Session.Session.Guid.ContainsKey(sessionId)) {
                new Session.Session().DestroySession(sessionId);
                return true;
            }
            return false;
        }

        // POST: api/User
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
