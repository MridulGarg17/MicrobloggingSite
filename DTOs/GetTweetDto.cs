using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
   public class GetTweetDto
    {


        public int id { get; set; }
        public string Body { get; set; }
        public int User_id { get; set; }
        public string User_name { get; set; }
        public string Created_at { get; set; }
        public int? Like_count { get; set; }
        public int? dislike_count { get; set; }
        public string reaction { get; set; }
    }
}
