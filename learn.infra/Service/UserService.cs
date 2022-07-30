using learn.core.Data;
using learn.core.DTO;
using learn.core.Reopsitory;
using learn.core.Service;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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
          public string Authentication_jwt(UserApi user)
        {
            var tokenhandler = new JwtSecurityTokenHandler();
            var tokenkey = Encoding.ASCII.GetBytes("[SECRET Used To Sign And Verify Jwt Token,It can be any string]");
            var tokenDescirptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(
                new Claim[]
                {
                    new Claim("userName", user.userName),
                    new Claim("userPass", user.userPass),
             





                }
                ),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256Signature)


            };

            var generatetoken = tokenhandler.CreateToken(tokenDescirptor);
            return tokenhandler.WriteToken(generatetoken);
        }

    }
}
