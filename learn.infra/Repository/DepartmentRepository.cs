using Dapper;
using learn.core.Data;
using learn.core.Domain;
using learn.core.Reopsitory;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace learn.infra.Repository
{
   public class DepartmentRepository: IDepartmentRepository
    {
        private readonly IDBContext dbContext;
        public DepartmentRepository(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool createDept(DepartmentApi dept)
        {
            //insert all data in the units.txt file
            List<string> Depts = new List<string>();
            using (var sr = new StreamReader(@"C:\Users\C_ROAD\Downloads\units.txt"))
            {
                while (sr.Peek() >= 0)
                    Depts.Add(sr.ReadLine());
            }






            var parameter = new DynamicParameters();
            foreach (var dep in Depts)
            {
                parameter.Add("nameOfDepartmentApi", dep, dbType: DbType.String, direction: ParameterDirection.Input);
                 dbContext.dbConnection.ExecuteAsync("DepartmentApi_package.createDepartmentApi", parameter, commandType: CommandType.StoredProcedure);

             
            }
            return true;
        }

        public bool deleteDept(int id)
        {
            IEnumerable<DepartmentApi> depts = dbContext.dbConnection.Query<DepartmentApi>("DepartmentApi_package.getallDepartmentApi", commandType: CommandType.StoredProcedure);
            if (depts.Any(d => d.departmentId == id))
            {
                var parameter = new DynamicParameters();
                parameter.Add("idOfDepartmentApi", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

                var result = dbContext.dbConnection.ExecuteAsync("DepartmentApi_package.deleteDepartmentApi", parameter, commandType: CommandType.StoredProcedure);
                return true;
            }
            else
                return false;

        }

        public List<DepartmentApi> getallDepts()
        {
            IEnumerable<DepartmentApi> depts = dbContext.dbConnection.Query<DepartmentApi>("DepartmentApi_package.getallDepartmentApi", commandType: CommandType.StoredProcedure);
            return depts.ToList();
        }

        public bool updateDept(DepartmentApi dept, int id)
        {
            IEnumerable<DepartmentApi> depts = dbContext.dbConnection.Query<DepartmentApi>("DepartmentApi_package.getallDepartmentApi", commandType: CommandType.StoredProcedure);
            if (depts.Any(d => d.departmentId == id))
            {
                var parameter = new DynamicParameters();

                parameter.Add("nameOfDepartmentApi", dept.departmentName, dbType: DbType.String, direction: ParameterDirection.Input);
                var result = dbContext.dbConnection.ExecuteAsync("DepartmentApi_package.UpdateDepartmentApi", parameter, commandType: CommandType.StoredProcedure);
                if (result != null)
                    return true;
                else return false;

            }
            else return false;
        }





    }
}
