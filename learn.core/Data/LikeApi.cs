using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace learn.core.Data
{
  public class LikeApi
    {
        [Key]

        public int likeId { set; get; }
        public int userId { set; get; }
        public int postId { set; get; }

    }
}
