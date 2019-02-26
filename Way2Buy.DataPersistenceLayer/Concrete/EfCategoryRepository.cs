using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Way2Buy.BusinessObjects.Entities;
using Way2Buy.DataPersistenceLayer.Abstract;

namespace Way2Buy.DataPersistenceLayer.Concrete
{
    public class EfCategoryRepository : ICategoryRepository
    {
        readonly EfDbContext _dbContext = new EfDbContext();

        public IEnumerable<Category> Categories
        {
            get { return _dbContext.Categories.ToList(); }
        }

        public void SaveCategory(Category cat)
        {
            if (cat.CategoryId == 0)
            {
                _dbContext.Categories.Add(cat);
            }
            else
            {
                var category = _dbContext.Categories.FirstOrDefault(x => x.CategoryId == cat.CategoryId);
                if (category != null)
                {
                    category.CategoryName = cat.CategoryName;
                    category.CategoryDescription = cat.CategoryDescription;
                    category.IsActive = cat.IsActive;

                }                
            }
            _dbContext.SaveChanges();
        }

        public Category DeleteCategory(int categoryId)
        {
            var category = _dbContext.Categories.FirstOrDefault(x => x.CategoryId == categoryId);
            if (category != null)
            {
                _dbContext.Categories.Remove(category);
                _dbContext.SaveChanges();
            }
            return category;
        }

        public Category GetCategory(int categoryId)
        {
            var category = _dbContext.Categories.FirstOrDefault(x => x.CategoryId == categoryId);
            return category;
        }
    }
}
