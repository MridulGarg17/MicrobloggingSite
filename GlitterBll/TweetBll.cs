using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlitterDll;
namespace GlitterBll
{
    public class TweetBll
    {
        
        private TweetOperation operationOnTweet;
        private GetTweets getTweets;
        private HashTags operationOnTag;
        private PostTagMapOperation mapper;

        public IList<TweetDto> tweetList;
        private List<string> tagList = new List<string>();
        private IList<int> tagId = new List<int>();

        public bool AddTweet(TweetDto newTweet) {

            operationOnTweet = new TweetOperation();
            operationOnTag = new HashTags();
            int tweetId;
            newTweet.Body = newTweet.Body.Trim();
            if (string.IsNullOrEmpty(newTweet.Body)) {
                return false;
            }
            tweetId = operationOnTweet.AddTweet(newTweet);

            tagList = SplitTweet(newTweet.Body);
            tagId = operationOnTag.AddHashTag(tagList);
            TweetTagMap(tweetId, tagId);
            return true;
        }

        public IList<GetTweetDto> GetAllTweet(int userId) {
            GetTweetDto tweet ;
            getTweets = new GetTweets();
            tweetList = new List<TweetDto>();
            IList<GetTweetDto> allTweets = new List<GetTweetDto>(); 
            tweetList = getTweets.GetAllTweets(userId);
            foreach (var i in tweetList) {
                tweet = new GetTweetDto();
                tweet.id = i.id;
                tweet.Body = i.Body;
                tweet.User_id = i.User_id;
                tweet.User_name = i.User_name;
                tweet.Like_count = i.Like_count;
                tweet.dislike_count = i.dislike_count;
                tweet.Created_at = i.Created_at.ToShortDateString().ToString();
                if (i.reaction == true)
                {
                    tweet.reaction = "Liked";
                }
                else if (i.reaction == false)
                {
                    tweet.reaction = "Disliked";
                }
                else {
                    tweet.reaction = "not reacted";
                }

                allTweets.Add(tweet);
            }
            
           // tweetList.Sort((obj1, obj2) => DateTime.Compare(obj2.CreatedAt, obj1.CreatedAt));
            //tweetList.OrderByDescending(f => f.id);
            IList<GetTweetDto> x = allTweets.OrderByDescending(i => i.id).ToList();
            return x;
        }

        public bool UpdateTweet(TweetDto newTweet) {

            operationOnTweet = new TweetOperation();
            operationOnTag = new HashTags();
            mapper = new PostTagMapOperation();
            newTweet.Body = newTweet.Body.Trim();
            tagList = SplitTweet(newTweet.Body);
            if (string.IsNullOrEmpty(newTweet.Body))
            {
                return false;
            }
            tagId = mapper.RetrieveTagId(newTweet.id);
            mapper.Remove(newTweet.id);
            operationOnTag.RemoveHashtag(tagId);
            tagId = operationOnTag.AddHashTag(tagList);
            operationOnTweet.EditTweet(newTweet);
            TweetTagMap(newTweet.id, tagId);
            return true;

        }

        public bool DeleteTweet(int uId,int tweetId) {

            mapper = new PostTagMapOperation();
            operationOnTweet = new TweetOperation();
            operationOnTag = new HashTags();

            tagId = mapper.RetrieveTagId(tweetId);
            mapper.Remove(tweetId);
            operationOnTag.RemoveHashtag(tagId);
            return operationOnTweet.RemoveTweet(uId,tweetId);



        }

        public List<string> SplitTweet(string tweetBody) {
            
            string[] splitOnSpace = tweetBody.Split(' ');
            HashSet<string> hashTags = new HashSet<string>();
            for (int i = 0; i < splitOnSpace.Length; i++) {

                if (splitOnSpace[i][0] == '#'&&splitOnSpace[i].Length>1)
                {
                    hashTags.Add(splitOnSpace[i].Substring(1, splitOnSpace[i].Length-1));
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
