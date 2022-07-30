using learn.core.Data;
using learn.core.DTO;
using learn.core.Reopsitory;
using learn.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository repository;
        public UserService(IUserRepository repository)
        {
            this.repository = repository;
        }

        public bool createUser(UserApi user)
        {
            return this.repository.createUser(user);
        }

        public bool deleteUser(int id)
        {
            return this.repository.deleteUser(id);
        }

        public List<UserApi> getallUsers()
        {
            return this.repository.getallUsers();
        }

        public bool updateUser(UserApi user, int id)
        {
            return this.repository.updateUser(user, id);
        }
        public List<UserMsgsDTO> MsgsCount()
        {
            return this.repository.MsgsCount();


        }
        public List<UserVisaCountDTO> VisaCount()
        {
            return this.repository.VisaCount();


        }
        public List<UsersCityCountDTO> CityCount()
        {
            return this.repository.CityCount();
 
        }

    }
}
