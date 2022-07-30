using Dapper;
using learn.core.Data;
using learn.core.Domain;
using learn.core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace learn.infra.Repository
{
   public class GroupRepository: IGroupRepository
    {
        private readonly IDBContext dbContext;
        public GroupRepository(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool createGroup(GroupApi group , int id)
        {
            // The id parameter here  is the id of user who created the group , i.e. the Admin of the group  

            int random = new Random().Next(0, 3);

            var parameter = new DynamicParameters();
            parameter.Add("nameOfGroupApi", group.groupName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("dateOfGroupApi", group.creationDate , dbType: DbType.Date, direction: ParameterDirection.Input);
            parameter.Add("adminOfGroupApi", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
       
            var result = dbContext.dbConnection.ExecuteAsync("GroupApi_package.createGroupApi", parameter, commandType: CommandType.StoredProcedure);
            if (result != null)
                return true;
            return false;
        }



        public bool deleteGroup(int id)
        {
            IEnumerable<GroupApi> groups = dbContext.dbConnection.Query<GroupApi>("UserApi_package.getallUserApi", commandType: CommandType.StoredProcedure);
            if (groups.Any(g => g.groupId == id))
            {
                var parameter = new DynamicParameters();
                parameter.Add("idOfGroupApi", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

                var result = dbContext.dbConnection.ExecuteAsync("GroupApi_package.deleteGroupApi", parameter, commandType: CommandType.StoredProcedure);
                return true;
            }
            else
                return false;

        }

        public List<GroupApi> getGroups()
        {
            IEnumerable<GroupApi> groups = dbContext.dbConnection.Query<GroupApi>("GroupApi_package.getallGroupApi", commandType: CommandType.StoredProcedure);
            return groups.ToList();
        }



    }

}
