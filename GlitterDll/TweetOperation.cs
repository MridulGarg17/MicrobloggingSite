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
            tweet.Created_at = newTweet.Created_at;
            glitterDb.Posts.Add(tweet);
            glitterDb.SaveChanges();
            var postId = glitterDb.Posts.Where(i => i.Created_at == tweet.Created_at).Single().id;
           // var postId = glitterDb.Posts.OrderByDescending(x => x.id).First().id;
            return postId;

        }

        public void RemoveTweet(int tId) {

            var post = glitterDb.Posts.Where(i => i.id == tId).Single();
            glitterDb.Posts.Remove(post);
            glitterDb.SaveChanges();

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
