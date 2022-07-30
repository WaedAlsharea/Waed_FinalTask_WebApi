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
  public class UserMsgRepository : IUserMsgRepository
    {
        private readonly IDBContext dbContext;
        private List<string> emails = new List<string>();

        public UserMsgRepository(IDBContext dbContext)
        {
            this.dbContext = dbContext;
            emails.Add("@gmail.com");
            emails.Add("@hotmail.com");
            emails.Add("@yahoo.com");
        }


        public bool createUserMsg(UserMsgApi umsg)
        {

            DateTime now = DateTime.Now;

            var parameter = new DynamicParameters();

            parameter.Add("textOfMsg", umsg.msgText, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("dateOfMsg", now, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("senderOfMsg", umsg.senderId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("reciverOfMsg", umsg.reciverId, dbType: DbType.Int32, direction: ParameterDirection.Input);
          
            var result = dbContext.dbConnection.ExecuteAsync("UserMsgApi_package.createUserMsgApi", parameter, commandType: CommandType.StoredProcedure);
            if (result != null)
                return true;
            return false;
        }

        public bool deleteUserMsg(int id)
        {
            IEnumerable<UserMsgApi> msgs = dbContext.dbConnection.Query<UserMsgApi>("UserMsgApi_package.getallUserMsgApi", commandType: CommandType.StoredProcedure);
            if (msgs.Any(m=> m.umsgId == id))
            {
                var parameter = new DynamicParameters();
                parameter.Add("idOfUserMsgApi", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

                var result = dbContext.dbConnection.ExecuteAsync("UserMsgApi_package.deleteUserMsgApi", parameter, commandType: CommandType.StoredProcedure);
                if (result != null)
                    return true;
                return false;
            }
            else
                return false;

        }

        public List<UserMsgApi> getUserMsgs()
        {
            IEnumerable<UserMsgApi> msgs = dbContext.dbConnection.Query<UserMsgApi>("UserMsgApi_package.getallUserMsgApi", commandType: CommandType.StoredProcedure);
            return msgs.ToList();
        }
        public List<UserMsgFilterDTO> MsgFilter(string msg)
        {

            var parameter = new DynamicParameters();
            parameter.Add("msg", msg, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<UserMsgFilterDTO> msgs = dbContext.dbConnection.Query<UserMsgFilterDTO>("UserMsgApi_package.uMsgfilter", parameter, commandType: CommandType.StoredProcedure);
            return msgs.ToList();
        }
        public List<UserMsgFilterDTO> MsgFilter(DateFilterDTO msg)
        {
            var parameter = new DynamicParameters();
      
            parameter.Add("fromDate", msg.fromDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("toDate", msg.toDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);


            IEnumerable<UserMsgFilterDTO> result = dbContext.dbConnection.Query<UserMsgFilterDTO>("UserMsgApi_package.DateMsgFilter", parameter, commandType: CommandType.StoredProcedure);

            return result.ToList();

        }

        public List<MsgsBackUpDTO> MsgBackUp( )
        {
            IEnumerable<MsgsBackUpDTO> result = dbContext.dbConnection.Query<MsgsBackUpDTO>("UserMsgApi_package.MsgBackUp", commandType: CommandType.StoredProcedure);
            return result.ToList();

        }



        //public bool updateUserMsg(UserMsgApi umsg)
        //{
        //    IEnumerable<UserMsgApi> msgs = dbContext.dbConnection.Query<UserMsgApi>("UserMsgApi_package.getallUserMsgApi", commandType: CommandType.StoredProcedure);
        //    if (msgs.Any(m =>m.umsgId  == umsg.umsgId))
        //    {
        //        var parameter = new DynamicParameters();
        //        parameter.Add("textOfMsg", umsg.msgText, dbType: DbType.String, direction: ParameterDirection.Input);
        //        parameter.Add("senderOfMsg", umsg.senderId, dbType: DbType.Int32, direction: ParameterDirection.Input);
        //        parameter.Add("reciverOfMsg", umsg.reciverId, dbType: DbType.Int32, direction: ParameterDirection.Input);

        //        var result = dbContext.dbConnection.ExecuteAsync("UserMsgApi_package.UpdateUserMsgApi", parameter, commandType: CommandType.StoredProcedure);
        //        if (result != null)
        //            return true;
        //        else return false;

        //    }
        //    else return false;
        //}


        public int GetallMsgsCount()
        {

            int count = getUserMsgs().Count();
            return count;
        }

       
    }
}
