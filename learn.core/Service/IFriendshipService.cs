using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Service
{
  public  interface IFriendshipService
    {
        public bool createFriendship(FriendShipApi friend);

        public bool deleteFriendship(int id);
        public List<FriendShipApi> getFriendship();
        public bool BlockUser(FriendShipApi friend, int blockerId);


    }
}
