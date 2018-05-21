using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;

namespace GlitterDll
{
   public class TweetOperation
    {
        private GlitterdbEntities glitterDb = new GlitterdbEntities();
        


        public int AddTweet(TweetDto newTweet) {
            Post tweet = new Post();

            tweet.Body = newTweet.Body;
            tweet.User_id = newTweet.User_id;
            tweet.Like_count = newTweet.Like_count;
            tweet.dislike_count = newTweet.dislike_count;
            tweet.Created_at = DateTime.Now;
            glitterDb.Posts.Add(tweet);
            glitterDb.SaveChanges();
           // var postId = glitterDb.Posts.Where(i => i.Created_at == tweet.Created_at).First().id;
            var postId = glitterDb.Posts.OrderByDescending(x => x.id).First().id;
            return postId;

        }

        public bool RemoveTweet(int tId) {
            int uId = 1;
            var post = glitterDb.Posts.Where(i => i.id == tId).Single();
            if (post.User_id == uId)
            {
                glitterDb.Posts.Remove(post);
                glitterDb.SaveChanges();
                return true;
            }

            return false;

        }

        public void EditTweet(TweetDto updateTweet) {
            int postId = updateTweet.id;
            var post = glitterDb.Posts.Where(id => id.id == postId).Single();
            post.Body = updateTweet.Body;
            post.Created_at = updateTweet.Created_at;
            glitterDb.SaveChanges();

        }

    }
}
