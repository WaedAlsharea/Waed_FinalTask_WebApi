using learn.core.Data;
using learn.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Service
{
   public interface IUserService
    {
        public bool createUser(UserApi user);

        public bool deleteUser(int id);
        public List<UserApi> getallUsers();
        public bool updateUser(UserApi user , int id);
        public List<UserMsgsDTO> MsgsCount();

        public List<UserVisaCountDTO> VisaCount();
        public List<UsersCityCountDTO> CityCount();
        public string Authentication_jwt(UserApi user);


    }
}
