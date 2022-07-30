using learn.core.Data;
using learn.core.Reopsitory;
using learn.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.Service
{
  public  class DepartmentService : IDepartmentService
    {

        private readonly IDepartmentRepository repository;
        public DepartmentService(IDepartmentRepository repository)
        {
            this.repository = repository;
        }

        public bool createDept(DepartmentApi dept)
        {
            return this.repository.createDept(dept);   
        }

        public bool deleteDept(int id)
        {
            return this.repository.deleteDept(id);
        }

        public List<DepartmentApi> getallDepts()
        {
            return this.repository.getallDepts();
        }

        public bool updateDept(DepartmentApi dept, int id)
        {
            return this.repository.updateDept(dept, id);
        }
    }
}
