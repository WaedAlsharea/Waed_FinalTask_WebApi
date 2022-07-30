using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.DTO
{
    public class MsgsBackUpDTO
    {
        public string Sender { set; get; }
        public string Message { set; get; }
        public DateTime MessageDate { set; get; }
        public string Reciver { set; get; }
    }
}
