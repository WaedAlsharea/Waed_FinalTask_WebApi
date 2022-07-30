using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace learn.core.Data
{
  public   class CommentApi
    {
        [Key]

        public int commentId { set; get; }
        public DateTime creationdate { set; get; }
        public string commenText { set; get; }
        public int userId { set; get; }
        public int postId { set; get; }


    }
}
