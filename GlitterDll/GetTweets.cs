using System.Collections.Generic;
using System.Linq;
using DTOs;
using System.Data.Entity;

namespace GlitterDll
{
    public class GetTweets
    {
        private GlitterdbEntities glitterDb = new GlitterdbEntities();

        IList<TweetDto> tweetList = new List<TweetDto>();

        /// <summary>
        /// Gets all tweets of user and his/her followee.
        /// </summary>
        /// <param name="uId">The u identifier.</param>
        /// <returns></returns>
        public IList<TweetDto> GetAllTweets(int uId)
        {

            var followeeList = (from i in glitterDb.Connections where i.Follower_id == uId select i.Followee_id).ToList();
            followeeList.Add(uId);
            TweetDto tweetDetail;
            foreach (var user in followeeList)
            {

                var result = glitterDb.Posts.Where(i => i.User_id == uId).ToList();
                
                foreach (var item in result)
                {
                    tweetDetail = new TweetDto();

                    tweetDetail.id = item.id;
                    tweetDetail.Body = item.Body;
                    tweetDetail.User_id = item.User_id;
                    tweetDetail.Created_at = item.Created_at;
                    tweetDetail.Like_count = item.Like_count;
                    tweetDetail.dislike_count = item.dislike_count;

                    tweetList.Add(tweetDetail);

                }
            }
            return tweetList;
        }

        /// <summary>
        /// function return the tweets having given tag
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <returns></returns>
        public IList<TweetDto> GetTagTweet(string tag)
        {
            var hashTag = glitterDb.Tags.Where(id => id.text == tag).Single();

            if (hashTag != null)
            {
                int tagId = hashTag.id;
                var tweets = glitterDb.Posts.Include(i => i.PostTagMaps.Where(id => id.Tag_id == tagId)).ToList();
                TweetDto tweetDetail;
                foreach (var item in tweets)
                {
                    tweetDetail = new TweetDto();

                    tweetDetail.id = item.id;
                    tweetDetail.Body = item.Body;
                    tweetDetail.User_id = item.User_id;
                    tweetDetail.Created_at = item.Created_at;
                    tweetDetail.Like_count = item.Like_count;
                    tweetDetail.dislike_count = item.dislike_count;

                    tweetList.Add(tweetDetail);
                }

            }
            else
            {
                tweetList = null;
            }
            return tweetList;
        }

    }
}
