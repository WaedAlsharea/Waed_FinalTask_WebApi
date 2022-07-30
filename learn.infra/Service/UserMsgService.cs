using learn.core.Data;
using learn.core.DTO;
using learn.core.Reopsitory;
using learn.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.Service
{
  public  class UserMsgService : IUserMsgService
    {
        private readonly IUserMsgRepository repository;
        public UserMsgService(IUserMsgRepository repository)
        {
            this.repository = repository;
        }

        public bool createUserMsg(UserMsgApi umsg)
        {
            return this.repository.createUserMsg(umsg);
        }

        public bool deleteUserMsg(int id)
        {
            return this.repository.deleteUserMsg(id);
        }

        public List<UserMsgApi> getUserMsgs()
        {
            return this.repository.getUserMsgs();
        }
        public int GetallMsgsCount()
        {
            return this.repository.GetallMsgsCount();


        }
        public List<UserMsgFilterDTO> MsgFilter(string msg)
        {
            return this.repository.MsgFilter(msg);

        }
        public List<UserMsgFilterDTO> MsgFilter(DateFilterDTO msg)
        {

            return this.repository.MsgFilter(msg);

        }
        public List<MsgsBackUpDTO> MsgBackUp()
        {
            return this.repository.MsgBackUp();


        }



    }
}
