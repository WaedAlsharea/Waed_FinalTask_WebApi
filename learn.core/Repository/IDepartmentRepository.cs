using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Reopsitory
{
   public interface IDepartmentRepository
    {
        public bool createDept(DepartmentApi dept);

        public bool deleteDept(int id);
        public List<DepartmentApi> getallDepts();
        public bool updateDept(DepartmentApi dept, int id);
    }
}
