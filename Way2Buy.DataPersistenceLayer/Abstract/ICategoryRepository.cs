using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Way2Buy.BusinessObjects.Entities;

namespace Way2Buy.DataPersistenceLayer.Abstract
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }

        void SaveCategory(Category category);

        Category DeleteCategory(int categoryId);

        Category GetCategory(int categoryId);
    }
}
