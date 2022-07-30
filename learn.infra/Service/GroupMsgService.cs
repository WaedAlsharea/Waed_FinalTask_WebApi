using learn.core.Data;
using learn.core.Reopsitory;
using learn.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.Service
{
  public  class GroupMsgService : IGroupMsgService
    {
        private readonly IGroupMsgRepository repository;
        public GroupMsgService(IGroupMsgRepository repository)
        {
            this.repository = repository;
        }

        public bool createGroupMsg(GroupMsgApi msg)
        {
            return this.repository.createGroupMsg(msg);
        }

        public bool deleteGroupMsg(int id)
        {
            return this.repository.deleteGroupMsg(id);
        }

        public List<GroupMsgApi> getGroupMsgs()
        {
            return this.repository.getGroupMsgs();
        }
    }
}
