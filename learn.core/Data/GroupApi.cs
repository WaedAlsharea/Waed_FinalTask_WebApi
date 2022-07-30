using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace learn.core.Data
{
 public  class GroupApi
    {
        [Key]

        public int groupId { set; get; }
        public string groupName { set; get; }
        public DateTime creationDate { set; get; }
        public int adminGroup { set; get; }

    }
}
