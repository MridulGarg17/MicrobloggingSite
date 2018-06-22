using DTOs;
using GlitterDll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlitterBll
{
     public class SearchBll
    {
        GetTweets getTweet;
        UserOperation operationOnUser;

        /// <summary>
        /// Searches the tweet.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <returns></returns>
        public IList<GetTweetDto> SearchTweet(string tag) {
            getTweet = new GetTweets();
            GetTweetDto tweet;
            IList<GetTweetDto> allTweets = new List<GetTweetDto>();
            IList<TweetDto> searchedtweet = getTweet.GetTagTweet(tag);
            if (searchedtweet == null) {
                return null;
            }
            foreach (var i in searchedtweet)
            {
                tweet = new GetTweetDto();
                tweet.id = i.id;
                tweet.Body = i.Body;
                tweet.User_id = i.User_id;
                tweet.User_name = i.User_name;
                tweet.Like_count = i.Like_count;
                tweet.dislike_count = i.dislike_count;
                tweet.Created_at = i.Created_at.ToShortDateString().ToString();
                if (i.reaction == true)
                {
                    tweet.reaction = "Liked";
                }
                else if (i.reaction == false)
                {
                    tweet.reaction = "Disliked";
                }
                else
                {
                    tweet.reaction = "not reacted";
                }

                allTweets.Add(tweet);
            }
            return allTweets;
        }

        /// <summary>
        /// Searches the user.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <returns></returns>
        public IList<UserDto> SearchUser(string tag,int uid) {
            operationOnUser = new UserOperation();
            return (operationOnUser.SearchUser(tag,uid));
        }
    }
}
