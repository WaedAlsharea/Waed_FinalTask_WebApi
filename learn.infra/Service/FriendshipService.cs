using learn.core.Data;
using learn.core.Repository;
using learn.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.Service
{
   public class FriendshipService : IFriendshipService

    {
        private readonly IFriendshipRepository repository;
        public FriendshipService(IFriendshipRepository repository)
        {
            this.repository = repository;
        }

        public bool createFriendship(FriendShipApi friend)
        {
           return this.repository.createFriendship(friend);
        }

        public bool deleteFriendship(int id)
        {
            return this.repository.deleteFriendship(id);
        }

        public List<FriendShipApi> getFriendship()
        {
            return this.repository.getFriendship();
        }
        public bool BlockUser(FriendShipApi friend, int blockerId)
        {
            return this.repository.BlockUser(friend, blockerId);

        }

    }
}
