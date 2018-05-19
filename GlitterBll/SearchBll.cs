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

        /// <summary>
        /// Searches the tweet.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <returns></returns>
        public IList<TweetDto> SearchTweet(string tag) {
            getTweet = new GetTweets();
            return (getTweet.GetTagTweet(tag));
        }

        /// <summary>
        /// Searches the user.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <returns></returns>
        public IList<UserDto> SearchUser(string tag) {
            operationOnUser = new UserOperation();
            return (operationOnUser.SearchUser(tag));
        }
    }
}
