using learn.core.Data;
using learn.core.DTO;
using learn.core.Reopsitory;
using learn.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.Service
{
  public  class PostService : IPostService
    {
        private readonly IPostRepository repository;
        public PostService(IPostRepository repository)
        {
            this.repository = repository;
        }

        public bool createPost(PostApi post)
        {
            return this.repository.createPost(post);
        }

        public bool deletePost(int id)
        {
            return this.repository.deletePost(id);
        }

        public List<PostApi> getMyPosts()
        {
            return this.repository.getMyPosts();
        }

        public bool updatePost(PostApi post, int id)
        {
            return this.repository.updatePost(post,id);
        }
        public List<PostLikeCountDTO> LikesCount()
        {
            return this.repository.LikesCount();


        }


    }
}
