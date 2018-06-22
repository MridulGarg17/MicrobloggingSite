using DTOs;
using GlitterDll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlitterBll
{
    public class AnalyticsBll
    {
        HashTags hashTag;
        GetTweets getTweet = new GetTweets();
        UserOperation mostActive;

        public AnalyticsDto Analytic() {
            AnalyticsDto bonus = new AnalyticsDto();
            bonus.MostTrending= MostTrending();
            bonus.MostLiked = MostLiked();
            bonus.ActiveUser = MostTweetByPerson();
            bonus.TotaltweetsDay = TotalTweetsDay();
            return bonus;
        }

        private string MostTrending() {
            hashTag = new HashTags();
            return(hashTag.MostTrending());
        }

        private int TotalTweetsDay() {
            
            return (getTweet.TotalTweet());
        }

        private UserDto MostTweetByPerson() {
            mostActive = new UserOperation();
            return (mostActive.MostTweetPerson());
        }

        private TweetDto MostLiked() {
            return (getTweet.MostLiked());
        }

        

    }
}
