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
  public class GroupMsgRepository : IGroupMsgRepository
    {
        private readonly IDBContext dbContext;
        public GroupMsgRepository(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool createGroupMsg(GroupMsgApi msg)
        {


            var parameter = new DynamicParameters();
            parameter.Add("textOfMsg", msg.msgText, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("senderOfMsg", msg.senderId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("reciverOfMsg", msg.groupId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.dbConnection.ExecuteAsync("GroupMsgApi_package.createGroupMsgApi", parameter, commandType: CommandType.StoredProcedure);
            if (result != null)
                return true;
            return false;
        }

        public bool deleteGroupMsg(int id)

        {
            IEnumerable<GroupMsgApi> msgs = dbContext.dbConnection.Query<GroupMsgApi>("GroupMsgApi_package.getallGroupMsgApi", commandType: CommandType.StoredProcedure);
            if (msgs.Any(m => m.gmsgId == id))
            {
                var parameter = new DynamicParameters();
                parameter.Add("idOfGroupMsgApi", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
                var result = dbContext.dbConnection.ExecuteAsync("GroupMsgApi_package.deleteGroupMsgApi", parameter, commandType: CommandType.StoredProcedure);
                if (result != null)
                    return true;
                return false;
            }
            else
                return false;
        }

        public List<GroupMsgApi> getGroupMsgs()
        {
            IEnumerable<GroupMsgApi> msgs = dbContext.dbConnection.Query<GroupMsgApi>("GroupMsgApi_package.getallGroupMsgApi", commandType: CommandType.StoredProcedure);
            return msgs.ToList();
        }

    }
}
