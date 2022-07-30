using learn.core.Data;
using learn.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Reopsitory
{
  public  interface IUserMsgRepository
    {
        public bool createUserMsg(UserMsgApi umsg);

        public bool deleteUserMsg(int id);
        public List<UserMsgApi> getUserMsgs();
        public int GetallMsgsCount();
        public List<UserMsgFilterDTO> MsgFilter(string msg);
        public List<UserMsgFilterDTO> MsgFilter(DateFilterDTO msg);
        public List<MsgsBackUpDTO> MsgBackUp();





    }
}
