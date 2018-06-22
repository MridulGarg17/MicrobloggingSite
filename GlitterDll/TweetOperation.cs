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
            tweet.Like_count = 0;
            tweet.dislike_count = 0;
            tweet.Created_at = DateTime.Now;
            glitterDb.Posts.Add(tweet);
            glitterDb.SaveChanges();
           // var postId = glitterDb.Posts.Where(i => i.Created_at == tweet.Created_at).First().id;
            var postId = glitterDb.Posts.OrderByDescending(x => x.id).First().id;
            return postId;

        }

        public bool RemoveTweet(int uId,int tId) {
           
            var post = glitterDb.Posts.Where(i => i.id == tId).Single();
            var postreaction = glitterDb.PostReactions.Where(i => i.Post_id == tId).ToList();
            if (post.User_id == uId)
            {
                glitterDb.PostReactions.RemoveRange(postreaction);
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
            post.Created_at = DateTime.Now;
            glitterDb.SaveChanges();

        }

    }
}
