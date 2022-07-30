using learn.core.Data;
using learn.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Service
{
   public interface IPostService
    {
        public bool createPost(PostApi post);

        public bool deletePost(int id);
        public List<PostApi> getMyPosts();
        public bool updatePost(PostApi post, int id);
        public List<PostLikeCountDTO> LikesCount();

    }
}
