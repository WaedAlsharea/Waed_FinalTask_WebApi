using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Service
{
   public interface IGroupService
    {
        public bool createGroup(GroupApi group, int id);

        public bool deleteGroup(int id);
        public List<GroupApi> getGroups();
    }
}
