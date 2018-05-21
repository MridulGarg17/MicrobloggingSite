using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;
namespace GlitterDll
{
    /// <summary>
    /// 
    /// </summary>
   public class EditConnections
    {
        private GlitterdbEntities glitterDb = new GlitterdbEntities();

        /// <summary>
        /// Follows the specified fId.
        /// </summary>
        /// <param name="Uid">The uid.</param>
        /// <param name="fId">The f identifier.</param>
        /// <returns></returns>
        public bool Follow(int Uid, int fId) {

            Connection relation = new Connection();
            var check = glitterDb.Connections.Where(i => i.Follower_id == Uid && i.Followee_id == fId).SingleOrDefault();
            if (check == null)
            {
                relation.Follower_id = Uid;
                relation.Followee_id = fId;
                glitterDb.Connections.Add(relation);
                glitterDb.SaveChanges();
                return true;
            }

            return false;
        }


        /// <summary>
        /// Unfollow the fid.
        /// </summary>
        /// <param name="uId">The u identifier.</param>
        /// <param name="fId">The f identifier.</param>
        /// <returns></returns>
        public bool UnFollowo(int uId, int fId) {
            var relation = glitterDb.Connections.Where(user => user.Follower_id == uId && user.Followee_id == fId).SingleOrDefault();
            if (relation != null)
            {
                glitterDb.Connections.Remove(relation);
                glitterDb.SaveChanges();
                return true;
            }

            return false;
        }

    }
}
