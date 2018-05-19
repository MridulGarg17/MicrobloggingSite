using DTOs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlitterDll
{
   public class ReactionOperation
    {
        private GlitterdbEntities glitterDb = new GlitterdbEntities();

        /// <summary>
        /// Adds the reaction.
        /// </summary>
        /// <param name="reaction">The reaction.</param>
        /// <returns></returns>
        public bool AddReaction(ReactionDto reaction) {

            var postReaction = glitterDb.PostReactions.Where(i => i.Post_id == reaction.Post_id && i.user_id == reaction.user_id).Single();

            if (postReaction != null)
            {

                if (reaction.Reaction == postReaction.Reaction)
                {
                    var post = glitterDb.Posts.Where(i => i.id == reaction.Post_id).Single();
                    if (reaction.Reaction)
                    {
                        post.Like_count = post.Like_count - 1;
                    }
                    else {
                        post.dislike_count = post.dislike_count - 1;
                    }
                    glitterDb.PostReactions.Remove(postReaction);
                    glitterDb.SaveChanges();
                }
                else
                {
                    postReaction.Reaction = reaction.Reaction;
                    updateReactionCount(reaction.Post_id, reaction.Reaction);
                    glitterDb.SaveChanges();

                }



                return true;
            }

            postReaction = new PostReaction();
            postReaction.Post_id = reaction.Post_id;
            postReaction.user_id = reaction.user_id;
            postReaction.Reaction = reaction.Reaction;
            glitterDb.PostReactions.Add(postReaction);
            glitterDb.SaveChanges();
            updateReactionCount(reaction.Post_id, reaction.Reaction);
            return true;

        }

        //public bool UpdateReaction(ReactionDto reaction) {

        //    var postReaction = glitterDb.PostReactions.Where(i => i.Post_id == reaction.Post_id && i.user_id == reaction.user_id).Single();

        //    if (postReaction != null) {

        //        if (reaction.Reaction == postReaction.Reaction)
        //        { 
        //            glitterDb.PostReactions.Remove(postReaction);
        //            glitterDb.SaveChanges();
        //        }
        //        else {
        //            postReaction.Reaction = reaction.Reaction;
        //            glitterDb.SaveChanges();

        //        }
        //        return true;
        //    }

        //    return false;

        //}

        /// <summary>
        /// Gets the users with reaction.
        /// </summary>
        /// <param name="postId">The post identifier.</param>
        /// <returns></returns>
        /// 

        public void updateReactionCount(int postId,bool reaction) {
            var post = glitterDb.Posts.Where(i => i.id==postId).Single();

            if (post != null) {
                if (reaction)
                {
                    post.Like_count = post.Like_count + 1;
                }
                else {
                    post.dislike_count = post.dislike_count + 1;
                }

                glitterDb.SaveChanges();
            }
        }


        public IList<UserDto> GetUsersWithReaction(int postId) {

            var user = glitterDb.Users.Include(i => i.PostReactions.Where(id => id.Post_id == postId)).ToList();

            UserDto userWithReaction = new UserDto();

            IList<UserDto> userList = new List<UserDto>();

            foreach (var u in user) {

                userWithReaction.Firstname = u.Firstname;
                userWithReaction.Lastname = u.Lastname;
                userWithReaction.Image = u.Image;

                userList.Add(userWithReaction);

            }


            return userList;
        }

    }
}
