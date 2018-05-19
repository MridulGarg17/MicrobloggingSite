using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class PostTagMapDto
    {

        public int postId { get; set; }
        public IList<int> tagIdList { get; set; }

    }
}
