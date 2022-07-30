using learn.core.Data;
using learn.core.Reopsitory;
using learn.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.Service
{
  public  class UserGroupService : IUserGroupService
    {
        private readonly IUserGroupRepository repository;
        public UserGroupService(IUserGroupRepository repository)
        {
            this.repository = repository;
        }

        public bool createUserGroup(UserGroupApi usergroup)
        {
            return this.repository.createUserGroup(usergroup);
        }

        public bool deleteUserGroup(int id)
        {
            return this.repository.deleteUserGroup(id);
        }

        public List<UserGroupApi> getUserGroups()
        {
            return this.repository.getUserGroups();
        }
        public int GetallMsgsCount()
        {
            return this.repository.GetallMsgsCount();


        }

    }
}
