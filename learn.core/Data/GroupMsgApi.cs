using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace learn.core.Data
{
    public class GroupMsgApi
    {
        [Key]
        public int gmsgId { set; get; }
        public string msgText { set; get; }
        public int senderId { set; get; }
        public int groupId { set; get; }

    }
}
