using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Reopsitory
{
  public  interface IUserGroupRepository
    {
        public bool createUserGroup(UserGroupApi usergroup);

        public bool deleteUserGroup(int id);
        public List<UserGroupApi> getUserGroups();
        public int GetallMsgsCount();

    }
}
