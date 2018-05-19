using DTOs;
using GlitterDll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlitterBll
{
    class SearchBll
    {
        GetTweets getTweet;
        UserOperation operationOnUser;   
        public IList<TweetDto> SearchTweet(string tag) {
            getTweet = new GetTweets();
            return (getTweet.GetTagTweet(tag));
        }


        public IList<UserDto> SearchUser(string tag) {
            operationOnUser = new UserOperation();
            return (operationOnUser.SearchUser(tag));
        }
    }
}
