using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace learn.core.Data
{
  public  class ServiceApi
    {
        [Key]
        public int serviceId { set; get; }
        public string serviceName { set; get; }
        public double servicePrice { set; get; }
        public int categoryId { set; get; }

            
    }
}
