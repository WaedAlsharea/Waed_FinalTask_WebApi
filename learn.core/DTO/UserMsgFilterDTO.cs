using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.DTO
{
   public class UserMsgFilterDTO
    {
      
        public string Sender { set; get; }
        public DateTime MsgDate { set; get; }
        public string Message { set; get; }
    }
}
