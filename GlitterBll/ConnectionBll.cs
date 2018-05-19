using DTOs;
using GlitterDll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlitterBll
{


    class ConnectionBll
    {
        EditConnections editConnection;
        GetConnection getConnection;
        IList<ConnectionDto> connectionlist;


        public IList<ConnectionDto> GetFollower(int userId) {

            getConnection = new GetConnection();
            connectionlist = getConnection.GetFollower(userId);
            return connectionlist;

        }

        public IList<ConnectionDto> GetFollowee(int userId) {

            getConnection = new GetConnection();
            connectionlist = getConnection.GetFollowee(userId);
            return connectionlist;
        }

        public bool FollowUser(int userId, int followeeId) {
            editConnection = new EditConnections();
            return (editConnection.Follow(userId, followeeId));

            
        } 

        public bool UnfollowUser(int userId, int followeeId) {
            editConnection = new EditConnections();
            return (editConnection.UnFollowo(userId, followeeId));

        }

    }
}
