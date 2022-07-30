using learn.core.Data;
using learn.core.Reopsitory;
using learn.core.Service;
using learn.infra.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.Service
{
   public class CategoryService: ICategoryService
    {
        private readonly ICategoryRepository repository;
        public CategoryService(ICategoryRepository repository)
        {
            this.repository = repository;
        }

        public bool createCategory(CategoryApii category)
        {
            return this.repository.createCategory(category);
        }

        public bool deleteCategory(int id)
        {
            return this.repository.deleteCategory(id);
        }

        public List<CategoryApii> getallCategories()
        {
            return this.repository.getallCategories();
        }

        public bool updateCategory(CategoryApii category, int id)
        {
            return this.repository.updateCategory(category,id);
        }
    }
    }
