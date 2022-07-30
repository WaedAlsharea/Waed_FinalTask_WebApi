using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Reopsitory
{
  public interface ICategoryRepository
    {
        public bool createCategory(CategoryApii category);

        public bool deleteCategory(int id);
        public List<CategoryApii> getallCategories();
        public bool updateCategory(CategoryApii category, int id);

    }
}
