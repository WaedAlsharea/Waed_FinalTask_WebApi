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
   public class UserGroupRepository: IUserGroupRepository
    {
        private readonly IDBContext dbContext;
        public UserGroupRepository(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool createUserGroup(UserGroupApi usergroup)
        {


            var parameter = new DynamicParameters();
            parameter.Add("idOfGroup", usergroup.groupId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("idOfUser", usergroup.userId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.dbConnection.ExecuteAsync("UserGroupApi_package.createUserGroupApi", parameter, commandType: CommandType.StoredProcedure);
            if (result != null)
                return true;
            return false;
        }

        public bool deleteUserGroup(int id)
        {
            IEnumerable<UserGroupApi> groups = dbContext.dbConnection.Query<UserGroupApi>("UserGroupApi_package.getallUserGroupApi", commandType: CommandType.StoredProcedure);
            if (groups.Any(g => g.ugroupId == id))
            {
                var parameter = new DynamicParameters();
                parameter.Add("idOfUserGroupApi", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
                var result = dbContext.dbConnection.ExecuteAsync("UserGroupApi_package.deleteUserGroupApi", parameter, commandType: CommandType.StoredProcedure);
                if (result != null)
                    return true;
                return false;
            }
            else
                return false;
        }

        public List<UserGroupApi> getUserGroups()
        {
            IEnumerable<UserGroupApi> groups = dbContext.dbConnection.Query<UserGroupApi>("UserGroupApi_package.getallUserGroupApi", commandType: CommandType.StoredProcedure);
            return groups.ToList();
        }
        public int GetallMsgsCount()
        {

            int count = getUserGroups().Count();
            return count;
        }

    }
}
