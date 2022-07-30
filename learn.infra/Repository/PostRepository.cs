using Dapper;
using learn.core.Data;
using learn.core.Domain;
using learn.core.DTO;
using learn.core.Reopsitory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace learn.infra.Repository
{
   public class PostRepository: IPostRepository
    {
        private readonly IDBContext dbContext;
        public PostRepository(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool createPost(PostApi post)
        {


            var parameter = new DynamicParameters();
            parameter.Add("dateOfPostApi", post.creationDate, dbType: DbType.Date, direction: ParameterDirection.Input);
            parameter.Add("textOfPostApi", post.postText, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("userOfPostApi", post.userId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.dbConnection.ExecuteAsync("PostApi_package.createPostApi", parameter, commandType: CommandType.StoredProcedure);
            if (result != null)
                return true;
            return false;
        }

        public bool deletePost(int id)
        {
            IEnumerable<PostApi> posts = dbContext.dbConnection.Query<PostApi>("PostApi_package.getallPostApi", commandType: CommandType.StoredProcedure);
            if (posts.Any(p => p.postId == id))
            {
                var parameter = new DynamicParameters();
                parameter.Add("idOfPostApi", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
                var result = dbContext.dbConnection.ExecuteAsync("PostApi_package.deletePostApi", parameter, commandType: CommandType.StoredProcedure);
                return true;
            }
            else
                return false;
        }

        public List<PostApi> getMyPosts()
        {
            IEnumerable<PostApi> posts = dbContext.dbConnection.Query<PostApi>("PostApi_package.getallPostApi", commandType: CommandType.StoredProcedure);
            return posts.ToList();
        }

        public bool updatePost(PostApi post, int id)
        {
            IEnumerable<PostApi> posts = dbContext.dbConnection.Query<PostApi>("PostApi_package.getallPostApi", commandType: CommandType.StoredProcedure);
            if (posts.Any(p => p.postId == id))
            {
                var parameter = new DynamicParameters();
                parameter.Add("dateOfPostApi", post.creationDate, dbType: DbType.Date, direction: ParameterDirection.Input);
                parameter.Add("textOfPostApi", post.postText, dbType: DbType.String, direction: ParameterDirection.Input);
                parameter.Add("userOfPostApi", post.userId, dbType: DbType.Int32, direction: ParameterDirection.Input);

                var result = dbContext.dbConnection.ExecuteAsync("PostApi_package.UpdatePostApi", parameter, commandType: CommandType.StoredProcedure);
                if (result != null)
                    return true;
                else return false;

            }
            else return false;
        }
        public List<PostLikeCountDTO> LikesCount()
        {

            IEnumerable<PostLikeCountDTO> result = dbContext.dbConnection.Query<PostLikeCountDTO>("PostApi_package.postLikesCount", commandType: CommandType.StoredProcedure);
            return result.ToList();

        }


    }
}
