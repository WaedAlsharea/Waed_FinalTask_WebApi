using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace learn.core.Data
{
   public  class UserGroupApi
    {
        [Key]
        public int ugroupId { set; get; }
        public int groupId { set; get; }
        public int userId { set; get; }


    }
}
