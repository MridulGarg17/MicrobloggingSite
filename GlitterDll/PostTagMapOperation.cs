using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlitterDll
{
    
   public class PostTagMapOperation
    {
        private GlitterdbEntities glitterDb = new GlitterdbEntities();

        /// <summary>
        /// Adds the specified mapper.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <returns></returns>
        public int Add(PostTagMapDto mapper) {
            PostTagMap map = new PostTagMap();
           int postId = mapper.postId;
            map.Post_id = postId;
            foreach (var item in mapper.tagIdList) {
                map.Tag_id = item;
                glitterDb.PostTagMaps.Add(map);
            }
            glitterDb.SaveChanges();
            return 0;
        }

        /// <summary>
        /// Removes the specified post identifier.
        /// </summary>
        /// <param name="postId">The post identifier.</param>
        /// <returns></returns>
        public int Remove(int postId) {

            var post = glitterDb.PostTagMaps.Where(id => id.Post_id == postId).ToList();
            glitterDb.PostTagMaps.RemoveRange(post);
            glitterDb.SaveChanges();

            return 0;
        }

        /// <summary>
        /// Updates the specified post identifier.
        /// </summary>
        /// <param name="postId">The post identifier.</param>
        /// <param name="newList">The new list.</param>
        /// <returns></returns>
        public int Update(int postId,IList<int> newList) {
            Remove(postId);
            PostTagMapDto newPost = new PostTagMapDto();
            newPost.postId = postId;
           newPost.tagIdList = newList;
            Add(newPost);
            return 0;
        }

        public IList<int> RetrieveTagId(int postId) {

            var tags = glitterDb.PostTagMaps.Where(i => i.Post_id == postId).ToList();
            IList<int> tagIds = new List<int>();
            foreach (var i in tags) {
                tagIds.Add(i.Tag_id);
            }
            return tagIds;
        }

    }
}
