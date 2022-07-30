using learn.core.Data;
using learn.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Reopsitory
{
  public  interface IPaymentRepository
    {
        public bool createPayment(PaymentApi payment);

        public bool deletePayment(int id);
        public List<PaymentApi> getPayments();
        public bool updateVisa(VisaApi visa, int userId, int serviceId);
        public List<YearlySalesDTO> TotalSales();


    }
}
