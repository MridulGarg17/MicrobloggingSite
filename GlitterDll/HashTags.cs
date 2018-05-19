using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlitterDll
{
    internal class HashTags
    {
        private GlitterdbEntities glitterDb = new GlitterdbEntities();

        /// <summary>
        /// Adds the hash tag.
        /// </summary>
        /// <param name="tagList">The tag list.</param>
        /// <returns></returns>
        public IList<int> AddHashTag(IList<string> tagList)
        {
            Tag newTag;
            IList<int> idList = new List<int>();
            foreach (string s in tagList)
            {

                newTag = new Tag();
                var check = glitterDb.Tags.Where(i => i.text == s).Single();

                if (check != null)
                {
                    check.count = check.count + 1;
                    glitterDb.SaveChanges();
                }
                else
                {

                    newTag.text = s;
                    newTag.count = 1;
                    glitterDb.Tags.Add(newTag);
                    glitterDb.SaveChanges();
                }
            }

            foreach (string s in tagList)
            {
                var tag = glitterDb.Tags.Where(i => i.text == s).Single();
                idList.Add(tag.id);
            }

            return idList;
        }


        /// <summary>
        /// Removes the hashtag.
        /// </summary>
        /// <param name="tagList">The tag list.</param>
        /// <returns></returns>
        public IList<int> RemoveHashtag(IList<string> tagList)
        {
            IList<int> idList = new List<int>();

            foreach (string s in tagList)
            {

                var tag = glitterDb.Tags.Where(i => i.text == s).Single();
                int tagId = tag.id;
                idList.Add(tagId);
                if (tag.count == 1)
                {
                    glitterDb.Tags.Remove(tag);
                    glitterDb.SaveChanges();
                }
                else
                {
                    tag.count = tag.count - 1;
                }

            }

            return idList;
        }

    }
}
