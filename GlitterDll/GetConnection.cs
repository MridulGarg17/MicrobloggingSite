using System.Collections.Generic;
using System.Linq;
using DTOs;
using System.Data.Entity;

namespace GlitterDll
{
    class GetConnection
    {
        private GlitterdbEntities glitterDb = new GlitterdbEntities();

        IList<ConnectionDto> connectionList = new List<ConnectionDto>();

        /// <summary>
        /// Gets the follower of the logged-in user.
        /// </summary>
        /// <param name="uId">The u identifier.</param>
        /// <returns></returns>
        public IList<ConnectionDto> GetFollower(int uId) {

            var list = glitterDb.Users.Include(follower => follower.Connections.Where(i => i.Followee_id == uId)).ToList();
            ConnectionDto user;
            if (list.Count > 0)
            {
                foreach (var follower in list)
                {
                    user = new ConnectionDto();
                    user.id = follower.id;
                    user.Firstname = follower.Firstname;
                    user.Lastname = follower.Lastname;
                    user.image = follower.Image;

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

            var list = glitterDb.Users.Include(followee => followee.Connections.Where(i => i.Follower_id == uId)).ToList();
            ConnectionDto user;
            if (list.Count > 0)
            {
                foreach (var followee in list)
                {
                    user = new ConnectionDto();
                    user.id = followee.id;
                    user.Firstname = followee.Firstname;
                    user.Lastname = followee.Lastname;
                    user.image = followee.Image;

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
