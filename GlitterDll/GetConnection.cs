using System.Collections.Generic;
using System.Linq;
using DTOs;
using System.Data.Entity;

namespace GlitterDll
{
   public class GetConnection
    {
        private GlitterdbEntities glitterDb = new GlitterdbEntities();

        IList<ConnectionDto> connectionList = new List<ConnectionDto>();

        /// <summary>
        /// Gets the follower of the logged-in user.
        /// </summary>
        /// <param name="uId">The u identifier.</param>
        /// <returns></returns>
        public IList<ConnectionDto> GetFollower(int uId) {

            //var list = glitterDb.Users.Include(follower => follower.Connections.Where(i => i.Followee_id == uId)).ToList();
           // var list = glitterDb.Users.Include(i => i.Connections).Where(i => i.id == uId).ToList();
            var list = glitterDb.Connections.Where(i => i.Followee_id == uId).Include(i => i.User).ToList();
            ConnectionDto user;
            if (list.Count > 0)
            {
                foreach (var follower in list)
                {
                    
                    
                        user = new ConnectionDto();
                        user.id = follower.Follower_id;
                        user.Firstname = follower.User1.Firstname;
                        user.Lastname = follower.User1.Lastname;
                        user.image = follower.User1.Image;
                        connectionList.Add(user);

                    
                }
            }
            else {
                list = null;
            }

            return connectionList;

        }

        /// <summary>
        /// return the list of users whome the logedin user is following.
        /// </summary>
        /// <param name="uId">The u identifier.</param>
        /// <returns></returns>
        public IList<ConnectionDto> GetFollowee(int uId) {

            // var list = glitterDb.Users.Include(followee => followee.Connections.Where(i => i.Follower_id == uId)).ToList();

            var list = glitterDb.Connections.Where(i => i.Follower_id == uId).Include(i => i.User).ToList();

            ConnectionDto user;
            if (list.Count > 0)
            {
                foreach (var followee in list)
                {
                    user = new ConnectionDto();
                    user.id = followee.Followee_id;
                    user.Firstname = followee.User.Firstname;
                    user.Lastname = followee.User.Lastname;
                    user.image = followee.User.Image;

                    connectionList.Add(user);
                }
            }
            else
            {
                list = null;
            }

            return connectionList;
        }

    }
}
