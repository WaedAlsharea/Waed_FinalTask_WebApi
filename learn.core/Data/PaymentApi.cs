using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace learn.core.Data
{
   public class PaymentApi
    {
        [Key]

        public int paymentId { set; get; }
        public DateTime paymentDate { set; get; }
        public double paymentAmount { set; get; }
        public int userId { set; get; }
        public int serviceId { set; get; }


    }
}
