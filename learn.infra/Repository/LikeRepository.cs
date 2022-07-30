using Dapper;
using learn.core.Data;
using learn.core.Domain;
using learn.core.Reopsitory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace learn.infra.Repository
{
   public class LikeRepository: ILikeRepository
    {
        private readonly IDBContext dbContext;
        public LikeRepository(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public bool createLike(LikeApi like)
        {

            var parameter = new DynamicParameters();
            parameter.Add("userOfLikeApi", like.userId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("postOfLikeApi", like.postId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.dbConnection.ExecuteAsync("LikeApi_package.createLikeApi", parameter, commandType: CommandType.StoredProcedure);
            if (result != null)
                return true;
            return false;
        }

        public bool deleteLike(int id)
        {
            IEnumerable<LikeApi> likes = dbContext.dbConnection.Query<LikeApi>("LikeApi_package.getallLikeApi", commandType: CommandType.StoredProcedure);
            if (likes.Any(l => l.likeId == id))
            {
                var parameter = new DynamicParameters();
                parameter.Add("idOfLikeApi", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

                var result = dbContext.dbConnection.ExecuteAsync("LikeApi_package.deleteLikeApi", parameter, commandType: CommandType.StoredProcedure);
                if (result != null)
                    return true;
                return false;
            }
            else
                return false;

        }

        public List<LikeApi> getMyLikes()
        {
            IEnumerable<LikeApi> likes = dbContext.dbConnection.Query<LikeApi>("LikeApi_package.getallLikeApi", commandType: CommandType.StoredProcedure);
            return likes.ToList();
        }


    }

}
