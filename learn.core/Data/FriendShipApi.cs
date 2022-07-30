using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace learn.core.Data
{
  public  class FriendShipApi
    {
        [Key]
        public int fshipId { set; get; }
        public int Is_Blocked { set; get; }

        public int requestId { set; get; }
        public int acceptId { set; get; }

    }
}
