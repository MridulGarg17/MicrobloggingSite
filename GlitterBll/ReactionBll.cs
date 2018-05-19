using DTOs;
using GlitterDll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlitterBll
{
    class ReactionBll
    {
        ReactionOperation operationOnReaction;
        IList<UserDto> reactedUser;


        public IList<UserDto> GetReactedUser(int tweetId) {
            operationOnReaction = new ReactionOperation();
            reactedUser = new List<UserDto>();
            reactedUser = operationOnReaction.GetUsersWithReaction(tweetId);
            return reactedUser;

        }


        public void AddReaction() {


        }

    }
}
