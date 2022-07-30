using learn.core.Data;
using learn.core.DTO;
using learn.core.Reopsitory;
using learn.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.Service
{
   public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository repository;
        public PaymentService(IPaymentRepository repository)
        {
            this.repository = repository;
        }

        public bool createPayment(PaymentApi payment)
        {
            return this.repository.createPayment(payment);
        }

        public bool deletePayment(int id)
        {
            return this.repository.deletePayment(id);
        }

        public List<PaymentApi> getPayments()
        {
            return this.repository.getPayments();
        }
        public bool updateVisa(VisaApi visa, int userId, int serviceId)
        {
            return this.repository.updateVisa(visa, userId, serviceId);

        }
        public List<YearlySalesDTO> TotalSales()
        {
            return this.repository.TotalSales();


        }


    }
}
