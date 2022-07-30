using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace learn.core.Data
{
    public class UserApi
    {
        [Key]
        public int userId { set; get; }
        public string userName { set; get; }
        public string userEmail { set; get; }

        public string userPhone { set; get; }
        public string userGender { set; get; }
        public DateTime userbirthDate { set; get; }
        public int Is_Active { set; get; }
        public string userPass { set; get; }
        
        public int roleId { set; get; }
        public int countryId { set; get; }
        public int departmentId { set; get; }



    }
}
