using learn.core.Data;
using learn.core.Repository;
using learn.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.Service
{
   public class GroupService : IGroupService
    {
        private readonly IGroupRepository repository;
        public GroupService(IGroupRepository repository)
        {
            this.repository = repository;
        }

        public bool createGroup(GroupApi group, int id )
        {
            return this.repository.createGroup(group, id);
        }

        public bool deleteGroup(int id)
        {
            return this.repository.deleteGroup(id);
        }

        public List<GroupApi> getGroups()
        {
            return this.repository.getGroups();
        }
    }
}
