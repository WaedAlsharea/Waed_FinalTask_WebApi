using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Service
{
  public  interface IServiceService
    {
        public bool createService(ServiceApi service);

        public bool deleteService(int id);
        public List<ServiceApi> getallServices();
        public bool updateService(ServiceApi service, int id);
    }
}
