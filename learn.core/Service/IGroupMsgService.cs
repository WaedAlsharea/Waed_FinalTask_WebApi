using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Service
{
   public interface IGroupMsgService
    {
        public bool createGroupMsg(GroupMsgApi msg);

        public bool deleteGroupMsg(int id);
        public List<GroupMsgApi> getGroupMsgs();

    }
}
