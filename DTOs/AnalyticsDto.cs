using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class AnalyticsDto
    {
        public string MostTrending { get; set; }
        public int TotaltweetsDay { get; set; }
        public UserDto ActiveUser { get; set; }
        public TweetDto MostLiked { get; set; }

    }
}
