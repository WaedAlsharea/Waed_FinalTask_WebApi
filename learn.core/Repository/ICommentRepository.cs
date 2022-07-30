using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Reopsitory
{
   public interface ICommentRepository
    {
        public bool createComment(CommentApi comment);

        public bool deleteComment(int id);

        public List<CommentApi> getMyComments();

        public bool updateComment(CommentApi comment, int id);
    }
}
