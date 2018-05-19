using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlitterDll
{
    
    class PostTagMapOperation
    {
        private GlitterdbEntities glitterDb = new GlitterdbEntities();

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

        public int Remove(int postId) {

            var post = glitterDb.PostTagMaps.Where(id => id.Post_id == postId).ToList();
            glitterDb.PostTagMaps.RemoveRange(post);
            glitterDb.SaveChanges();

            return 0;
        }

        public int Update(int postId,IList<int> newList) {
            Remove(postId);
            PostTagMapDto newPost = new PostTagMapDto();
            newPost.postId = postId;
           newPost.tagIdList = newList;
            Add(newPost);
            return 0;


        }


    }
}
