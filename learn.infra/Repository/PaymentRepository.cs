using Dapper;
using learn.core.Data;
using learn.core.Domain;
using learn.core.DTO;
using learn.core.Reopsitory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace learn.infra.Repository
{
   public class PaymentRepository: IPaymentRepository
    {
        private readonly IDBContext dbContext;
        public PaymentRepository(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool createPayment(PaymentApi payment)
        {

            var parameter = new DynamicParameters();
            parameter.Add("DateOfPaymentApi", DateTime.Now, dbType: DbType.Date, direction: ParameterDirection.Input);
            parameter.Add("amountOfPaymentApi", payment.paymentAmount, dbType: DbType.Double, direction: ParameterDirection.Input);
            parameter.Add("serviceOfPaymentApi", payment.serviceId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("userOfPaymentApi", payment.userId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.dbConnection.ExecuteAsync("PaymentApi_package.createPaymentApi", parameter, commandType: CommandType.StoredProcedure);
            if (result != null)
                return true;
            return false;
        }

        public bool deletePayment(int id)
        {
            IEnumerable<PaymentApi> payments = dbContext.dbConnection.Query<PaymentApi>("PaymentApi_package.getallPaymentApi", commandType: CommandType.StoredProcedure);
            if (payments.Any(p => p.paymentId == id))
            {
                var parameter = new DynamicParameters();
                parameter.Add("idOfPaymentApi", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

                var result = dbContext.dbConnection.ExecuteAsync("PaymentApi_package.PaymentApi", parameter, commandType: CommandType.StoredProcedure);
                if (result != null)
                    return true;
                return false;
            }
            else
                return false;

        }

        public List<PaymentApi> getPayments()
        {
            IEnumerable<PaymentApi> payments = dbContext.dbConnection.Query<PaymentApi>("PaymentApi_package.getallPaymentApi", commandType: CommandType.StoredProcedure);
            return payments.ToList();
        }

        public bool updateVisa(VisaApi visa, int userId, int serviceId)
        {
            IEnumerable<ServiceApi> services = dbContext.dbConnection.Query<ServiceApi>("PaymentApi_package.getServices", commandType: CommandType.StoredProcedure);
            var service = services.Where(s => s.serviceId == serviceId).SingleOrDefault();
            PaymentApi pay = new PaymentApi();
            pay.serviceId = serviceId;
            pay.userId = userId;
            pay.paymentAmount = service.servicePrice;
            DateTime now = DateTime.Now;
            var parameter = new DynamicParameters();

            parameter.Add("nameOfOwner", visa.ownerName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("cvvOfCard", visa.cvv, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("idOfUser", visa.userId, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("priceOfService", service.servicePrice, dbType: DbType.String, direction: ParameterDirection.Input);

          
            var result = dbContext.dbConnection.ExecuteAsync("PaymentApi_package.VisaUpdate", parameter, commandType: CommandType.StoredProcedure);
            if (result != null)
          
            {
                bool done = createPayment(pay);
               return done;
            }
            else return false;

        }

        public List<YearlySalesDTO> TotalSales()
        {
            IEnumerable<YearlySalesDTO> payments = dbContext.dbConnection.Query<YearlySalesDTO>("PaymentApi_package.YearlySales", commandType: CommandType.StoredProcedure);
            return payments.ToList();
        }
    }
}
