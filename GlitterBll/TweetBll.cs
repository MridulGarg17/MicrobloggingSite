using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlitterDll;
namespace GlitterBll
{
    class TweetBll
    {
        private TweetOperation operationOnTweet;
        private GetTweets getTweets;
        private HashTags operationOnTag;
        private PostTagMapOperation mapper;

        public IList<TweetDto> tweetList;
        private List<string> tagList = new List<string>();
        private IList<int> tagId = new List<int>();

        public void AddTweet(TweetDto newTweet) {

            operationOnTweet = new TweetOperation();
            operationOnTag = new HashTags();
            int tweetId;
            tweetId = operationOnTweet.AddTweet(newTweet);

            tagList = SplitTweet(newTweet.Body);
            tagId = operationOnTag.AddHashTag(tagList);
            TweetTagMap(tweetId, tagId);

        }

        public void GetAllTweet(int userId) {

            getTweets = new GetTweets();
            tweetList = new List<TweetDto>();
            tweetList = getTweets.GetAllTweets(userId);

        }

        public void UpdateTweet(TweetDto newTweet) {

            operationOnTweet = new TweetOperation();
            operationOnTag = new HashTags();
            mapper = new PostTagMapOperation();

            tagList = SplitTweet(newTweet.Body);

            tagId = mapper.RetrieveTagId(newTweet.id);
            mapper.Remove(newTweet.id);
            operationOnTag.RemoveHashtag(tagId);
            tagId = operationOnTag.AddHashTag(tagList);
            TweetTagMap(newTweet.id, tagId);
           

        }

        public void DeleteTweet(int tweetId) {

            mapper = new PostTagMapOperation();
            operationOnTweet = new TweetOperation();
            operationOnTag = new HashTags();

            tagId = mapper.RetrieveTagId(tweetId);
            mapper.Remove(tweetId);
            operationOnTag.RemoveHashtag(tagId);
            operationOnTweet.RemoveTweet(tweetId);



        }

        public List<string> SplitTweet(string tweetBody) {

            string[] splitOnSpace = tweetBody.Split(' ');
            HashSet<string> hashTags = new HashSet<string>();
            for (int i = 0; i < splitOnSpace.Length; i++) {

                if (splitOnSpace[i][0] == '#')
                {
                    hashTags.Add(splitOnSpace[i].Substring(1, splitOnSpace[i].Length));
                }
                else {
                    continue;
                }

            }

             tagList = hashTags.ToList();

            return tagList;
        }

        public void TweetTagMap(int tweetId,IList<int> tagIdParam) {
            mapper = new PostTagMapOperation();
            PostTagMapDto mapperDto = new PostTagMapDto();
            mapperDto.postId = tweetId;
            mapperDto.tagIdList = tagIdParam;
            mapper.Add(mapperDto);

        }

    }
}
