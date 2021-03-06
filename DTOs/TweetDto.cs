﻿
using System.ComponentModel.DataAnnotations;

namespace DTOs
{
   
    public class TweetDto
    {
        
        public int id { get; set; }
        [Required]
        public string Body { get; set; }
        [Required]
        public int User_id { get; set; }
        public string User_name { get; set; }
        public System.DateTime Created_at { get; set; }
        public int? Like_count { get; set; }
        public int? dislike_count { get; set; }
        public bool? reaction { get; set; }
        [Required]
        public string SessionId { get; set; }
    }
}
