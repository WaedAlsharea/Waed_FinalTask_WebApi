using Dapper;
using learn.core.Data;
using learn.core.Domain;
using learn.core.Reopsitory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace learn.infra.Repository
{
   public class CategoryRepository : ICategoryRepository
    {
        private readonly IDBContext dbContext;
        public CategoryRepository(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public bool createCategory(CategoryApii category)
        {


            var parameter = new DynamicParameters();
            parameter.Add("nameOfCategoryApi", category.categoryName, dbType: DbType.String, direction: ParameterDirection.Input);



            var result = dbContext.dbConnection.ExecuteAsync("CategoryApii_package.createCategoryApi", parameter, commandType: CommandType.StoredProcedure);
            if (result != null)
                return true;
            return false;
        }


        public bool deleteCategory(int id)
        {
            IEnumerable<CategoryApii> categories = dbContext.dbConnection.Query<CategoryApii>("CategoryApii_package.getallCategoryApi", commandType: CommandType.StoredProcedure);
            if (categories.Any(c => c.categoryId == id))
            {
                var parameter = new DynamicParameters();
                parameter.Add("idOfCategoryApi", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

                var result = dbContext.dbConnection.ExecuteAsync("CategoryApii_package.deleteCategoryApi", parameter, commandType: CommandType.StoredProcedure);
                return true;
            }
            else
                return false;

        }

        public  List<CategoryApii> getallCategories()
        {
            IEnumerable<CategoryApii> categories = dbContext.dbConnection.Query<CategoryApii>("CategoryApii_package.getallCategoryApi", commandType: CommandType.StoredProcedure);
            return categories.ToList();
        }


        public bool updateCategory(CategoryApii category, int id)
        {
            IEnumerable<CategoryApii> categories = dbContext.dbConnection.Query<CategoryApii>("CategoryApii_package.getallCategoryApi", commandType: CommandType.StoredProcedure);
            if (categories.Any(c => c.categoryId == id))
            {
                var parameter = new DynamicParameters();

                parameter.Add("nameOfCategoryApi", category.categoryName, dbType: DbType.String, direction: ParameterDirection.Input);
                var result = dbContext.dbConnection.ExecuteAsync("CategoryApii_package.UpdateCategoryApi", parameter, commandType: CommandType.StoredProcedure);
                if (result != null)
                    return true;
                else return false;

            }
            else return false;
        }



    }
}
