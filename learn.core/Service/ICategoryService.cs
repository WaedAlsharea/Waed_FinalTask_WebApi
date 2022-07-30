using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Service
{
 public interface ICategoryService
    {

        public bool createCategory(CategoryApii category);


        public bool deleteCategory(int id);
        public List<CategoryApii> getallCategories();
        public bool updateCategory(CategoryApii category, int id);

    }
}
