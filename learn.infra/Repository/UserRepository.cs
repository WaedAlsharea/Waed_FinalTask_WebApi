using Dapper;
using learn.core.Data;
using learn.core.Domain;
using learn.core.DTO;
using learn.core.Reopsitory;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace learn.infra.Repository
{
   public class UserRepository : IUserRepository
    {

        private readonly IDBContext dbContext;
       private List<string> emails = new List<string>();
        private List<string> numskey = new List<string>();



        public UserRepository(IDBContext dbContext)
        {
            this.dbContext = dbContext;
            emails.Add("@gmail.com");
            emails.Add("@hotmail.com");
            emails.Add("@yahoo.com");
            numskey.Add("077");
            numskey.Add("078");
            numskey.Add("079");

        }


        public bool createUser(UserApi user)
        {
            IEnumerable<DepartmentApi> Depts = dbContext.dbConnection.Query<DepartmentApi>("UserApi_package.getDepts", commandType: CommandType.StoredProcedure);

            DateTime now = DateTime.Now;


            //Random UserNames from emp.text file
            List<string> names = new List<string>();
            using (var sr = new StreamReader(@"C:\Users\C_ROAD\Downloads\emp.txt"))
            {
                while (sr.Peek() >= 0)
                    names.Add(sr.ReadLine());
            }
            int randomNames = new Random().Next(0, names.Count());



            //Random Gender :) this is funny a little bit 
            string[] genders = new string[] { "Female", "Male" };
            int randomGender = new Random().Next(genders.Length);

            //RandomDate
            RandomDateTime date = new RandomDateTime();
        
            //Random Emails
            int randomindex = new Random().Next(0,3);
            int randomDept = new Random().Next(1, Depts.Count());

            //Random Is_Active 
            const string c = "YN";
            var Is_Active = new string(Enumerable.Repeat(c, 1)
                .Select(s => s[new Random().Next(s.Length)]).ToArray());


            //Random Alphnumeric passwords
            const string alphas = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var password = new string(Enumerable.Repeat(alphas, 8)
                .Select(s => s[new Random().Next(s.Length)]).ToArray());


            const string nums = "0123456789";
            var phonenumber = new string(Enumerable.Repeat(nums, 8)
                .Select(s => s[new Random().Next(s.Length)]).ToArray());


            var parameter = new DynamicParameters();


            parameter.Add("nameOfUser", names[randomNames], dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("phoneOfUser", numskey[randomindex] + phonenumber, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("genderOfUser", genders[randomGender], dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("emailOfUser", (String.Concat(names[randomNames].Where(c => !Char.IsWhiteSpace(c)))).ToLower() + emails[randomindex], dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("userDateOfbirth", date.Next(), dbType: DbType.Date, direction: ParameterDirection.Input);
            parameter.Add("idOfRole",2, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("idOfCity", new Random().Next(1,14), dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("idofDept", randomDept, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("passOfUser", password, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("userState", new Random().Next(1), dbType: DbType.Int32, direction: ParameterDirection.Input);
         


            var result = dbContext.dbConnection.ExecuteAsync("UserApi_package.createUserApi", parameter, commandType: CommandType.StoredProcedure);
            if (result != null)
            return true;
            return false;
        }

        public bool deleteUser(int id)
        {
            IEnumerable<UserApi> users = dbContext.dbConnection.Query<UserApi>("UserApi_package.getallUserApi", commandType: CommandType.StoredProcedure);
            if (users.Any(u => u.userId == id))
            {
                var parameter = new DynamicParameters();
                parameter.Add("idOfUserApi", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

                var result = dbContext.dbConnection.ExecuteAsync("UserApi_package.deleteUserApi", parameter, commandType: CommandType.StoredProcedure);
                return true;
            }
            else
                return false;

        }

        public List<UserApi> getallUsers()
        {
            IEnumerable<UserApi> result = dbContext.dbConnection.Query<UserApi>("UserApi_package.getallUserApi", commandType: CommandType.StoredProcedure);
            return result.ToList();

        }

        public bool updateUser(UserApi user , int id)
        {
            IEnumerable<UserApi> users = dbContext.dbConnection.Query<UserApi>("UserApi_package.getallUserApi", commandType: CommandType.StoredProcedure);
            if (users.Any(u => u.userId == id))
            {
                var parameter = new DynamicParameters();
                parameter.Add("idOfUserApi", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

                parameter.Add("nameOfUser", user.userName, dbType: DbType.String, direction: ParameterDirection.Input);
                parameter.Add("phoneOfUser",user.userPhone , dbType: DbType.String, direction: ParameterDirection.Input);
                parameter.Add("genderOfUser", user.userGender, dbType: DbType.String, direction: ParameterDirection.Input);

                parameter.Add("emailOfUser",user.userEmail, dbType: DbType.String, direction: ParameterDirection.Input);
                parameter.Add("userDateOfbirth", user.userbirthDate, dbType: DbType.Date, direction: ParameterDirection.Input);
                parameter.Add("idOfRole",user.roleId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                parameter.Add("idOfCity", user.countryId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                parameter.Add("idofDept", user.countryId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                parameter.Add("passOfUser", user.userPass, dbType: DbType.String, direction: ParameterDirection.Input);
                parameter.Add("userState", user.Is_Active, dbType: DbType.Int32, direction: ParameterDirection.Input);


                var result = dbContext.dbConnection.ExecuteAsync("UserApi_package.UpdateUserApi", parameter, commandType: CommandType.StoredProcedure);
                if (result != null)
                return true;
                else return false;

            }
            else return false;
        }



        public List<UserMsgsDTO> MsgsCount()
        {

            IEnumerable<UserMsgsDTO> result = dbContext.dbConnection.Query<UserMsgsDTO>("UserApi_package.userMsgsCount", commandType: CommandType.StoredProcedure);
            return result.ToList();

        }
        
         public List<UserVisaCountDTO> VisaCount()
        {

            IEnumerable<UserVisaCountDTO> result = dbContext.dbConnection.Query<UserVisaCountDTO>("UserApi_package.userVisaCount", commandType: CommandType.StoredProcedure);
            return result.ToList();

        }

        public List<UsersCityCountDTO> CityCount()
        {

            IEnumerable<UsersCityCountDTO> result = dbContext.dbConnection.Query<UsersCityCountDTO>("UserApi_package.userCountryCount", commandType: CommandType.StoredProcedure);
            return result.ToList();

        }

        public UserApi Authentication_jwt(UserApi user)
        {
            var parameter = new DynamicParameters();
        

            IEnumerable<UserApi> users = dbContext.dbConnection.Query<UserApi>("UserApi_package.getallUserApi", commandType: CommandType.StoredProcedure);

            var result = users.Where(u => u.userName == user.userName && u.userPass == user.userPass).SingleOrDefault();

            return result;
        }

      
    }
}
