using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace learn.core.Data
{
  public class CategoryApii
    {
        [Key]
        public int categoryId { set; get; }
        public string categoryName { set; get; }

    }
}
