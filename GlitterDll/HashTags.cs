﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlitterDll
{
    public class HashTags
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
                var check = glitterDb.Tags.Where(i => i.text == s).SingleOrDefault();

                if (check != null)
                {
                    check.count = check.count + 1;
                    glitterDb.SaveChanges();
                }
                else
                {

                    newTag.text = s;
                    newTag.count = 1;
                    newTag.SearchCount = 0;
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
        public bool RemoveHashtag(IList<int> tagList)
        {
           // IList<int> idList = new List<int>();

            foreach (int s in tagList)
            {

                var tag = glitterDb.Tags.Where(i => i.id == s).Single();
                //int tagId = tag.id;
               // idList.Add(tagId);
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

            return true;
        }


        public string MostTrending() {

            var hashTag = glitterDb.Tags.OrderByDescending(x => x.SearchCount).ThenByDescending(i => i.count).ToList();
            return (hashTag[0].text);

        }
    }
}
