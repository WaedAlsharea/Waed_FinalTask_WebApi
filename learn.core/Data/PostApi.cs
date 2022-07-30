using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace learn.core.Data
{
    public class PostApi
    {
        [Key]
        public int postId { set; get; }
        public DateTime creationDate {set;get;}
        public string postText { set; get; }
        public int userId { set; get; }

    }
}
