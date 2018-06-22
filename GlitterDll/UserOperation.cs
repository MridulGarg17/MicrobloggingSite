using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Services;

namespace GlitterDll
{
   public class UserOperation
    {
        private GlitterdbEntities glitteDb = new GlitterdbEntities();

        /// <summary>
        /// Signups the specified new user.
        /// </summary>
        /// <param name="newUser">The new user.</param>
        /// <returns></returns>
        public bool Signup(SignupDto newUser) {
            User user = new User();

            var checkUser = glitteDb.Users.Where(i => i.Email == newUser.Email).SingleOrDefault();
            try
            {
                if (checkUser == null)
                {

                    user.Firstname = newUser.Firstname;
                    user.Lastname = newUser.Lastname;
                    user.Image = newUser.Image;
                    user.Country_id = newUser.Country_id;
                    user.Email = newUser.Email;
                    user.Password = newUser.Password;
                    user.Phone = newUser.Phone;
                    glitteDb.Users.Add(user);
                    glitteDb.SaveChanges();
                    return true;
                }
            }
            catch(Exception) {
                return false;
            }
            return false;
        }

        /// <summary>
        /// Signins the specified user request.
        /// </summary>
        /// <param name="userRequest">The user request.</param>
        /// <returns></returns>
        /// 
        
        public UserDto Signin(LoginDto userRequest) {

            var user = glitteDb.Users.Where(i => i.Email == userRequest.Email).SingleOrDefault();
            UserDto userIn = new UserDto();
            try
            {
                if (user != null)
                {

                    if (user.Password == userRequest.Password)
                    {
                        userIn.id = user.id;
                        userIn.Firstname = user.Firstname;
                        userIn.Lastname = user.Lastname;
                        userIn.Image = user.Image;
                        return userIn;
                    }
                    else
                    {
                        return userIn;
                    }
                }
            }
            catch (Exception) {
                return null;
            }
            return userIn;
        }


        public IList<UserDto> SearchUser(string tag,int uid) {
            var users = glitteDb.Users.Where(i => i.Firstname == tag || i.Lastname == tag).ToList();
            IList<UserDto> searchedUsers = new List<UserDto>();
            UserDto person = new UserDto();
            if (users == null) {
                return null;
            }

            List<int> l = new List<int>();

            var x = glitteDb.Connections.Where(i => i.Follower_id == uid).ToList();

            foreach (var i in x) {
                l.Add(i.Followee_id);
            }

            foreach (var user in users) {
                person.id = user.id;
                person.Firstname = user.Firstname;
                person.Lastname = user.Lastname;
                person.Image = user.Image;
                if (l.Contains(user.id)) {
                    person.following = true;
                }
                else
                {
                    person.following = false;
                }

                searchedUsers.Add(person);
            }
            return searchedUsers;
        }

        public UserDto MostTweetPerson() {
            int j=0;
            var personId = glitteDb.Posts.GroupBy(u => u.User_id).OrderByDescending(grp => grp.Count()).Take(1)
                .Select(g => g).ToList();
            foreach (var p in personId) {
                foreach (var x in p) {
                     j = x.User_id;
                    break;
                }
            }
            var person = glitteDb.Users.Where(user => user.id == j).SingleOrDefault();
            UserDto userDetail = new UserDto();
            userDetail.id = person.id;
            userDetail.Firstname = person.Firstname;
            userDetail.Lastname = person.Lastname;
            userDetail.Image = person.Image;
            return (userDetail);
            
        }
    }
}
