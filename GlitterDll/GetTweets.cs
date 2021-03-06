﻿using System.Collections.Generic;
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
            foreach (var personId in followeeList)
            {

                var result = glitterDb.Posts.Where(i => i.User_id == personId).ToList();
                var personName = (from i in glitterDb.Users where i.id == personId select i.Firstname).ToString();
                var person = glitterDb.Users.Where(i => i.id == personId).SingleOrDefault();
                personName = person.Firstname + person.Lastname;
                foreach (var item in result)
                {
                    tweetDetail = new TweetDto();

                    tweetDetail.id = item.id;
                    tweetDetail.Body = item.Body;
                    tweetDetail.User_id = item.User_id;
                    tweetDetail.User_name = personName;
                    tweetDetail.Created_at = item.Created_at;
                    tweetDetail.Like_count = item.Like_count;
                    tweetDetail.dislike_count = item.dislike_count;
                    //var react = (from post in glitterDb.PostReactions where post.id == item.id && post.user_id == uId select post.Reaction).SingleOrDefault();
                    var x = glitterDb.PostReactions.Where(i => i.Post_id == item.id && i.user_id == uId).SingleOrDefault();
                    if (x != null)
                        tweetDetail.reaction = x.Reaction;
                    else
                    {
                        tweetDetail.reaction = null;
                    }
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
            var hashTag = glitterDb.Tags.Where(id => id.text == tag).SingleOrDefault();


            if (hashTag != null)
            {
                hashTag.SearchCount = hashTag.SearchCount + 1;
                glitterDb.SaveChanges();

                int tagId = hashTag.id;
                //var tweets = glitterDb.Posts.Include(i => i.PostTagMaps.Where(id => id.Tag_id == tagId)).ToList();
                var tweets = glitterDb.PostTagMaps.Where(i => i.Tag_id == tagId).Include(i => i.Post).ToList();
                TweetDto tweetDetail;
                foreach (var item in tweets)
                {
                    tweetDetail = new TweetDto();

                    tweetDetail.id = item.Post.id;
                    tweetDetail.Body = item.Post.Body;
                    tweetDetail.User_id = item.Post.User_id;
                    tweetDetail.User_name = item.Post.User.Firstname;
                    tweetDetail.Created_at = item.Post.Created_at;
                    tweetDetail.Like_count = item.Post.Like_count;
                    tweetDetail.dislike_count = item.Post.dislike_count;

                    tweetList.Add(tweetDetail);
                }

            }
            else
            {
                tweetList = null;
            }
            return tweetList;
        }


        public int TotalTweet()
        {

            var count = glitterDb.Posts.Count(i => DbFunctions.TruncateTime( i.Created_at) == System.DateTime.Today);

            return count;
        }

        public TweetDto MostLiked()
        {

            var tweet = glitterDb.Posts.OrderByDescending(i => i.Like_count).ToList();
            TweetDto tweetDetail = new TweetDto();
            tweetDetail.id = tweet[0].id;
            tweetDetail.Body = tweet[0].Body;
            tweetDetail.Like_count = tweet[0].Like_count;
            tweetDetail.User_id = tweet[0].User_id;
            tweetDetail.dislike_count = tweet[0].dislike_count;
            tweetDetail.Created_at = tweet[0].Created_at;
            return tweetDetail;

        }

    }
}
