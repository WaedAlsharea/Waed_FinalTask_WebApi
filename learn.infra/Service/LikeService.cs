using learn.core.Data;
using learn.core.Reopsitory;
using learn.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.Service
{
   public class LikeService : ILikeService
    {
        private readonly ILikeRepository repository;
        public LikeService(ILikeRepository repository)
        {
            this.repository = repository;
        }

        public bool createLike(LikeApi like)
        {
            return this.repository.createLike(like);
        }

        public bool deleteLike(int id)
        {
            return this.repository.deleteLike(id);
        }

        public List<LikeApi> getMyLikes()
        {
            return this.repository.getMyLikes();
        }
    }
}
