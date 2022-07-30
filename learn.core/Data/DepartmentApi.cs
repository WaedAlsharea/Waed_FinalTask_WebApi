using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace learn.core.Data
{
   public class DepartmentApi
    {
        [Key]
        public int departmentId { set; get; }
        public string departmentName { set; get; }

    }
}
