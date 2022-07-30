using Dapper;
using learn.core.Data;
using learn.core.Domain;
using learn.core.Reopsitory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace learn.infra.Repository
{
  public class ServiceRepository : IServiceRepository
    {
        private readonly IDBContext dbContext;
        public ServiceRepository(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }





        public bool createService(ServiceApi service)
        {


            var parameter = new DynamicParameters();
            parameter.Add("nameOfServiceApi", service.serviceName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("priceOfServiceApi", service.servicePrice, dbType: DbType.Double, direction: ParameterDirection.Input);
            parameter.Add("categoryOfServiceApi", service.categoryId, dbType: DbType.Int32, direction: ParameterDirection.Input);





            var result = dbContext.dbConnection.ExecuteAsync("ServiceApi_package.createServiceApi", parameter, commandType: CommandType.StoredProcedure);
            if (result != null)
                return true;
            return false;
        }


        public bool deleteService(int id)
        {
            IEnumerable<ServiceApi> services = dbContext.dbConnection.Query<ServiceApi>("ServiceApi_package.getallServiceApi", commandType: CommandType.StoredProcedure);
            if (services.Any(s => s.serviceId == id))
            {
                var parameter = new DynamicParameters();
                parameter.Add("idOfServiceApi", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

                var result = dbContext.dbConnection.ExecuteAsync("ServiceApi_package.deleteServiceApi", parameter, commandType: CommandType.StoredProcedure);
                return true;
            }
            else
                return false;

        }

        public List<ServiceApi> getallServices()
        {
            IEnumerable<ServiceApi> services = dbContext.dbConnection.Query<ServiceApi>("ServiceApi_package.getallServiceApi", commandType: CommandType.StoredProcedure);
            return services.ToList();
        }

        public bool updateService(ServiceApi service, int id)
        {
            IEnumerable<ServiceApi> services = dbContext.dbConnection.Query<ServiceApi>("ServiceApi_package.getallServiceApi", commandType: CommandType.StoredProcedure);
            if (services.Any(s => s.serviceId == id))
            {
                var parameter = new DynamicParameters();

                parameter.Add("nameOfServiceApi", service.serviceName, dbType: DbType.String, direction: ParameterDirection.Input);
                parameter.Add("priceOfServiceApi", service.servicePrice, dbType: DbType.Double, direction: ParameterDirection.Input);
                parameter.Add("categoryOfServiceApi", service.categoryId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                var result = dbContext.dbConnection.ExecuteAsync("ServiceApi_package.UpdateServiceApi", parameter, commandType: CommandType.StoredProcedure);
                if (result != null)
                    return true;
                else return false;

            }
            else return false;
        }






    }
}
