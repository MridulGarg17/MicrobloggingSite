using DTOs;
using GlitterDll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlitterBll
{
    class AnalyticsBll
    {
        HashTags hashTag;
        GetTweets getTweet = new GetTweets();
        UserOperation mostActive;
       

        public string MostTrending() {
            hashTag = new HashTags();
            return(hashTag.MostTrending());
        }

        public int TotalTweetsDay() {
            
            return (getTweet.TotalTweet());
        }

        public string MostTweetByPerson() {
            mostActive = new UserOperation();
            return (mostActive.MostTweetPerson());
        }

        public TweetDto MostLiked() {
            return (getTweet.MostLiked());
        }

        

    }
}
