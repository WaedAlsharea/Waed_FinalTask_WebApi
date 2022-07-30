using Dapper;
using learn.core.Data;
using learn.core.Domain;
using learn.core.Reopsitory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learn.infra.Repository
{
    public class CommentRepository: ICommentRepository
    {
        private readonly IDBContext dbContext;
        public CommentRepository(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool createComment(CommentApi comment)
        {


            var parameter = new DynamicParameters();
            parameter.Add("dateOfCommentApi", comment.creationdate, dbType: DbType.Date, direction: ParameterDirection.Input);
            parameter.Add("textOfCommentApi", comment.commenText, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("userOfCommentApi", comment.userId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("postOfCommentApi", comment.postId, dbType: DbType.Int32, direction: ParameterDirection.Input);

           var  result =  dbContext.dbConnection.ExecuteAsync("CommentApi_package.createCommentApi", parameter, commandType: CommandType.StoredProcedure);
            if (result != null)
                return true;
            return false;
        }

        public bool deleteComment(int id)
        {
            IEnumerable<CommentApi> comments = dbContext.dbConnection.Query<CommentApi>("CommentApi_package.getallCommentApi", commandType: CommandType.StoredProcedure);
            if (comments.Any(c => c.commentId == id))
            {
                var parameter = new DynamicParameters();
                parameter.Add("idOfCommentApi", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
                var result = dbContext.dbConnection.ExecuteAsync("CommentApi_package.deleteCommentApi", parameter, commandType: CommandType.StoredProcedure);
                return true;
            }
            else
                return false;
        }

        public  List<CommentApi> getMyComments()
        {
            IEnumerable<CommentApi> comments = dbContext.dbConnection.Query<CommentApi>("CommentApi_package.getallCommentApi", commandType: CommandType.StoredProcedure);
            return comments.ToList();
        }

        public bool updateComment(CommentApi comment, int id)
        {
            IEnumerable<CommentApi> comments = dbContext.dbConnection.Query<CommentApi>("CommentApi_package.getallCommentApi", commandType: CommandType.StoredProcedure);
            if (comments.Any(c=> c.commentId == id))
            {
                var parameter = new DynamicParameters();
               parameter.Add("textOfCommentApi", comment.commenText, dbType: DbType.String, direction: ParameterDirection.Input);

                var result = dbContext.dbConnection.ExecuteAsync("CommentApi_package.UpdateCommentApi", parameter, commandType: CommandType.StoredProcedure);
                if (result != null)
                    return true;
                else return false;

            }
            else return false;
        }

    }
}
