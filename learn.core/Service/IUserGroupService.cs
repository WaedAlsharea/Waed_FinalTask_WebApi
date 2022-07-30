using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Service
{
  public  interface IUserGroupService
    {
        public bool createUserGroup(UserGroupApi usergroup);

        public bool deleteUserGroup(int id);
        public List<UserGroupApi> getUserGroups();
        public int GetallMsgsCount();


    }
}
