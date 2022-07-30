using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Reopsitory
{
   public interface ILikeRepository
    {
        public bool createLike(LikeApi like);

        public bool deleteLike(int id);
        public List<LikeApi> getMyLikes();
    }
}
