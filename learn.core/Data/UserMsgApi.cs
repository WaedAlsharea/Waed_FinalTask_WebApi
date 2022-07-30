using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace learn.core.Data
{
    public class UserMsgApi
    {
        public object userId;

        [Key]
        public int umsgId { set; get; }
        public string msgText { set; get; }
        public string msgDate { set; get; }

        public int senderId { set; get; }
        public int reciverId { set; get; }

    }
}
