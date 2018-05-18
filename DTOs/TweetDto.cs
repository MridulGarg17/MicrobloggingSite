
namespace DTOs
{
   
    public class TweetDto
    {
        
        public int id { get; set; }
        public string Body { get; set; }
        public int User_id { get; set; }
        public byte[] Created_at { get; set; }
        public int? Like_count { get; set; }
        public int? dislike_count { get; set; }

    }
}
