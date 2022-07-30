using learn.core.Data;
using learn.core.Reopsitory;
using learn.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.Service
{
  public  class ServiceService: IServiceService
    {
        private readonly IServiceRepository repository;
        public ServiceService(IServiceRepository repository)
        {
            this.repository = repository;
        }

        public bool createService(ServiceApi service)
        {
            return this.repository.createService(service);
        }

        public bool deleteService(int id)
        {
            return this.repository.deleteService(id);
        }

        public List<ServiceApi> getallServices()
        {
            return this.repository.getallServices();
        }

        public bool updateService(ServiceApi service, int id)
        {
            return this.repository.updateService(service,id);
        }
    }
}
