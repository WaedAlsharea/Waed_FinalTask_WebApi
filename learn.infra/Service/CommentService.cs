using learn.core.Data;
using learn.core.Reopsitory;
using learn.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.Service
{
  public  class CommentService : ICommentService

    {
        private readonly ICommentRepository repository;
        public CommentService(ICommentRepository repository)
        {
            this.repository = repository;
        }

        public bool createComment(CommentApi comment)
        {
            return this.repository.createComment(comment);       
        }

        public bool deleteComment(int id)
        {
            return this.repository.deleteComment(id);
        }

        public List<CommentApi> getMyComments()
        {
            return this.repository.getMyComments();
        }

        public bool updateComment(CommentApi comment, int id)
        {
            return this.repository.updateComment(comment, id);
        }
    }
}
